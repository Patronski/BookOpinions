﻿using BookOpinions.Models.BindingModels.Book;
using BookOpinions.Models.EntityModels;
using BookOpinions.Models.ViewModels.Book;
using BookOpinions.Models.ViewModels.Home;
using BookOpinions.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookOpinions.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class BookController : BaseController
    {
        private BookService service;

        public BookController()
        {
            this.service = new BookService();
        }
        
        [Route("book/add")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("book/add")]
        public ActionResult Add(AddBookBindingModel bm)
        {
            if (ModelState.IsValid)
            {
                this.CurrentUser = UserManager.FindById(this.User.Identity.GetUserId());
                this.service.AddNewBook(bm, this.CurrentUser);
                TempData["AddedBook"] = $"Successfully added book {bm.Title}";

                return this.RedirectToAction("all", "book");
            }
            return this.RedirectToAction("add");
        }

        [Route("book/all/{sortOrder?}")]
        public ActionResult All(string sortOrder)
        {
            IEnumerable<SimpleBookViewModel> vms;

            vms = this.service.GetAllBooksBySortOrder(sortOrder);

            return View(vms);
        }

        [Route("book/{id}")]
        public ActionResult About(int id)
        {
            Book vm = this.service.GetBookById(id);

            return View(vm);
        }

        [Route("book/SendRating/{vote}/{s}/{id}/{url}")]
        public JsonResult SendRating(string vote, string s, string id, string url)
        {
            int autoId = 0;
            Int16 thisVote = 0;
            Int16 sectionId = 0;
            Int16.TryParse(s, out sectionId);
            Int16.TryParse(vote, out thisVote);
            int.TryParse(id, out autoId);
            this.CurrentUser = UserManager.FindById(this.User.Identity.GetUserId());

            if (!User.Identity.IsAuthenticated)
            {
                return Json("Not authenticated!");
            }

            if (autoId.Equals(0))
            {
                return Json("Sorry, record to vote doesn't exists");
            }


            // school voting
            // check if he has already voted
            Book userVotedForThisBook = context.Books
                .FirstOrDefault(b => b.Id == autoId && b.Rating.Any(rate => rate.User == this.CurrentUser));
            if (userVotedForThisBook != null)
            {
                // keep the school voting flag to stop voting by this member
                HttpCookie cookie = new HttpCookie(url, "true");
                Response.Cookies.Add(cookie);
                return Json("<br />You have already rated this post, thanks !");
            }

            var book = context.Books.FirstOrDefault(b => b.Id == autoId);
            if (book != null)
            {
                object obj = book.Rating.FirstOrDefault(rating=> rating.User == CurrentUser);

                string updatedVotes = string.Empty;
                string[] votes = null;
                if (obj != null && obj.ToString().Length > 0)
                {
                    string currentVotes = obj.ToString(); // votes pattern will be 0,0,0,0,0
                    votes = currentVotes.Split(',');
                    // if proper vote data is there in the database
                    if (votes.Length.Equals(5))
                    {
                        // get the current number of vote count of the selected vote, always say -1 than the current vote in the array 
                        int currentNumberOfVote = int.Parse(votes[thisVote - 1]);
                        // increase 1 for this vote
                        currentNumberOfVote++;
                        // set the updated value into the selected votes
                        votes[thisVote - 1] = currentNumberOfVote.ToString();
                    }
                    else
                    {
                        votes = new string[] { "0", "0", "0", "0", "0" };
                        votes[thisVote - 1] = "1";
                    }
                }
                else
                {
                    votes = new string[] { "0", "0", "0", "0", "0" };
                    votes[thisVote - 1] = "1";
                }

                // concatenate all arrays now
                foreach (string ss in votes)
                {
                    updatedVotes += ss + ",";
                }
                updatedVotes = updatedVotes.Substring(0, updatedVotes.Length - 1);

                context.Entry(book).State = EntityState.Modified;
                Rating currentRating = new Rating()
                {
                    User = CurrentUser,
                    Book = book,
                    Rate = thisVote
                };

                book.Rating.Add(currentRating); /*= updatedVotes;*/
                context.SaveChanges();

                // keep the school voting flag to stop voting by this member
                HttpCookie cookie = new HttpCookie(url, "true");
                Response.Cookies.Add(cookie);
            }

            return Json("<br />You rated " + thisVote + " star(s), thanks !");
        }
    }
}
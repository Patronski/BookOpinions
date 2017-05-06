using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookOpinions.Models.BindingModels.Book;
using BookOpinions.Models.EntityModels;
using BookOpinions.Models.ViewModels.Home;
using BookOpinions.Models.FunctionalityModels;
using BookOpinions.Models.ViewModels.Book;

namespace BookOpinions.Services
{
    public class BookService : Service
    {
        public void AddNewBook(AddBookBindingModel bm, ApplicationUser currentUser)
        {
            var authors = bm
                .AuthorName
                .Split(',')
                .Select(name => new Author
                {
                    Name = name,
                })
                .ToList();

            Image image = new Image()
            {
                Url = bm.ImageUrl
            };

            Book book = new Book()
            {
                Authors = authors,
                Title = bm.Title,
                Image = image,
            };

            this.Context.Books.Add(book);
            this.Context.SaveChanges();
        }

        public AllBooksViewModel GetAllBooksBySortOrderForPage(string sortOrder, int? page, int booksOnPage)
        {
            IEnumerable<SimpleBookViewModel> books;

            var sortToLower = sortOrder != null ? sortOrder.ToLower() : null;

            switch (sortToLower)
            {
                case "author":
                    books = this.Context.Books
                        .Select(b => new SimpleBookViewModel
                        {
                            Id = b.Id,
                            ImgUrl = b.Image.Url,
                            Title = b.Title,
                            Author = b.Authors.FirstOrDefault() //Todo
                        })
                        .OrderBy(sb => sb.Author.Name);
                    break;
                case "title":
                    books = this.Context.Books
                        .Select(b => new SimpleBookViewModel
                        {
                            Id = b.Id,
                            ImgUrl = b.Image.Url,
                            Title = b.Title,
                            Author = b.Authors.FirstOrDefault()
                        })
                        .OrderBy(sb=> sb.Title);
                    break;
                case "newfirst":
                    books = this.Context.Books
                        .Select(b => new SimpleBookViewModel
                        {
                            Id = b.Id,
                            ImgUrl = b.Image.Url,
                            Title = b.Title,
                            Author = b.Authors.FirstOrDefault()
                        });
                    books = books
                        .Reverse();
                    break;
                default:
                    books = this.Context.Books
                        .Select(b => new SimpleBookViewModel
                        {
                            Id = b.Id,
                            ImgUrl = b.Image.Url,
                            Title = b.Title,
                            Author = b.Authors.FirstOrDefault()
                        });
                    break;
            }

            var pager = new Pager(books.Count(), page, 6 * 3);
            var viewModel = new AllBooksViewModel
            {
                Books = books
                        .Skip((pager.CurrentPage - 1) * pager.ItemsOnPage)
                        .Take(pager.ItemsOnPage),
                Pager = pager,
                SortOrder = sortOrder
            };

            return viewModel;
        }

        public Book GetBookById(int id)
        {
            return this.Context.Books.Find(id);
        }
    }
}

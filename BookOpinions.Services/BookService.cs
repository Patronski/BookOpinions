using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookOpinions.Models.BindingModels.Book;
using BookOpinions.Models.EntityModels;

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
    }
}

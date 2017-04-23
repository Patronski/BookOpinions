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
        public void AddNewBook(AddBookBindingModel bm)
        {
            Book book = Mapper.Map<AddBookBindingModel, Book>(bm);

            this.Context.Books.Add(book);
            this.Context.SaveChanges();
        }
    }
}

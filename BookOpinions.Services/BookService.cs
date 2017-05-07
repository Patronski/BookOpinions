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
                    Name = name.Trim(),
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

        public AllBooksViewModel GetAllBooksBySortOrderForPage(string sortOrder, string search, int? page, int booksOnPage)
        {
            IEnumerable<SimpleBookViewModel> books = this.Context.Books
                .Select(b => new SimpleBookViewModel
                {
                    Id = b.Id,
                    ImgUrl = b.Image.Url,
                    Title = b.Title,
                    Author = b.Authors.FirstOrDefault() //Todo not only first author. All!
                });
            
            var sortToLower = sortOrder != null ? sortOrder.ToLower() : null;
            switch (sortToLower)
            {
                case "author":
                    books = books.OrderBy(sb => sb.Author != null ? sb.Author.Name : "Я");
                    break;
                case "title":
                    books = books.OrderBy(sb => sb.Title);
                    break;
                case "newfirst":
                    books = books.Reverse();
                    break;
                default:
                    break;
            }

            if (!string.IsNullOrEmpty(search))
            {
                var searchWords = search.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(w => w.ToLower());
                books = books.Where(b =>
                {
                    var titleWords = b.Title.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(w=> w.ToLower());
                    var rezult = false;
                    foreach (var titleWord in titleWords)
                    {
                        if (searchWords.Any(sw=> titleWord.StartsWith(sw)))
                        {
                            rezult = true;
                        }
                    }
                    return rezult;
                });
            }

            Pager pager = new Pager(books.Count(), page, booksOnPage);
            var viewModel = new AllBooksViewModel
            {
                Books = books
                        .Skip((pager.CurrentPage - 1) * booksOnPage)
                        .Take(booksOnPage),
                Pager = pager,
                SortOrder = sortOrder,
                Search = search
            };

            return viewModel;
        }

        public void DeleteBook(int id)
        {
            var book = this.Context.Books.Find(id);
            this.Context.Books.Remove(book);
            this.Context.SaveChanges();
        }

        public AboutBookViewModel GetAboutBookVmById(int id)
        {
            var book = this.Context.Books.Find(id);
            AboutBookViewModel vm = Mapper.Map<AboutBookViewModel>(book);

            return vm;
        }

        public AddBookViewModel GetAddBookVmById(int id)
        {
            Book book = this.Context.Books.Find(id);
            AddBookViewModel vm = Mapper.Map<AddBookViewModel>(book);
            var authorNames = book.Authors.Select(a => a.Name);
            vm.AuthorName = string.Join(",", authorNames);

            return vm;
        }
    }
}

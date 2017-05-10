using BookOpinions.Models.BindingModels.Book;
using BookOpinions.Models.EntityModels;
using BookOpinions.Models.ViewModels.Book;

namespace BookOpinions.Services.Contracts
{
    public interface IBookService
    {
        void AddNewBook(AddBookBindingModel bm, ApplicationUser currentUser);

        void DeleteBook(int id);

        void AddComment(CommentBindingModel bm);

        void DeleteComment(int commentId);

        AllBooksViewModel GetAllBooksBySortOrderForPage(string sortOrder, string search, int? page, int booksOnPage);

        AboutBookViewModel GetAboutBookVmById(int id, string userId);

        AddBookViewModel GetAddBookVmById(int id);
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookOpinions.Controllers;
using TestStack.FluentMVCTesting;
using BookOpinions.Models.ViewModels.Book;
using BookOpinions.Models.BindingModels.Book;
using BookOpinions.Models.ViewModels.Account;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BookOpinions.Tests.Controllers
{
    /// <summary>
    /// Summary description for BookControllerTest
    /// </summary>
    [TestClass]
    public class BookControllerTests
    {
        public BookControllerTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Add_GetMethod_ShouldPass()
        {
            var controller = new BookController();
            controller.WithCallTo(c => c.Add()).ShouldRenderDefaultView();
        }

        [TestMethod]
        public void All_Default_ShouldPass()
        {
            //Arrange
            string order = "";

            //Assert, Act
            var controller = new BookController();
            controller.WithCallTo(c => c.All(order, null, null)).ShouldRenderDefaultView()
                .WithModel<AllBooksViewModel>();
        }

        [TestMethod]
        public void All_SortTitle_ShouldPass()
        {
            //Arrange
            string order = "title";

            //Assert, Act
            var controller = new BookController();
            controller.WithCallTo(c => c.All(order, null, null)).ShouldRenderDefaultView()
                .WithModel<AllBooksViewModel>();
        }

        [TestMethod]
        public void All_SortAuthor_ShouldPass()
        {
            //Arrange
            string order = "author";

            //Assert, Act
            var controller = new BookController();
            controller.WithCallTo(c => c.All(order, null, null)).ShouldRenderDefaultView()
                .WithModel<AllBooksViewModel>();
        }

        [TestMethod]
        public void All_SortOldFirst_ShouldPass()
        {
            //Arrange
            string order = "old first";

            //Assert, Act
            var controller = new BookController();
            controller.WithCallTo(c => c.All(order, null, null)).ShouldRenderDefaultView()
                .WithModel<AllBooksViewModel>();
        }

        [TestMethod]
        public void All_SortNewFirst_ShouldPass()
        {
            //Arrange
            string order = "new first";

            //Assert, Act
            var controller = new BookController();
            controller.WithCallTo(c => c.All(order, null, null)).ShouldRenderDefaultView()
                .WithModel<AllBooksViewModel>();
        }

        [TestMethod]
        public void All_SortOpinions_ShouldPass()
        {
            //Arrange
            string order = "opinions";

            //Assert, Act
            var controller = new BookController();
            controller.WithCallTo(c => c.All(order, null, null)).ShouldRenderDefaultView()
                .WithModel<AllBooksViewModel>();
        }

        [TestMethod]
        public void All_SortRating_ShouldPass()
        {
            //Arrange
            string order = "rating";

            //Assert, Act
            var controller = new BookController();
            controller.WithCallTo(c => c.All(order, null, null)).ShouldRenderDefaultView()
                .WithModel<AllBooksViewModel>();
        }

        [TestMethod]
        public void All_Search_ShouldPass()
        {
            //Arrange
            string search = "Searched book";

            //Assert, Act
            var controller = new BookController();
            controller.WithCallTo(c => c.All(null, null, search)).ShouldRenderDefaultView()
                .WithModel<AllBooksViewModel>();
        }

        [TestMethod]
        public void Add_PostMethod_ShouldRedirect()
        {
            var accountController = new AccountController();
            var result = accountController.Login(
                new LoginViewModel
                {
                    Email = "donstz@yahoo.com",
                    Password = "12qwQW!"
                },
                "") as Task<ActionResult>;

            if (result.IsCompleted)
            {
                var controller = new BookController();
                controller.WithCallTo(c => c.Add(new AddBookBindingModel()
                {
                    AuthorName = "Gancho",
                    ImageUrl = "Http://",
                    Title = "Title"
                }))
                .ShouldRedirectTo(c => c.All(null, null, null));
            }
        }
    }
}

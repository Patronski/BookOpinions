using BookOpinions.Controllers;
using BookOpinions.Models.ViewModels.Book;
using BookOpinions.Models.ViewModels.Home;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace BookOpinions.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index_ShouldPass()
        {
            var controller = new HomeController();
            controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView()
                .WithModel<IEnumerable<SimpleBookViewModel>>();
        }

        [TestMethod]
        public void Contact_ShouldPass()
        {
            var controller = new HomeController();
            controller.WithCallTo(c => c.Contact()).ShouldRenderDefaultView();
        }

        [TestMethod]
        public void UploadFile_ShouldPass()
        {
            var controller = new HomeController();
            controller.WithCallTo(c => c.UploadFile()).ShouldRenderDefaultView();
        }


        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}

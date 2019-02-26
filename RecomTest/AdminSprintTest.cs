using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecommandationApp.Controllers;

namespace RecomTest
{
    [TestClass]
    public class AdminSprintTest
    {
        [TestMethod]
        public void Index()
        {
            //Arrange
            AdminController controller = new AdminController();
            //Act
            ViewResult result = controller.Index(null) as ViewResult;

            //Assert

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create()
        {
            //Arrange
            AdminController controller = new AdminController();
            //Act
            ViewResult result = controller.Create() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }
    }
}

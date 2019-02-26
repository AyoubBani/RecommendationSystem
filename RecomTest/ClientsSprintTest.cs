using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecommandationApp.Controllers;
using RecommandationApp.Models;

namespace RecomTest
{
    [TestClass]
    public class ClientsSprintTest
    {
        //profile

        [TestMethod]
        public void Index()
        {
            //Arrange
            ProfilController controller = new ProfilController();

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateComment()
        {
            //Arrange
            OffresController controller = new OffresController();
            OffreViewModel offre = new OffreViewModel();

            //Act
            ViewResult result = controller.CreateComment(offre) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }
    }
}

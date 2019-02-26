using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecommandationApp.Controllers;
using RecommandationApp.Models;

namespace RecomTest
{
    [TestClass]
    public class RepresentantSprintTest
    {
        
        [TestMethod]
        public void Details()
        {
            //Arrange
            OffresController controller = new OffresController();

            //Act
            ViewResult result = controller.Details(10) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create()
        {
            //Arrange
            OffresController controller = new OffresController();
            Offre offre = new Offre();

            //Act
            ViewResult result = controller.Create(offre) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore.Controllers;
using MusicStore.Models;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace MusicStoreFinalTests.Test
{
    [TestClass]
    public class OrderControllerTest
    {
        [TestMethod]
        public void OrderDetailUsesDAL()
        {
            //arrange
            Fakes.FakeOrderDAL DAL = new Fakes.FakeOrderDAL();
            OrdersController controller = new OrdersController(DAL);

            //Act
            controller.Details(6);

            //Assert
            Assert.AreEqual(6, DAL.orderId);
        }

        [TestMethod]
        public void DetailReturnsErrorWithInvalidId()
        {
            //arrange
            Fakes.FakeAlbumDAL DAL = new Fakes.FakeAlbumDAL();
            AlbumsController controller = new AlbumsController(DAL);

            //Act
            ViewResult result = controller.Details(10000) as ViewResult;
            //Assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void CreateLoadsView()
        {
            OrdersController controller = new OrdersController();
            // act
            ViewResult actual = (ViewResult)controller.Create();

            // assert
            Assert.AreEqual("Create", actual.ViewName);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore.Controllers;
using MusicStore.Models;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
namespace MusicStoreFinalTests
{
    [TestClass]
    public class AlbumControllerTests
    {
        [TestMethod]
        public void DetailUsesDAL()
        {
            //arrange
            Fakes.FakeAlbumDAL DAL = new Fakes.FakeAlbumDAL();
            AlbumsController controller = new AlbumsController(DAL);

            //Act
            controller.Details(5);

            //Assert
            Assert.AreEqual(5, DAL.albumId);
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
    }
}

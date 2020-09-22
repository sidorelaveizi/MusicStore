//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using MusicStore.Domain.Abstract;
//using MusicStore.Domain.Entities;
//using MusicStore.WebUI.Controllers;
//using System.Collections.Generic;

//namespace MusicStore.UnitTests
//{
//    [TestClass]
//    public class AdminTests
//    {
//        [TestMethod]
//        public void Index_Contains_All_Albums()
//        {
//            // Arrange - create the mock repository
//            Mock<IAlbumRepository> mock = new Mock<IAlbumRepository>();
//            mock.Setup(m => m.GetAll()).Returns(new Album[] {
//          new Album {AlbumId = 1, Title = "A Copland Celebration, Vol. I", Price=8.99M},
//          new Album {AlbumId = 2, Title = "Worlds", Price=8.99M},
//          new Album {AlbumId = 3, Title="For Those About To Rock We Salute You", Price=8.99M},
//});
//            // Arrange - create a controller
//            AdminController target = new AdminController(mock.Object);
//            // Action
//            Album[] result = ((IEnumerable<Album>)target.Index().
//            ViewData.Model).ToArray();
//            // Assert
//            Assert.AreEqual(result.Length, 3);
//            Assert.AreEqual("P1", result[0].Title);
//            Assert.AreEqual("P2", result[1].Title);
//            Assert.AreEqual("P3", result[2].Title);
//        }
//    }
//}

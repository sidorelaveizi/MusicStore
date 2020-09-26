//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using MusicStore.Domain.Concrete;
//using MusicStore.Domain.Entities;

//namespace MusicStore.UnitTests
//{
//    [TestClass]
//    public class CartTests
//    {
//        [TestMethod]
//        public void Can_Add_New_Lines()
//        {
//            // Arrange - create some test products
//            Album a1 = new Album { AlbumId = 1, Title = "P1" };
//            Album a2 = new Album { AlbumId = 2, Title = "P2" };
//            // Arrange - create a new cart
//            CartRepository target = new CartRepository();
//            // Act
//            target.AddItem(a1, 1);
//            target.AddItem(a2, 1);
//            CartLine[] results = target.Lines.ToArray();
//            // Assert
//            Assert.AreEqual(results.Length, 2);
//            Assert.AreEqual(results[0].Product, p1);
//            Assert.AreEqual(results[1].Product, p2);
//        }
//    }
//}

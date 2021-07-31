using Kefisinventory.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestProject1
{
    public class UnitTest1
    {
        private ProductController controller;
        [Fact]
        public async Task MakeasaleTest()
        {
            // Arrange
            var productid = 2;
            // Act
            var result = await controller.Makeasale(productid);

            // Assert
            var viewResult = Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task MakeadisptchTest()
        {
            // Arrange
            var orderid = 2;
            var productid = 2;
            var quantity = 2;
            // Act
            var result = await controller.Makeadispatch(orderid, productid, quantity);

            // Assert
            var viewResult = Assert.IsType<NotFoundResult>(result);
        }
    }
}

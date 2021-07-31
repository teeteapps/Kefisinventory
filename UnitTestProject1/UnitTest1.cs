using DBL.Models;
using DBL.Repository;
using Kefisinventory;
using Kefisinventory.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestProject1
{
    public class UnitTest1
    {
        
        private ProductController controller;
        private ProductRepository repo = null;
        public UnitTest1()
        {
            if (repo == null)
            {
                repo = new ProductRepository(Util.GetDbConnString());
            }
        }

        [Fact]
        public void MakeasaleTest()
        {
            // Arrange
            var productid = 2;
            // Act
            var result = repo.Makeasale(productid); ;

            // Assert
            Assert.NotEmpty(result.RespMessage);
        }
        [Fact]
        public void MakeadisptchTest()
        {
            // Arrange
            var orderid = 2;
            var productid = 2;
            var quantity = 2;
            // Act
            var result =  repo.Makeadispatch(orderid, productid, quantity);

            // Assert
            Assert.NotEmpty(result.RespMessage);
        }
    }
}

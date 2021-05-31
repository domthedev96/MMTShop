using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMTShop.API.Controllers;
using MMTShop.Business.Interfaces;
using MMTShop.Models;
using Moq;

namespace MMTShop.Tests.API
{
    [TestClass]
    public class ProductControllerTests
    {
        private List<Category> _testCategoryList;
        private Category _testCategory;
        private List<Product> _testProductList;
        private Product _testProductCategory1;
        private Product _testProductCategory2;

        [TestInitialize]
        public void Init()
        {
            _testCategory =  new Category()
            {
                Id = 1,
                Name = "TEST_CATEGORY"
            };
            _testCategoryList = new List<Category>()
            {
                _testCategory
            };
            _testProductCategory1 = new Product()
            {
                IsFeatured = true,
                Sku = "TEST_SKU",
                Name = "TEST_NAME",
                Price = 200,
                CategoryId = 1,
                Description = "TEST_DESC",
                Id = 1
            };
            _testProductCategory2 = new Product()
            {
                IsFeatured = true,
                Sku = "TEST_SKU_2",
                Name = "TEST_NAME_2",
                Price = 400,
                CategoryId = 2,
                Description = "TEST_DESC_2",
                Id = 2
            };
            _testProductList = new List<Product>()
            {
                _testProductCategory1
            };
        }

        [TestMethod]
        public async Task GetFeaturedProductsAsync_ReturnFeaturedProductsSuccessfullyAsync()
        {
            var productServiceMock = new Mock<IProductService>();
            productServiceMock.Setup(x => x.GetFeaturedProductsAsync()).Returns(Task.FromResult(_testProductList));

            var controller = new ProductController(new Mock<ICategoryService>().Object, productServiceMock.Object);
            var response = await controller.GetFeaturedProductsAsync();
            var result = (OkObjectResult)response;
            var featuredProducts = (List<Product>)result.Value;

            Assert.AreEqual(_testProductList, featuredProducts);
        }

        [TestMethod]
        public async Task GetAllProductCategoriesAsync_ReturnCategoriesSuccessfullyAsync()
        {
            var categoryServiceMock = new Mock<ICategoryService>();
            categoryServiceMock.Setup(x => x.GetAllCategoriesAsync()).Returns(Task.FromResult(_testCategoryList));

            var controller = new ProductController(categoryServiceMock.Object, new Mock<IProductService>().Object);
            var response = await controller.GetAllProductCategoriesAsync();
            var result = (OkObjectResult)response;
            var categoryList = (List<Category>)result.Value;
            
            Assert.AreEqual(_testCategoryList, categoryList);
        }

        [TestMethod]
        public async Task GetProductsByCategoryAsync_ReturnProductsInCategorySuccessfullyAsync()
        {
            var productServiceMock = new Mock<IProductService>();
            productServiceMock.Setup(x => x.GetProductsByCategoryIdAsync(2)).Returns(Task.FromResult(new List<Product>()
            {
                _testProductCategory2
            }));

            var controller = new ProductController(new Mock<ICategoryService>().Object, productServiceMock.Object);
            var response = await controller.GetProductsByCategoryAsync(2);
            var result = (OkObjectResult)response;
            var productsInCategory = (List<Product>)result.Value;

            Assert.AreEqual(_testProductCategory2, productsInCategory.First());
        }

    }
}

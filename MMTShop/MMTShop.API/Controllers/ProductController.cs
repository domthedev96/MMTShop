using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMTShop.Business.Interfaces;

namespace MMTShop.API.Controllers
{
    [Route("api/v1/products")]
    public class ProductController : V1BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public ProductController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        [Route("featured")]
        public async Task<IActionResult> GetFeaturedProductsAsync()
        {
            try
            {
                //Make a call to the database to retrieve all products with IsFeature flag set to true
                var featuredProducts = await _productService.GetFeaturedProductsAsync();
                return Ok(featuredProducts);
            }
            catch (Exception e)
            {
                //If there was a developer exception logging app, here is where I would insert the logging call
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("categories")]
        public async Task<IActionResult> GetAllProductCategoriesAsync()
        {
            try
            {
                //Make a call to the database to retrieve all categories
                var categories = await _categoryService.GetAllCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception e)
            {
                //If there was a developer exception logging app, here is where I would insert the logging call
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("category/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategoryAsync(int categoryId)
        {
            try
            {
                //Make a call to database to retrieve all products with the category id passed in
                var productsInCategory = await _productService.GetProductsByCategoryIdAsync(categoryId);
                return Ok(productsInCategory);
            }
            catch (Exception e)
            {
                //If there was a developer exception logging app, here is where I would insert the logging call
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
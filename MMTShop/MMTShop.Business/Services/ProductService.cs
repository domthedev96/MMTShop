using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MMTShop.Business.Components;
using MMTShop.Business.Interfaces;
using MMTShop.Common.CustomExceptions;
using MMTShop.Common.ExtensionMethods;
using MMTShop.Models;

namespace MMTShop.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        private readonly ISqlCommandManager _commandManager;

        public ProductService(IDbConnectionFactory dbConnectionFactory, ISqlCommandManager commandManager)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _commandManager = commandManager;
        }

        public async Task<List<Product>> GetFeaturedProductsAsync()
        {
            try
            {
                var featuredProducts = new List<Product>();

                using (var connection = _dbConnectionFactory.Connect())
                {
                    _commandManager.BuildStoredProc(SqlConstants.GET_ALL_FEATURED_PRODCUTS_STORED_PROC, connection);
                    var data = await _commandManager.ExecuteQueryAsync();

                    foreach (DataRow row in data.Rows)
                    {
                        featuredProducts.Add(new Product
                        {
                            Id = row.GetSafeInt("Id"),
                            CategoryId = row.GetSafeInt("CategoryId"),
                            Sku = row.GetSafeString("SKU"),
                            Name = row.GetSafeString("Name"),
                            Description = row.GetSafeString("Description"),
                            Price = row.GetSafeDecimal("Price"),
                            IsFeatured = row.GetSafeBool("IsFeatured")
                        });
                    }
                }

                return featuredProducts;
            }
            catch (Exception e)
            {
                throw new ProductServiceException("Error occurred while retrieving featured products from database", e);
            }
        }

        public async Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            try
            {
                var productsInCategory = new List<Product>();

                using (var connection = _dbConnectionFactory.Connect())
                {
                    _commandManager.BuildStoredProc(SqlConstants.GET_ALL_PRODUCTS_BY_CATEGORY_STORED_PROC, connection);
                    _commandManager.AddParameter("@categoryId", SqlDbType.Int, categoryId);
                    var data = await _commandManager.ExecuteQueryAsync();

                    foreach (DataRow row in data.Rows)
                    {
                        productsInCategory.Add(new Product
                        {
                            Id = row.GetSafeInt("Id"),
                            CategoryId = row.GetSafeInt("CategoryId"),
                            Sku = row.GetSafeString("SKU"),
                            Name = row.GetSafeString("Name"),
                            Description = row.GetSafeString("Description"),
                            Price = row.GetSafeDecimal("Price"),
                            IsFeatured = row.GetSafeBool("IsFeatured")
                        });
                    }
                }

                return productsInCategory;
            }
            catch (Exception e)
            {
                throw new ProductServiceException($"Error occurred while retrieving products with a category id of {categoryId} from database", e);
            }
        }
    }
}

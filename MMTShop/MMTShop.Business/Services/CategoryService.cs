using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MMTShop.Business.Components;
using MMTShop.Business.Interfaces;
using MMTShop.Common.CustomExceptions;
using MMTShop.Models;
using MMTShop.Common.ExtensionMethods;

namespace MMTShop.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        private readonly ISqlCommandManager _commandManager;

        public CategoryService(IDbConnectionFactory dbConnectionFactory, ISqlCommandManager commandManager)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _commandManager = commandManager;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            try
            {
                var categories = new List<Category>();

                using (var connection = _dbConnectionFactory.Connect())
                {
                    _commandManager.BuildStoredProc(SqlConstants.GET_ALL_CATEGORIES_STORED_PROC, connection);
                    var data = await _commandManager.ExecuteQueryAsync();
                   
                    foreach (DataRow row in data.Rows)
                    {
                        categories.Add(new Category
                        {
                            Id = row.GetSafeInt("Id"),
                            Name = row.GetSafeString("Name")
                        });
                    }
                }

                return categories;
            }
            catch (Exception e)
            {
                throw new CategoryServiceException("Error occurred while retrieving all categories from database", e);
            }
        }
    }
}

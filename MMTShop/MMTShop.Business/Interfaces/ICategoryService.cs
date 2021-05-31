using System.Collections.Generic;
using System.Threading.Tasks;
using MMTShop.Models;

namespace MMTShop.Business.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategoriesAsync();
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using MMTShop.Models;

namespace MMTShop.Business.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetFeaturedProductsAsync();
        Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId);
    }
}

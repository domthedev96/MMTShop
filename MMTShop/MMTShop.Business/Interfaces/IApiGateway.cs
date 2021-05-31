using System.Threading.Tasks;

namespace MMTShop.Business.Interfaces
{
    public interface IApiGateway
    {
        Task<T> GetAsync<T>(string url);
    }
}

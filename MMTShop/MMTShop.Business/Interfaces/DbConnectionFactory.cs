using System.Data;

namespace MMTShop.Business.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection Connect();
    }
}

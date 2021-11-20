using System.Threading.Tasks;

namespace Comercio.Domain.Interfaces
{
    public interface IRepositoryBase
    {
        Task<dynamic> Query(string sql = null, object obj = null);
        Task<dynamic> GetAll(string sql);
        Task<dynamic> GetById(string sql, object obj);
        Task<dynamic> Add(string sql, object obj);
        Task<dynamic> Update(string sql, object obj);
        Task<bool> Delete(string sql, object obj);
    }
}

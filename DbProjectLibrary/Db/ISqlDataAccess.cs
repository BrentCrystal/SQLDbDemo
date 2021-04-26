using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbProjectLibrary.Db
{
    public interface ISqlDataAccess
    {
        Task<List<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionStringName);
        
        Task<int> SaveDataAsync<T>(string storedProcedure, T parameters, string connectionStringName);
    }
}
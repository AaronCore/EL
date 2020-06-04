using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EL.Application
{
    public interface IDataBaseService
    {
        Task<List<string>> GetDataBases();
        Task<List<DataBaseTableDto>> GetDataBaseTables(string dataBase);
        Task<bool> CreateTableEntity(string dataBaseName, string[] tables, string namespaceName, string savePath);
    }
}

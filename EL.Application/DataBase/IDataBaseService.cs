using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EL.Application
{
    public interface IDataBaseService
    {
        Task<List<string>> GetDataBases();
        Task<List<string>> GetDataBaseTables(string dataBase);
    }
}

using EL.DapperCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.Application
{
    public class DataBaseService : IDataBaseService
    {
        private readonly DapperRepository _dapperRepository = new DapperRepository();

        public async Task<List<string>> GetDataBases()
        {
            var sql = "show databases";
            var result = await _dapperRepository.QueryAsync<string>(sql);
            return result.OrderBy(p => p).ToList();
        }

        public async Task<List<string>> GetDataBaseTables(string dataBase)
        {
            var sql = string.Format("show tables from {0}", dataBase);
            var result = await _dapperRepository.QueryAsync<string>(sql);
            return result.OrderBy(p => p).ToList();
        }
    }
}

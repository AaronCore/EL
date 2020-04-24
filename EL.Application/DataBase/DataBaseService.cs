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

        public async Task<List<DataBaseTableDto>> GetDataBaseTables(string dataBase)
        {
            var sql = string.Format("SELECT TABLE_SCHEMA,TABLE_NAME,TABLE_COMMENT,TABLE_ROWS,CREATE_TIME,UPDATE_TIME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='{0}';", dataBase);
            var queryResult = await _dapperRepository.QueryAsync<DataBaseTableDto>(sql);

            var result = queryResult.OrderBy(p => p.Table_Name).Select(p => new DataBaseTableDto
            {
                Table_Schema = p.Table_Schema,
                Table_Name = p.Table_Name,
                Table_Comment = p.Table_Comment,
                Table_Rows = GetTableByRows(dataBase, p.Table_Name),
                Create_Time = p.Create_Time,
                Update_Time = p.Update_Time
            }).ToList();
            return result;
        }

        public int GetTableByRows(string dataBase, string table)
        {
            try
            {
                string sql = string.Format("SELECT COUNT(*) FROM {0}.{1}", dataBase, table);
                var result = _dapperRepository.ExecuteScalar<int>(sql);
                return result;
            }
            catch (Exception)
            {
                return 0;
            }
            
        }
    }
}

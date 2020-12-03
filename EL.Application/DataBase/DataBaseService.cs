using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL.Common;

namespace EL.Application
{
    public class DataBaseService : IDataBaseService
    {
        private static readonly DapperHelper _dapperHelper = new DapperHelper();

        public async Task<List<string>> GetDataBases()
        {
            var sql = "SELECT TABLE_SCHEMA FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' GROUP BY TABLE_SCHEMA ORDER BY TABLE_SCHEMA";
            var result = await _dapperHelper.QueryAsync<string>(sql);
            return result.OrderBy(p => p).ToList();
        }

        public async Task<List<DataBaseTableDto>> GetDataBaseTables(string dataBase)
        {
            var sql = string.Format("SELECT TABLE_SCHEMA,TABLE_NAME,TABLE_COMMENT,TABLE_ROWS,CREATE_TIME,UPDATE_TIME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='{0}';", dataBase);
            var queryResult = await _dapperHelper.QueryAsync<DataBaseTableDto>(sql);

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
                var result = _dapperHelper.ExecuteScalar<int>(sql);
                return result;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public async Task<bool> CreateTableEntity(string dataBaseName, string[] tables, string namespaceName, string savePath)
        {
            foreach (var item in tables)
            {
                var sql = string.Format(@"select 
                                                COLUMN_NAME as ColumnName,
                                                DATA_TYPE as DataType,
                                                case COLUMN_KEY when 'pri' then COLUMN_NAME else '' end as Pk , 
	                                            replace(replace(substring(COLUMN_TYPE, locate('(', COLUMN_KEY)), '(', ''), ')', '') as FieldLength , 
	                                            case IS_NULLABLE when 'no' then 'n' else 'y' end as IsNullable, 
	                                            ifnull(COLUMN_DEFAULT, '') as ColumnDefault, 
	                                            COLUMN_COMMENT as Remark 
                                           from information_schema.columns 
                                           where table_schema = '{0}' and table_name = '{1}'", dataBaseName, item);
                var result = await _dapperHelper.QueryAsync<TableDetails>(sql);
            }
            return false;
        }
    }
}

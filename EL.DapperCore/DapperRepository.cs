using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Dapper;
using EL.Common;

namespace EL.DapperCore
{
    public class DapperRepository
    {
        private string _connectionString;
        public DapperRepository()
        {
            _connectionString = new JsonConfigManager().GetValue<string>("ELConnection");
        }

        public IDbConnection Connection()
        {
            return new MySqlConnection(_connectionString);
        }

        #region 添加、修改

        public virtual bool Execute(string sql, object param = null)
        {
            using (var conn = Connection())
            {
                return conn.Execute(sql, param) > 0;
            }
        }
        public virtual async Task<bool> ExecuteAsync(string sql, object param = null)
        {
            using (var conn = Connection())
            {
                return await conn.ExecuteAsync(sql, param) > 0;
            }
        }

        #endregion

        #region 返回单个查询

        public virtual T ExecuteScalar<T>(string sql, object param = null)
        {
            using (var conn = Connection())
            {
                return conn.ExecuteScalar<T>(sql, param);
            }
        }
        public virtual async Task<T> ExecuteScalarAsync<T>(string sql, object param = null)
        {
            using (var conn = Connection())
            {
                return await conn.ExecuteScalarAsync<T>(sql, param);
            }
        }

        #endregion

        #region List查询

        public virtual IEnumerable<T> Query<T>(string sql, object param = null)
        {
            using (var conn = Connection())
            {
                return conn.Query<T>(sql, param);
            }
        }
        public virtual async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
        {
            using (var conn = Connection())
            {
                return await conn.QueryAsync<T>(sql, param);
            }
        }

        #endregion

        #region Model查询

        public virtual T QueryFirst<T>(string sql, object param = null)
        {
            using (var conn = Connection())
            {
                return conn.QueryFirstOrDefault<T>(sql, param);
            }
        }
        public virtual async Task<T> QueryFirstAsync<T>(string sql, object param = null)
        {
            using (var conn = Connection())
            {
                return await conn.QueryFirstOrDefaultAsync<T>(sql, param);
            }
        }

        #endregion
    }
}

using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using EL.Entity;
using EL.Repository;
using EL.DapperCore;
using EL.Common;

namespace EL.Application
{
    public class LogService : ILogService
    {
        private readonly IBaseRepository<LogEntity> _logRepository;
        private readonly DapperRepository _dapperRepository;
        public LogService()
        {
            _dapperRepository = new DapperRepository();
        }
        public LogService(IBaseRepository<LogEntity> logRepository)
        {
            _logRepository = logRepository;
        }

        public List<LogEntity> GetLogPageList(int pageIndex, int pageSize, out int total, string searchKey)
        {
            Expression<Func<LogEntity, bool>> where = e => true;
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                where = where.And(p => p.Message.Contains(searchKey));
            }
            var logList = _logRepository.LoadEntityEnumerable(where, p => p.CreateTime, "desc", pageIndex, pageSize).ToList();
            total = _logRepository.GetEntitiesCount(where);
            return logList;
        }
        public async Task SaveException(Exception ex)
        {
            var entity = new LogEntity
            {
                Message = ex.Message,
                StackTrace = !string.IsNullOrWhiteSpace(ex.StackTrace) ? ex.StackTrace : null,
                Exception = ex.ToString(),
                CreateTime = DateTime.Now
            };
            string sql = "insert into logs(message,exception,stacktrace,createtime) values(@message,@exception,@stacktrace,@createtime)";
            var param = new
            {
                message = entity.Message,
                exception = entity.Exception,
                stacktrace = entity.StackTrace,
                createtime = entity.CreateTime
            };
            await _dapperRepository.ExecuteAsync(sql, param);
        }
        public async Task<bool> Deletes(int[] ids)
        {
            var idArrar = ids.Distinct().ToArray();
            return await _logRepository.DelEntityAsync(p => idArrar.Contains(p.Id)) > 0;
        }
        public async Task<LogEntity> GetLog(int id)
        {
            return await _logRepository.WhereLoadEntityAsync(p => p.Id == id);
        }
    }
}

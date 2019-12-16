using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EL.Entity;
using EL.Repository;
using EL.DapperCore;

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
        public void SaveException(Exception ex)
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
            _dapperRepository.Execute(sql, param);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EL.Entity;
using EL.Repository;

namespace EL.Application
{
    public class LogService : ILogService
    {
        private readonly IBaseRepository<LogEntity> _logRepository;
        public LogService(IBaseRepository<LogEntity> logRepository)
        {
            _logRepository = logRepository;
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
            await _logRepository.AddEntityAsync(entity);
            await _logRepository.CommitAsync();
        }
    }
}

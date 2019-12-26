using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EL.Entity;

namespace EL.Application
{
    public interface ILogService
    {
        Task SaveException(Exception ex);
        Task<bool> Deletes(int[] ids);
        Task<LogEntity> GetLog(int id);
        List<LogEntity> GetLogPageList(int pageIndex, int pageSize, out int total, string searchKey);
    }
}

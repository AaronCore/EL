﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EL.Entity;

namespace EL.Application
{
    public interface ILogService
    {
        void SaveException(Exception ex);
        bool Deletes(int[] ids);
        LogEntity GetLog(int id);
        List<LogEntity> GetLogList(int pageIndex, int pageSize, out int total, string searchKey);
    }
}

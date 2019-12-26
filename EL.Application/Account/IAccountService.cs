using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using EL.Entity;

namespace EL.Application
{
    public interface IAccountService
    {
        Task<bool> Deletes(int[] ids);
        Task Enableds(int[] ids);
        Task<AccountEntity> GetAccount(int id);
        List<AccountEntity> GetAccountPageList(int pageIndex, int pageSize, out int total, string searchKey);
        Task Submit(Account_DTO entity);
    }
}

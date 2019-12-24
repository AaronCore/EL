using System;
using System.Collections.Generic;
using System.Text;
using EL.Entity;

namespace EL.Application
{
    public interface IAccountService
    {
        bool Deletes(int[] ids);
        void Enableds(int[] ids);
        AccountEntity GetAccount(int id);
        List<AccountEntity> GetAccountPageList(int pageIndex, int pageSize, out int total, string searchKey);
        void Submit(Account_DTO entity);
    }
}

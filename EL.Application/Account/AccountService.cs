using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using EL.Repository;
using EL.Common;
using EL.Entity;
using Dapper;
using EL.DapperCore;

namespace EL.Application
{
    public class AccountService : IAccountService
    {
        private readonly IBaseRepository<AccountEntity> _accountRepository;
        private readonly IBaseRepository<RoleEntity> _roleRepository;
        private readonly DapperRepository _dapperRepository = new DapperRepository();

        public AccountService(IBaseRepository<AccountEntity> accountRepository, IBaseRepository<RoleEntity> roleRepository)
        {
            _accountRepository = accountRepository;
            _roleRepository = roleRepository;
        }

        public async Task Submit(AccountEntity entity)
        {
            if (entity.Id > 0)
            {
                var model = await _accountRepository.WhereLoadEntityAsync(p => p.Id == entity.Id);
                model.Sort = entity.Sort;
                model.Enabled = entity.Enabled;
                model.EditTime = DateTime.Now;
                _accountRepository.UpdateEntity(model);
            }
            else
            {
                entity.Password = Md5Helper.GetMD5_32(entity.Password);
                entity.CreateTime = DateTime.Now;
                await _accountRepository.AddEntityAsync(entity);
            }
            await _accountRepository.CommitAsync();
        }
        public List<AccountDto> GetAccountPageList(int pageIndex, int pageSize, out int total, string searchKey)
        {
            --pageIndex;
            var parameters = new DynamicParameters();

            StringBuilder sb = new StringBuilder();
            sb.Append(@"select a.id,a.account,a.roleId,b.Name rolename,a.sort,a.enabled,a.editTime,a.editor,a.createTime,a.creater from sys_accounts a,sys_roles b where a.roleId=b.id and 1=1 ");
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                sb.Append(" a.account like concat('%',@searchKey,'%') or b.name like concat('%',@searchKey,'%')");
                parameters.Add("@searchKey", searchKey);
            }

            total = _dapperRepository.Query<AccountDto>(sb.ToString(), parameters).Count();

            sb.Append(" order by a.id desc limit @pageIndex,@pageSize");
            parameters.Add("@pageIndex", pageIndex * pageSize);
            parameters.Add("@pageSize", pageSize);

            var roleList = _dapperRepository.Query<AccountDto>(sb.ToString(), parameters).ToList();
            return roleList;
        }
        public async Task<AccountEntity> GetAccount(int id)
        {
            return await _accountRepository.WhereLoadEntityAsync(p => p.Id == id);
        }
        public async Task<bool> Deletes(int[] ids)
        {
            var idArrar = ids.Distinct().ToArray();
            return await _accountRepository.DelEntityAsync(p => idArrar.Contains(p.Id)) > 0;
        }
        public async Task Enableds(int[] ids)
        {
            var idArrar = ids.Distinct().ToArray();
            var list = _accountRepository.WhereLoadEntityEnumerable(p => idArrar.Contains(p.Id)).ToList();
            foreach (var item in list)
            {
                item.Enabled = item.Enabled ? false : true;
                _accountRepository.UpdateEntity(item);
                await _accountRepository.CommitAsync();
            }
        }
    }
}

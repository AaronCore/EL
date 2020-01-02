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
using MySql.Data.MySqlClient;

namespace EL.Application
{
    public class AccountService : IAccountService
    {
        private readonly IBaseRepository<AccountEntity> _accountRepository;
        private readonly IBaseRepository<MenuEntity> _menuRepository;
        private readonly DapperRepository _dapperRepository = new DapperRepository();
        public AccountService(IBaseRepository<AccountEntity> accountRepository, IBaseRepository<MenuEntity> menuRepository)
        {
            _accountRepository = accountRepository;
            _menuRepository = menuRepository;
        }

        public List<AccountMenDto> GetAccountMenu(int userId)
        {
            var account = _accountRepository.WhereLoadEntity(p => p.Id == userId);
            var sql = string.Format("select b.* from sys_role_menus a left join sys_menus b on a.MenuId=b.Id where a.RoleId={0}", account.RoleId);
            var menus = _menuRepository.GetModeListlBySql(sql);
            var result = MenuTree(menus, 0);
            return result;
        }
        private List<AccountMenDto> MenuTree(List<MenuEntity> data, int parentId)
        {
            var treeList = new List<AccountMenDto>();
            var list = data.Where(p => p.ParentId == parentId).OrderBy(p => p.Sort).ToList();
            foreach (var item in list)
            {
                bool hasChildren = data.Count(p => p.ParentId == item.Id) > 0;
                var model = new AccountMenDto
                {
                    Title = item.Name,
                    Key = item.Code,
                    Show = true,
                    Url = item.Path,
                    Icon = item.Icon,
                    Children = hasChildren ? MenuTree(data, item.Id) : null
                };
                treeList.Add(model);
            }
            return treeList;
        }
        public async Task<AccountEntity> Login(string account, string password)
        {
            return await _accountRepository.WhereLoadEntityAsync(p => p.Account == account && p.Password == password);
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
            return await _accountRepository.DelEntityAsync(p => p.Account != "admin" && idArrar.Contains(p.Id)) > 0;
        }
        public async Task Enableds(int[] ids)
        {
            var idArrar = ids.Distinct().ToArray();
            var list = _accountRepository.WhereLoadEntityEnumerable(p => p.Account != "admin" && idArrar.Contains(p.Id)).ToList();
            foreach (var item in list)
            {
                item.Enabled = item.Enabled ? false : true;
                _accountRepository.UpdateEntity(item);
                await _accountRepository.CommitAsync();
            }
        }
    }
}

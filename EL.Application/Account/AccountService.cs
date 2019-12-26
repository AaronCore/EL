using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using EL.Repository;
using EL.Common;
using EL.Entity;

namespace EL.Application
{
    public class AccountService : IAccountService
    {
        private readonly IBaseRepository<AccountEntity> _accountRepository;
        private readonly IBaseRepository<RoleEntity> _roleRepository;
        public AccountService(IBaseRepository<AccountEntity> accountRepository, IBaseRepository<RoleEntity> roleRepository)
        {
            _accountRepository = accountRepository;
            _roleRepository = roleRepository;
        }

        public async Task Submit(Account_DTO entity)
        {
            object roleEntity = null;
            if (entity.RoleId > 0)
            {
                roleEntity = await _roleRepository.WhereLoadEntityAsync(p => p.Id == entity.RoleId);
            }
            if (entity.Id > 0)
            {
                var model = await _accountRepository.WhereLoadEntityAsync(p => p.Id == entity.Id);
                model.Name = entity.Name;
                model.Sort = entity.Sort;
                model.Enabled = entity.Enabled;
                model.EditTime = DateTime.Now;
                if (entity.RoleId > 0)
                {
                    model.Role = (RoleEntity)roleEntity;
                }
                _accountRepository.UpdateEntity(model);
            }
            else
            {
                var model = entity.MapTo<AccountEntity>();
                model.Password = Md5Helper.GetMD5_32(entity.Password);
                model.CreateTime = DateTime.Now;
                if (entity.RoleId > 0)
                {
                    model.Role = (RoleEntity)roleEntity;
                }
                await _accountRepository.AddEntityAsync(model);
            }
            await _accountRepository.CommitAsync();
        }
        public List<AccountEntity> GetAccountPageList(int pageIndex, int pageSize, out int total, string searchKey)
        {
            Expression<Func<AccountEntity, bool>> where = e => true;
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                where = where.And(p => p.Name.Contains(searchKey) || p.Role.Name.Contains(searchKey));
            }
            var roleList = _accountRepository.LoadEntityEnumerable(where, p => p.CreateTime, "desc", pageIndex, pageSize).ToList();
            total = _accountRepository.GetEntitiesCount(where);
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

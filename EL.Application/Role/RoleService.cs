using System;
using System.Collections.Generic;
using System.Text;
using EL.Repository;
using EL.Common;
using EL.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Collections;
using System.Threading.Tasks;

namespace EL.Application
{
    public class RoleService : IRoleService
    {
        private readonly IBaseRepository<RoleEntity> _roleRepository;
        private readonly IBaseRepository<MenuEntity> _menuRepository;
        public RoleService(IBaseRepository<RoleEntity> roleRepository, IBaseRepository<MenuEntity> menuRepository)
        {
            _roleRepository = roleRepository;
            _menuRepository = menuRepository;
        }

        public async Task<List<RoleEntity>> GetRoleList()
        {
            return await _roleRepository.WhereLoadEntityEnumerableAsync(p => p.Enabled);
        }
        public async Task RoleMenuSubmit(int roleId, int[] menuIds)
        {
            var roleModel = await _roleRepository.WhereLoadEntityAsync(p => p.Id == roleId);
            var menuList = await _menuRepository.WhereLoadEntityEnumerableAsync(p => menuIds.Contains(p.Id));
            roleModel.RoleMenus.Clear();
            foreach (var item in menuList)
            {
                var model = new RoleMenuEntity()
                {
                    RoleId = roleId,
                    Role = roleModel,
                    MenuId = item.Id,
                    Menu = item
                };
                roleModel.RoleMenus.Add(model);
            }
            _roleRepository.UpdateEntity(roleModel);
            await _roleRepository.CommitAsync();
        }
        public async Task<RoleEntity> GetRole(int id)
        {
            return await _roleRepository.WhereLoadEntityAsync(p => p.Id == id);
        }
        public async Task Submit(RoleEntity entity)
        {
            if (entity.Id > 0)
            {
                var model = await _roleRepository.WhereLoadEntityAsync(p => p.Id == entity.Id);
                model.Name = entity.Name;
                model.Sort = entity.Sort;
                model.Enabled = entity.Enabled;
                model.EditTime = DateTime.Now;
                _roleRepository.UpdateEntity(model);
            }
            else
            {
                entity.CreateTime = DateTime.Now;
                _roleRepository.AddEntity(entity);
            }
            await _roleRepository.CommitAsync();
        }
        public List<RoleEntity> GetRolePageList(int pageIndex, int pageSize, out int total, string searchKey)
        {
            Expression<Func<RoleEntity, bool>> where = e => true;
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                where = where.And(p => p.Name.Contains(searchKey));
            }
            var roleList = _roleRepository.LoadEntityEnumerable(where, p => p.CreateTime, "desc", pageIndex, pageSize).ToList();
            total = _roleRepository.GetEntitiesCount(where);
            return roleList;
        }
        public async Task<bool> Deletes(int[] ids)
        {
            var idArrar = ids.Distinct().ToArray();
            return await _roleRepository.DelEntityAsync(p => idArrar.Contains(p.Id)) > 0;
        }
        public async Task Enableds(int[] ids)
        {
            var idArrar = ids.Distinct().ToArray();
            var list = await _roleRepository.WhereLoadEntityEnumerableAsync(p => idArrar.Contains(p.Id));
            foreach (var item in list)
            {
                item.Enabled = item.Enabled ? false : true;
                _roleRepository.UpdateEntity(item);
                await _roleRepository.CommitAsync();
            }
        }
    }
}

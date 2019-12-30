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
        private readonly IBaseRepository<RoleMenuEntity> _roleMenuRepository;
        public RoleService(IBaseRepository<RoleEntity> roleRepository, IBaseRepository<MenuEntity> menuRepository, IBaseRepository<RoleMenuEntity> roleMenuRepository)
        {
            _roleRepository = roleRepository;
            _menuRepository = menuRepository;
            _roleMenuRepository = roleMenuRepository;
        }

        public async Task<List<RoleMenuEntity>> GetRoleMenuList(int roleId)
        {
            return await _roleMenuRepository.WhereLoadEntityEnumerableAsync(p => p.RoleId == roleId);
        }
        public async Task<List<RoleEntity>> GetRoleList()
        {
            return await _roleRepository.WhereLoadEntityEnumerableAsync(p => p.Enabled);
        }
        public async Task RoleMenuSubmit(int roleId, int[] menuIds)
        {
            await _roleMenuRepository.DelEntityAsync(p => p.RoleId == roleId);
            var listModel = menuIds.Select(p => new RoleMenuEntity { RoleId = roleId, MenuId = p }).ToList();
            await _roleMenuRepository.AddRangeAsync(listModel);
            await _roleMenuRepository.CommitAsync();
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
                await _roleRepository.AddEntityAsync(entity);
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

using System;
using System.Collections.Generic;
using System.Text;
using EL.Repository;
using EL.Common;
using EL.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Collections;

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

        public List<RoleEntity> GetRoleList()
        {
            return _roleRepository.WhereLoadEntityEnumerable(p => p.Enabled).ToList();
        }
        public void RoleMenuSubmit(int roleId, int[] menuIds)
        {
            var roleModel = _roleRepository.WhereLoadEntity(p => p.Id == roleId);
            var menuList = _menuRepository.WhereLoadEntityEnumerable(p => menuIds.Contains(p.Id));
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
            _roleRepository.Commit();
        }
        public RoleEntity GetRole(int id)
        {
            return _roleRepository.WhereLoadEntity(p => p.Id == id);
        }
        public void Submit(RoleEntity entity)
        {
            if (entity.Id > 0)
            {
                var model = _roleRepository.WhereLoadEntity(p => p.Id == entity.Id);
                model.Name = entity.Name;
                model.Sort = entity.Sort;
                model.EditTime = DateTime.Now;
                _roleRepository.UpdateEntity(model);
                _roleRepository.Commit();
            }
            else
            {
                entity.CreateTime = DateTime.Now;
                _roleRepository.AddEntity(entity);
                _roleRepository.Commit();
            }
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
        public bool Deletes(int[] ids)
        {
            var idArrar = ids.Distinct().ToArray();
            return _roleRepository.DelEntity(p => idArrar.Contains(p.Id)) > 0;
        }
        public void Enableds(int[] ids)
        {
            var idArrar = ids.Distinct().ToArray();
            var list = _roleRepository.WhereLoadEntityEnumerable(p => idArrar.Contains(p.Id)).ToList();
            foreach (var item in list)
            {
                item.Enabled = item.Enabled ? false : true;
                _roleRepository.UpdateEntity(item);
                _roleRepository.Commit();
            }
        }
    }
}

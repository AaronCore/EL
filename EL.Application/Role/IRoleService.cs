using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EL.Entity;

namespace EL.Application
{
    public interface IRoleService
    {
        Task<bool> Deletes(int[] ids);
        Task Enableds(int[] ids);
        List<RoleEntity> GetRolePageList(int pageIndex, int pageSize, out int total, string searchKey);
        Task Submit(RoleEntity entity);
        Task<RoleEntity> GetRole(int id);
        Task RoleMenuSubmit(int roleId, int[] menuIds);
        Task<List<RoleEntity>> GetRoleList();
        Task<List<RoleMenuEntity>> GetRoleMenuList(int roleId);
    }
}

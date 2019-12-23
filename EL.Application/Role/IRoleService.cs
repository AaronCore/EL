using System;
using System.Collections.Generic;
using System.Text;
using EL.Entity;

namespace EL.Application
{
    public interface IRoleService
    {
        bool Deletes(int[] ids);
        void Enableds(int[] ids);
        List<RoleEntity> GetRoleList(int pageIndex, int pageSize, out int total, string searchKey);
        void Submit(RoleEntity entity);
        RoleEntity GetRole(int id);
        void RoleMenuSubmit(int roleId, int[] menuIds);
    }
}

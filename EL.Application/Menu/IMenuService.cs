using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using EL.Entity;

namespace EL.Application
{
    public interface IMenuService
    {
        Task<List<MenuTree_DTO>> GetMenuTreeList();
        Task<List<MenuList_DTO>> GetMenuList();
        Task<List<MenuList_DTO>> GetSelectMenuList();
        Task<MenuEntity> GetMenu(int id);
        Task Submit(MenuEntity menuDto);
        Task<bool> Deletes(int[] ids);
        Task Enableds(int[] ids);
    }
}

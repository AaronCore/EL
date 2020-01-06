using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using EL.Entity;

namespace EL.Application
{
    public interface IMenuService
    {
        Task<List<MenuTreeDto>> GetMenuTreeList();
        Task<List<MenuListDto>> GetMenuList();
        Task<List<MenuListDto>> GetSelectMenuList();
        Task<MenuEntity> GetMenu(int id);
        Task<int> Submit(MenuEntity menuDto);
        Task<bool> Deletes(int[] ids);
        Task Enableds(int[] ids);
    }
}

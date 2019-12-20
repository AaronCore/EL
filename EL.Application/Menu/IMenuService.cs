using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using EL.Entity;

namespace EL.Application
{
    public interface IMenuService
    {
        List<MenuTree_DTO> GetMenuTreeList();
        List<MenuList_DTO> GetMenuList();
        MenuEntity GetMenu(int id);
        void Submit(Menu_DTO menuDto);
        bool Deletes(int[] ids);
        void Enableds(int[] ids);
    }
}

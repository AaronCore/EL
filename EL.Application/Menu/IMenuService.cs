using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using EL.Entity;

namespace EL.Application
{
    public interface IMenuService
    {
        void Add(MenuEntity entity);
        MenuEntity GetMenu(int id);
        List<Menu_DTO> GetMenuTreeList();
    }
}

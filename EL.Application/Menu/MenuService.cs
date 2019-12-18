using System;
using System.Collections.Generic;
using System.Text;
using EL.Entity;
using EL.Repository;

namespace EL.Application.Menu
{
    public class MenuService : IMenuService
    {
        private readonly IBaseRepository<MenuEntity> _menuRepository;
        public MenuService(IBaseRepository<MenuEntity> menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public MenuEntity GetMenu(int id)
        {
            return _menuRepository.WhereLoadEntity(p => p.Id == id);
        }
    }
}

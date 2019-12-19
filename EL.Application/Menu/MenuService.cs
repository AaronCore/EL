using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using EL.Common;
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
        public void Add(MenuEntity entity)
        {
            _menuRepository.AddEntity(entity);
            _menuRepository.Commit();
        }
        public List<Menu_DTO> GetMenuTreeList()
        {
            var resultList = new List<Menu_DTO>();

            return resultList;
        }
    }
}

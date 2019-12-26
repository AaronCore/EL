using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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
        public async Task<List<MenuTree_DTO>> GetMenuTreeList()
        {
            var resultList = new List<MenuTree_DTO>();
            var oneList = await _menuRepository.WhereLoadEntityEnumerableAsync(p => p.ParentMenu == null);
            foreach (var oneItem in oneList)
            {
                var oneModel = oneItem.MapTo<MenuTree_DTO>();
                var towList = oneItem.Menus != null ? oneItem.Menus.ToList() : null;
                oneModel.ParentId = 0;
                oneModel.CreateTime = oneItem.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                var resultTwoList = new List<MenuTree_DTO>();
                foreach (var twoItem in towList)
                {
                    var twoModel = twoItem.MapTo<MenuTree_DTO>();
                    var threeList = twoItem.Menus != null ? twoItem.Menus.ToList() : null;
                    twoModel.ParentId = oneItem.Id;
                    twoModel.CreateTime = twoItem.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    var resultThreeList = new List<MenuTree_DTO>();
                    foreach (var threeItem in threeList)
                    {
                        var threeModel = threeItem.MapTo<MenuTree_DTO>();
                        threeModel.ParentId = twoItem.Id;
                        threeModel.CreateTime = threeItem.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                        threeModel.children = null;
                        resultThreeList.Add(threeModel);
                    }
                    twoModel.children = resultThreeList;
                    resultTwoList.Add(twoModel);
                }
                oneModel.children = resultTwoList;
                resultList.Add(oneModel);
            }
            return resultList;
        }
        public async Task<List<MenuList_DTO>> GetMenuList()
        {
            var resultList = new List<MenuList_DTO>();
            var oneList = await _menuRepository.WhereLoadEntityEnumerableAsync(p => p.Enabled && p.ParentMenu == null);
            foreach (var oneItem in oneList)
            {
                var oneModel = new MenuList_DTO()
                {
                    label = oneItem.Name,
                    value = oneItem.Id
                };
                var childrenList = new List<MenuList_DTO>();
                var towList = oneItem.Menus != null ? oneItem.Menus.ToList() : null;
                foreach (var towItem in towList)
                {
                    var towModel = new MenuList_DTO()
                    {
                        label = towItem.Name,
                        value = towItem.Id
                    };
                    childrenList.Add(towModel);
                }
                if (towList.Count() > 0)
                    oneModel.children = childrenList;
                resultList.Add(oneModel);
            }
            return resultList;
        }
        public async Task<MenuEntity> GetMenu(int id)
        {
            return await _menuRepository.WhereLoadEntityAsync(p => p.Id == id);
        }
        public async Task Submit(Menu_DTO menuDto)
        {
            object parentEntity = null;
            if (menuDto.ParentId > 0)
            {
                parentEntity = await _menuRepository.WhereLoadEntityAsync(p => p.Id == menuDto.ParentId);
            }
            if (menuDto.Id > 0)
            {
                var model = await _menuRepository.WhereLoadEntityAsync(p => p.Id == menuDto.Id);
                model.Name = menuDto.Name;
                model.Path = menuDto.Path;
                model.Code = menuDto.Code;
                model.Icon = menuDto.Icon;
                model.Sort = menuDto.Sort;
                model.Enabled = menuDto.Enabled;
                model.EditTime = DateTime.Now;
                if (menuDto.ParentId > 0)
                {
                    model.ParentMenu = (MenuEntity)parentEntity;
                }
                _menuRepository.UpdateEntity(model);
            }
            else
            {
                var model = menuDto.MapTo<MenuEntity>();
                model.CreateTime = DateTime.Now;
                if (menuDto.ParentId > 0)
                {
                    model.ParentMenu = (MenuEntity)parentEntity;
                }
                await _menuRepository.AddEntityAsync(model);
            }
            await _menuRepository.CommitAsync();
        }
        public async Task<bool> Deletes(int[] ids)
        {
            var idArrar = ids.Distinct().ToArray();
            return await _menuRepository.DelEntityAsync(p => idArrar.Contains(p.Id)) > 0;
        }
        public async Task Enableds(int[] ids)
        {
            var idArrar = ids.Distinct().ToArray();
            var list = await _menuRepository.WhereLoadEntityEnumerableAsync(p => idArrar.Contains(p.Id));
            foreach (var item in list)
            {
                item.Enabled = item.Enabled ? false : true;
                _menuRepository.UpdateEntity(item);
                await _menuRepository.CommitAsync();
            }
        }
    }
}

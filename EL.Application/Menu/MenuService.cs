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

        public async Task<List<MenuListDto>> GetSelectMenuList()
        {
            var list = await _menuRepository.WhereLoadEntityEnumerableAsync(p => p.Enabled);
            var resultList = SelectMenuTree(list, 0);
            return resultList;
        }

        private List<MenuListDto> SelectMenuTree(List<MenuEntity> data, int parentId)
        {
            List<MenuListDto> treeList = new List<MenuListDto>();
            var list = data.Where(p => p.ParentId == parentId).ToList();
            foreach (var item in list)
            {
                bool hasChildren = data.Count(p => p.ParentId == item.Id) > 0;
                var model = new MenuListDto
                {
                    Label = item.Name,
                    Value = item.Id
                };
                model.Children = hasChildren ? SelectMenuTree(data, item.Id) : null;
                treeList.Add(model);
            }
            return treeList;
        }

        public async Task<List<MenuTreeDto>> GetMenuTreeList()
        {
            var list = await _menuRepository.LoadEntityAllAsync();
            var resultList = MenuTree(list, 0);
            return resultList;
        }

        private List<MenuTreeDto> MenuTree(List<MenuEntity> data, int parentId)
        {
            List<MenuTreeDto> treeList = new List<MenuTreeDto>();
            var list = data.Where(p => p.ParentId == parentId).ToList();
            foreach (var item in list)
            {
                bool hasChildren = data.Count(p => p.ParentId == item.Id) > 0;
                var model = item.MapTo<MenuTreeDto>();
                model.CreateTime = item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                model.Children = hasChildren ? MenuTree(data, item.Id) : null;
                treeList.Add(model);
            }
            return treeList;
        }

        public async Task<List<MenuListDto>> GetMenuList()
        {
            var resultList = new List<MenuListDto>();
            var list = await _menuRepository.WhereLoadEntityEnumerableAsync(p => p.Enabled);
            var oneList = list.Where(p => p.ParentId == 0);
            foreach (var oneItem in oneList)
            {
                var oneModel = new MenuListDto()
                {
                    Label = oneItem.Name,
                    Value = oneItem.Id
                };
                var childrenList = new List<MenuListDto>();

                var towList = list.Where(p => p.ParentId == oneItem.Id).ToList();
                foreach (var towItem in towList)
                {
                    var towModel = new MenuListDto()
                    {
                        Label = towItem.Name,
                        Value = towItem.Id
                    };
                    childrenList.Add(towModel);
                }
                if (towList.Count() > 0)
                    oneModel.Children = childrenList;
                resultList.Add(oneModel);
            }
            return resultList;
        }

        public async Task<MenuEntity> GetMenu(int id)
        {
            return await _menuRepository.WhereLoadEntityAsync(p => p.Id == id);
        }

        public async Task<int> Submit(MenuEntity entity)
        {
            if (entity.Id > 0)
            {
                var model = await _menuRepository.WhereLoadEntityAsync(p => p.Id == entity.Id);
                model.ParentId = entity.ParentId;
                model.Name = entity.Name;
                model.Path = entity.Path;
                model.Code = entity.Code;
                model.Icon = entity.Icon;
                model.Sort = entity.Sort;
                model.Enabled = entity.Enabled;
                model.EditTime = DateTime.Now;
                _menuRepository.UpdateEntity(model);
            }
            else
            {
                if (_menuRepository.GetEntitiesCount(p => p.Name == entity.Name) > 0)
                {
                    return -2;
                }
                entity.Code = Guid.NewGuid().ToString();
                entity.CreateTime = DateTime.Now;
                await _menuRepository.AddEntityAsync(entity);
            }
            await _menuRepository.CommitAsync();
            return 0;
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

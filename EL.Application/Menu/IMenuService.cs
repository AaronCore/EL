using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using EL.Entity;

namespace EL.Application
{
    public interface IMenuService
    {
        MenuEntity GetMenu(int id);
    }
}

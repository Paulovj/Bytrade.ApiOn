using Bytrade.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bytrade.Repo.Interfaces
{
    public interface IMenuItemPortionsRepository
    {

        void Update<T>(T entity) where T : class;

        Task<Array> GetAllMenuItemPortions(int Id);
        List<MenuItemPortions> GetUpdateMenuItemPortions(int FileGenerationId);

        Task<bool> SaveChangeAsync();

        Task<int> GetExisteMenuItemPortions();

    }
}

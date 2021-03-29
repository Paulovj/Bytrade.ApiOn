using Bytrade.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bytrade.Repo.Interfaces
{
    public interface IMenuItemsRepository
    {

        void Update<T>(T entity) where T : class;

        Task<Array> GetAllMenuItems(int Id);
        List<MenuItems> GetUpdateMenuItems(int FileGenerationId);

        Task<bool> SaveChangeAsync();

        Task<int> GetExisteMenuItems();

    }
}

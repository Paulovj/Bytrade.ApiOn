using Bytrade.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bytrade.Repo.Interfaces
{
    public interface IMenuItemPricesRepository
    {

        void Update<T>(T entity) where T : class;

        Task<Array> GetAllMenuItemPrices(int Id);
        List<MenuItemPrices> GetUpdateMenuItemPrices(int FileGenerationId);

        Task<bool> SaveChangeAsync();

        Task<int> GetExisteMenuItemPrices();

    }
}

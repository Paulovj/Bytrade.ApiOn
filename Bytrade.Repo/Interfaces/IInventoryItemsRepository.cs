using Bytrade.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bytrade.Repo.Interfaces
{
    public interface IInventoryItemsRepository
    {

        void Update<T>(T entity) where T : class;

        Task<Array> GetAllInventoryItems(int Id);
        List<InventoryItems> GetUpdateInventoryItems(int FileGenerationId);

        Task<bool> SaveChangeAsync();

        Task<int> GetExisteInventoryItems();

    }
}

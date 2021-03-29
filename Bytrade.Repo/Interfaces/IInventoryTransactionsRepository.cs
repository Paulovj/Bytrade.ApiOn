using Bytrade.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bytrade.Repo.Interfaces
{
    public interface IInventoryTransactionsRepository
    {

        void Update<T>(T entity) where T : class;

        Task<Array> GetAllInventoryItems(int Id);
        List<InventoryTransactions> GetUpdateInventoryTransactions(int FileGenerationId);

        Task<bool> SaveChangeAsync();

        Task<int> GetExisteInventoryTransactions();

    }
}

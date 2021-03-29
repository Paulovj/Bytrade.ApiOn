using Bytrade.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bytrade.Repo.Interfaces
{
    public interface IInventoryTransactionDocumentsRepository
    {

        void Update<T>(T entity) where T : class;

        Task<Array> GetAllInventoryTransactionDocuments(int Id);
        List<InventoryTransactionDocuments> GetUpdateInventoryTransactionDocuments(int FileGenerationId);

        Task<bool> SaveChangeAsync();

        Task<int> GetExisteInventoryTransactionDocuments();

    }
}

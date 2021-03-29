using Bytrade.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bytrade.Repo.Interfaces
{
    public interface IEntitiesRepository
    {
        void Update<T>(T entity) where T : class;

        Task<Array> GetAllEntities(int Id);
        List<Entities> GetUpdateEntities(int FileGenerationId);

        Task<bool> SaveChangeAsync();

        Task<int> GetExisteEntities();
    }
}

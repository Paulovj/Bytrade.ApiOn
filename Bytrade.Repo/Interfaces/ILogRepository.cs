using Bytrade.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bytrade.Repo.Interfaces
{
    public interface ILogRepository
    {
        void Update<T>(T entity) where T : class;
        Task<bool> SaveChangeAsync();
        Task<Log[]> GetPedingSql();
    }
}

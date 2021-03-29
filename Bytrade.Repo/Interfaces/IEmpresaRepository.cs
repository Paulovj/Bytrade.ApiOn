using Bytrade.Dominio;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Bytrade.Repo.Interfaces
{
    public interface IEmpresaRepository
    {
        void Update<T>(T entity) where T : class;
        void Add<T>(T entity) where T : class;
        void AddService<T>(T entity) where T : class;
        Task<bool> SaveChangeAsync();
        Task<Empresa[]> GetAllAtivo();
        Task<Empresa[]> GetPedingtFile();
        Task<Empresa> GetAllOwnerById(int id);

    }
}

using Bytrade.Dominio;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Bytrade.Repo.Interfaces
{
    public interface IFileGenerationsRepository
    {
        //Task<Array> Add();
        void Update<T>(T entity) where T : class;
        void Add<T>(T entity) where T : class;
        void AddService<T>(T entity) where T : class;
        Task<bool> SaveChangeAsync();
        Task<FileGeneration[]> GetAll();
        Task<FileGeneration[]> GetPedingtFile();
        Task<FileGeneration> GetAllOwnerById(int id);

    }
}

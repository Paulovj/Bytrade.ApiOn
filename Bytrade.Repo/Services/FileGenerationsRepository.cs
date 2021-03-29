using Bytrade.Dominio;
using Bytrade.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bytrade.Repo.Services
{
    public class FileGenerationsRepository : IFileGenerationsRepository
    {
        private readonly ByTradeGeralAppContext _context;

        public FileGenerationsRepository(ByTradeGeralAppContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);

        }

        public void AddService<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<FileGeneration> GetAllOwnerById(int id)
        {
            IQueryable<FileGeneration> query = _context.FileGeneration;
            query = query.AsNoTracking().OrderBy(h => h.Id);
            return await query.FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<FileGeneration[]> GetAll()
        {
            IQueryable<FileGeneration> query = _context.FileGeneration;
            query = query.AsNoTracking().OrderBy(h => h.Id);
            return await query.ToArrayAsync();
        }

        public async Task<FileGeneration[]> GetPedingtFile()
        {
            IQueryable<FileGeneration> query = _context.FileGeneration;
            query = query.AsNoTracking().OrderBy(h => h.Status == 0);
            return await query.ToArrayAsync();
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}

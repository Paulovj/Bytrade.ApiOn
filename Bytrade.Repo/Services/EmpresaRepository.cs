using Bytrade.Dominio;
using Bytrade.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bytrade.Repo.Services
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly ByTradeGeralAppContext _context;

        public EmpresaRepository(ByTradeGeralAppContext context)
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

        public async Task<Empresa> GetAllOwnerById(int id)
        {
            IQueryable<Empresa> query = _context.Empresa;
            query = query.AsNoTracking().OrderBy(h => h.IdEmpresa);
            return await query.FirstOrDefaultAsync(h => h.IdEmpresa == id);
        }

        public async Task<Empresa[]> GetAllAtivo()
        {
            IQueryable<Empresa> query = _context.Empresa;
            query = query.AsNoTracking().OrderBy(h => h.IdEmpresa);
            return await query.ToArrayAsync();
        }

        public async Task<Empresa[]> GetPedingtFile()
        {
            IQueryable<Empresa> query = _context.Empresa;
            query = query.AsNoTracking().OrderBy(h => h.IdEmpresa);
            return await query.ToArrayAsync();
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}

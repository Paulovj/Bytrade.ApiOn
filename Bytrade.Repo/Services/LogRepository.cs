using Bytrade.Dominio;
using Bytrade.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bytrade.Repo.Services
{
    public class LogRepository : ILogRepository
    {
        private readonly ByTradeGeralAppContext _context;

        public LogRepository(ByTradeGeralAppContext context)
        {
            _context = context;
        }

        
        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<Log[]> GetPedingSql()
        {
                IQueryable<Log> query = _context.Log;
            query = query.AsNoTracking().Where(h => h.Status == 0);
            return await query.ToArrayAsync();
        }


    }
}

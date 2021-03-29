using Bytrade.Dominio;
using Bytrade.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bytrade.Repo.Services
{
    public class MenuItemPortionsRepository : IMenuItemPortionsRepository
    {
        private readonly ByTradeGeralAppContext _context;

        public MenuItemPortionsRepository(ByTradeGeralAppContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Retorna todos os Users pelo FileGenerationId, é o arquivo de backup 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Array> GetAllMenuItemPortions(int CompanyId)
        {
            IQueryable<MenuItemPortions> query = _context.MenuItemPortions;
            query = query.AsNoTracking()
                .Where(u => u.CompanyId == CompanyId)
                .OrderBy(h => h.CompanyId == CompanyId);

            List<string> lists = new List<string>();
            foreach (var item in query)
            {
                var sql = "INSERT INTO MenuItemPortions(CompanyId, FileGenerationId, Name, MenuItemId, Multiplier) VALUES " +
                    "(11, " + item.FileGenerationId + ",'" + item.Name + "'," + item.MenuItemId + "," + item.Multiplier + "); ";
                lists.Add(sql);
            }



            var lista = lists.ToArray();

            return lista;
        }
        /// <summary>
        /// Alterar Users
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);

        }
        /// <summary>
        /// Salvar a alteração
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
        /// <summary>
        /// Define os campos que serão de backups e defina qual arquivo de backup
        /// </summary>
        /// <param name="FileGenerationId"></param>
        /// <returns></returns>
        public List<MenuItemPortions> GetUpdateMenuItemPortions(int FileGenerationId)
        {
            List<MenuItemPortions> listando = new List<MenuItemPortions>();

            var entity = _context.MenuItemPortions.AsNoTracking()
            .Where(h => h.FileGenerationId == 0)
            .ToList();

            foreach (MenuItemPortions e in entity)
            {
                e.FileGenerationId = FileGenerationId;
                listando.Add(e);
            }

            return listando;

        }

        public async Task<int> GetExisteMenuItemPortions()
        {
            var menuItemPortions = _context.MenuItemPortions.AsNoTracking()
            .Where(h => h.FileGenerationId == 0)
            .ToList();
            int i = 0;
            foreach (MenuItemPortions e in menuItemPortions)
            {
                i++;
            }

            return i;
        }


    }
}

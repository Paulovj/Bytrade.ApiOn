using Bytrade.Dominio;
using Bytrade.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bytrade.Repo.Services
{
    public class MenuItemPricesRepository : IMenuItemPricesRepository
    {
        private readonly ByTradeGeralAppContext _context;

        public MenuItemPricesRepository(ByTradeGeralAppContext context)
        {
            _context = context;
        }



        /// <summary>
        /// Retorna todos os Users pelo FileGenerationId, é o arquivo de backup 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Array> GetAllMenuItemPrices(int CompanyId)
        {
            IQueryable<MenuItemPrices> query = _context.MenuItemPrices;
            query = query.AsNoTracking()
                .Where(u => u.CompanyId == CompanyId)
                .OrderBy(h => h.CompanyId == CompanyId);

            List<string> lists = new List<string>();
            foreach (var item in query)
            {
                var price = Convert.ToDecimal(item.Price);


                var sql = "INSERT INTO MenuItemPrices(CompanyId,FileGenerationId, MenuItemPortionId, PriceTag, Price) VALUES " +
                    "(11, " + item.FileGenerationId + "," + item.MenuItemPortionId + ",'" + item.PriceTag + "'," + price + "); ";
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
        public List<MenuItemPrices> GetUpdateMenuItemPrices(int FileGenerationId)
        {
            List<MenuItemPrices> listando = new List<MenuItemPrices>();

            var menuItemPrices = _context.MenuItemPrices.AsNoTracking()
            .Where(h => h.FileGenerationId == 0)
            .ToList();

            foreach (MenuItemPrices m in menuItemPrices)
            {
                m.FileGenerationId = FileGenerationId;
                listando.Add(m);
            }

            return listando;

        }

        public async Task<int> GetExisteMenuItemPrices()
        {
            var menuItemPrices = _context.MenuItemPrices.AsNoTracking()
            .Where(h => h.FileGenerationId == 0)
            .ToList();
            int i = 0;
            foreach (MenuItemPrices e in menuItemPrices)
            {
                i++;
            }

            return i;
        }


    }
}

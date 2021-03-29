using Bytrade.Dominio;
using Bytrade.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bytrade.Repo.Services
{
    public class MenuItemsRepository : IMenuItemsRepository
    {
        private readonly ByTradeGeralAppContext _context;

        public MenuItemsRepository(ByTradeGeralAppContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Retorna todos os Users pelo FileGenerationId, é o arquivo de backup 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Array> GetAllMenuItems(int CompanyId)
        {
            IQueryable<MenuItems> query = _context.MenuItems;
            query = query.AsNoTracking()
                .Where(u => u.CompanyId == CompanyId)
                .OrderBy(h => h.CompanyId  == CompanyId);

            List<string> lists = new List<string>();
            foreach (var item in query)
            {
                var sql = "INSERT INTO MenuItems (CompanyId, FileGenerationId, GroupCode, Barcode, Tag, Name) VALUES " +
                    "(11," + item.FileGenerationId + ",'" + item.GroupCode + "','" + item.Barcode + "','" + item.Tag + "','" + item.Name + "'); ";
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
        public List<MenuItems> GetUpdateMenuItems(int FileGenerationId)
        {
            List<MenuItems> listando = new List<MenuItems>();

            var menuItems = _context.MenuItems.AsNoTracking()
            .Where(h => h.FileGenerationId == 0)
            .ToList();

            foreach (MenuItems m in menuItems)
            {
                m.FileGenerationId = FileGenerationId;
                listando.Add(m);
            }

            return listando;

        }

        public async Task<int> GetExisteMenuItems()
        {
            var menuItems = _context.MenuItems.AsNoTracking()
            .Where(h => h.FileGenerationId == 0)
            .ToList();
            int i = 0;
            foreach (MenuItems m in menuItems)
            {
                i++;
            }

            return i;
        }
    }
}

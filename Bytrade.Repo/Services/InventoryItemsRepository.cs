using Bytrade.Dominio;
using Bytrade.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bytrade.Repo.Services
{
    public class InventoryItemsRepository : IInventoryItemsRepository
    {
        private readonly ByTradeGeralAppContext _context;

        public InventoryItemsRepository(ByTradeGeralAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todos os Users pelo FileGenerationId, é o arquivo de backup 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Array> GetAllInventoryItems(int CompanyId)
        {
            IQueryable<InventoryItems> query = _context.InventoryItems;
            query = query.AsNoTracking()
                .Where(u => u.CompanyId == CompanyId)
                .OrderBy(h => h.CompanyId == CompanyId);

            List<string> lists = new List<string>();
            foreach (var item in query)
            {
                var sql = "INSERT INTO InventoryItems(CompanyId, FileGenerationId, GroupCode, BaseUnit, TransactionUnit, TransactionUnitMultiplier, Warehouse, Name) " +
                    "VALUES " +
                    "(11," + item.FileGenerationId + ",'" + item.GroupCode + "','" + item.BaseUnit + "', ,'" + item.TransactionUnit + "', ," + item.TransactionUnitMultiplier + ", ,'" + item.Warehouse + "', ,'" + item.Name + "'); ";
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
        public List<InventoryItems> GetUpdateInventoryItems(int FileGenerationId)
        {
            List<InventoryItems> listando = new List<InventoryItems>();

            var inventoryItems = _context.InventoryItems.AsNoTracking()
            .Where(h => h.FileGenerationId == 0)
            .ToList();

            foreach (InventoryItems i in inventoryItems)
            {
                i.FileGenerationId = FileGenerationId;
                listando.Add(i);
            }

            return listando;

        }

        public async Task<int> GetExisteInventoryItems()
        {
            var inventoryItems = _context.InventoryItems.AsNoTracking()
            .Where(h => h.FileGenerationId == 0)
            .ToList();
            int i = 0;
            foreach (InventoryItems iv in inventoryItems)
            {
                i++;
            }

            return i;
        }

    }
}

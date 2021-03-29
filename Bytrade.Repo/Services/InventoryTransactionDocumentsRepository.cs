using Bytrade.Dominio;
using Bytrade.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bytrade.Repo.Services
{
    public class InventoryTransactionDocumentsRepository : IInventoryTransactionDocumentsRepository
    {
        private readonly ByTradeGeralAppContext _context;

        public InventoryTransactionDocumentsRepository(ByTradeGeralAppContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Retorna todos os Users pelo FileGenerationId, é o arquivo de backup 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Array> GetAllInventoryTransactionDocuments(int CompanyId)
        {
            IQueryable<InventoryTransactionDocuments> query = _context.InventoryTransactionDocuments;
            query = query.AsNoTracking()
                .Where(u => u.CompanyId == CompanyId)
                .OrderBy(h => h.CompanyId == CompanyId);

            List<string> lists = new List<string>();
            foreach (var item in query)
            {
                var sql = "INSERT INTO InventoryTransactionDocuments(CompanyId, FileGenerationId, Date, Name ) VALUES " +
                    "(11, " + item.FileGenerationId + ", '" + item.Date + "', '" + item.Name + "'); ";
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
        public List<InventoryTransactionDocuments> GetUpdateInventoryTransactionDocuments(int FileGenerationId)
        {
            List<InventoryTransactionDocuments> listando = new List<InventoryTransactionDocuments>();

            var inventoryTransactionDocuments = _context.InventoryTransactionDocuments.AsNoTracking()
            .Where(h => h.FileGenerationId == 0)
            .ToList();

            foreach (InventoryTransactionDocuments i in inventoryTransactionDocuments)
            {
                i.FileGenerationId = FileGenerationId;
                listando.Add(i);
            }

            return listando;

        }

        public async Task<int> GetExisteInventoryTransactionDocuments()
        {
            var inventoryTransactionDocuments = _context.InventoryTransactionDocuments.AsNoTracking()
            .Where(h => h.FileGenerationId == 0)
            .ToList();
            int i = 0;
            foreach (InventoryTransactionDocuments iv in inventoryTransactionDocuments)
            {
                i++;
            }

            return i;
        }


    }
}

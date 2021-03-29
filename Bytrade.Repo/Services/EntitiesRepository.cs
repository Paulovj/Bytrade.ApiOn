using Bytrade.Dominio;
using Bytrade.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bytrade.Repo.Services
{
    public class EntitiesRepository : IEntitiesRepository
    {
        private readonly ByTradeGeralAppContext _context;

        public EntitiesRepository(ByTradeGeralAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todos os Users pelo FileGenerationId, é o arquivo de backup 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Array> GetAllEntities(int CompanyId)
        {
            IQueryable<Entities> query = _context.Entities;
            query = query.AsNoTracking()
                .Where(u => u.CompanyId == CompanyId)
                .OrderBy(h => h.CompanyId  == CompanyId);

            List<string> lists = new List<string>();
            foreach (var item in query)
            {
                var sql = "INSERT INTO Entities(CompanyId, FileGenerationId, EntityTypeId, EmpresaId, LastUpdateTime, SearchString, CustomData, AccountId, WarehouseId, Name) VALUES " +
                    "(11," + item.FileGenerationId + "," + item.EntityTypeId + ",0,'" + item.LastUpdateTime + "','" + item.SearchString + "','" + item.CustomData + "','" + item.AccountId + "','" + item.WarehouseId + "','" + item.Name + "'); ";
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
        public List<Entities> GetUpdateEntities(int companyId)
        {
            List<Entities> listando = new List<Entities>();

            var entity = _context.Entities.AsNoTracking()
            .Where(h => h.CompanyId == companyId)
            .ToList();

            foreach (Entities e in entity)
            {
                e.CompanyId = companyId;
                listando.Add(e);
            }

            return listando;

        }

        public async Task<int> GetExisteEntities()
        {
            var entity = _context.Entities.AsNoTracking()
            .Where(h => h.FileGenerationId == 0)
            .ToList();
            int i = 0;
            foreach (Entities e in entity)
            {
                i++;
            }

            return i;
        }
    }
}

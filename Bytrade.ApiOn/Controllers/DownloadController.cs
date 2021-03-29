using Bytrade.Dominio;
using Bytrade.Repo.Interfaces;
using BytradeApiOn.Functions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bytrade.ApiOn.Controllers
{
    [Route("api/file")]
    public class DownaloadController : Controller
    {
        private readonly IFileGenerationsRepository _repo;
        private readonly IEntitiesRepository _entities;
        private readonly IFileGenerationsRepository _file;
        private readonly IInventoryItemsRepository _iventoryItems;
        private readonly IInventoryTransactionDocumentsRepository _iventoryTransactionDocuments;
        private readonly IMenuItemPortionsRepository _menuItemPortions;
        private readonly IMenuItemPricesRepository _menuItemPrices;
        private readonly IMenuItemsRepository _menuItems;
        private object _zip;

        public DownaloadController(IFileGenerationsRepository repo, IEntitiesRepository entities, 
            IFileGenerationsRepository fileG,
            IInventoryItemsRepository iventoryItems,
            IInventoryTransactionDocumentsRepository iventoryTransactionDocuments,
            IMenuItemPortionsRepository menuItemPortions,
            IMenuItemPricesRepository menuItemPrices,
            IMenuItemsRepository menuItems
            )
        {
            _repo = repo;
            _entities = entities;
            _file = fileG;
            _iventoryItems = iventoryItems;
            _iventoryTransactionDocuments = iventoryTransactionDocuments;
            _menuItemPortions = menuItemPortions;
            _menuItemPrices =  menuItemPrices;
            _menuItems = menuItems;
        }

        /// <summary>
        /// fazendo download de arquivo para atualização de cliente
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpGet("download")]
        public async Task<IActionResult> download(int companyId)
        {
            try
            {
                var folder = new Folder();
                string nameFolder = "Upload";
                folder.createFolder(nameFolder);

                var exsiteEntities = await _entities.GetExisteEntities();

                var fileGeneration = new FileGeneration()
                {
                    Id = 0,
                    FileName = "ApiOn_"+ companyId + "_" + DateTime.Now.ToString("dd_mm_yyyy_hh_m") + ".txt",
                    CompanyId = companyId,
                    Name = "ApiOn_11_" + DateTime.Now.ToString("dd_mm_yyyy_hh_m"),
                    Status = 0,
                    DateGeneration = DateTime.Now,
                    DateUpdate = DateTime.Now
                };

                _file.AddService(fileGeneration);
                if (await _file.SaveChangeAsync())
                {
                    var sqlEntities = await _entities.GetAllEntities(fileGeneration.CompanyId);
                    var sqlIventoryItems = await _iventoryItems.GetAllInventoryItems(fileGeneration.CompanyId);
                    var sqlIventoryTransaction = await _iventoryTransactionDocuments.GetAllInventoryTransactionDocuments(fileGeneration.CompanyId);
                    var sqlMenuItemPortion = await _menuItemPortions.GetAllMenuItemPortions(fileGeneration.CompanyId);
                    var sqlMenuPrices = await _menuItemPrices.GetAllMenuItemPrices(fileGeneration.CompanyId);
                    var sqlMenuItems= await _menuItems.GetAllMenuItems(fileGeneration.CompanyId);


                    ////declarando a variável do tipo StreamWriter para
                    //abrir ou criar um arquivo para escrita
                    StreamWriter x;
                    //Colocando o endereço físico (caminho do arquivo texto)
                    //string Caminho = "C:\\Users\\paulo\\Documents\\"+fileGenerations.Filename;

                    string nameFolder2 = nameFolder + "/" + fileGeneration.Name;
                    folder.createFolder(nameFolder2);

                    string Caminho = "./" + nameFolder + "/" + fileGeneration.Name + "/" + fileGeneration.FileName;

                    //usando o metodo e abrindo o arquivo texto
                    //x = File.AppendText(Caminho);
                    x = System.IO.File.AppendText(Caminho);
                    

                    //continuando escrevendo neste arquivo
                    //escrevendo a partir da ultima linha
                    
                    foreach (var entities in sqlEntities)
                    {
                        x.WriteLine(entities);
                    }

                    foreach (var iventoryItems in sqlIventoryItems)
                    {
                        x.WriteLine(iventoryItems);
                    }

                    foreach (var iventoryTransaction in sqlIventoryTransaction)
                    {
                        x.WriteLine(iventoryTransaction);
                    }

                    foreach (var menuItemPortion in sqlMenuItemPortion)
                    {
                        x.WriteLine(menuItemPortion);
                    }

                    foreach (var menuPrices in sqlMenuPrices)
                    {
                        x.WriteLine(menuPrices);
                    }

                    foreach (var menuItems in sqlMenuItems)
                    {
                        x.WriteLine(menuItems);
                    }


                    x.Close();

                    //string Caminho = "C:\\Users\\paulo\\Documents\\" + fileGenerations.Filename;
                    string PasswordForZipFile = "ourcodeworld123";
                    var _zip = new Zip();
                    _zip.compressDirectoryWithPassword(
                        @nameFolder2,
                        @nameFolder2 + ".zip",
                        PasswordForZipFile,
                        9
                    );
                    Directory.Delete(@nameFolder2, true);

                }

                    return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Arquivo não pode ser enviado: + {e}");
            }
        }
    }
}

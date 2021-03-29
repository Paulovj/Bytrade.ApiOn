using Bytrade.Dominio;
using Bytrade.Repo.Interfaces;
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
    public class UploadController : Controller
    {
        private readonly IFileGenerationsRepository _repo;
        public UploadController(IFileGenerationsRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Somente arquivo zipado, para atualização do banco de dados
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            try
            {
                
                var result = new List<FileUploadResult>();
                foreach (var file in files)
                {
                    string[] arquivo = file.FileName.Split('_');
                    var fileG = new FileGeneration();
                    
                    if (file.ContentType == "application/x-zip-compressed" || file.ContentType =="application/zip")
                    {
                        
                        
                        int arqCompanyId = int.Parse(arquivo[1]);
                        fileG.CompanyId = arqCompanyId;
                        fileG.FileName = file.FileName;
                        fileG.DateGeneration = DateTime.Now;
                        fileG.Status = 0;


                        var path = Path.Combine(Directory.GetCurrentDirectory(), "Download", file.FileName);
                        var stream = new FileStream(path, FileMode.Create);                        
                        _repo.Add(fileG);
                        if (await _repo.SaveChangeAsync())
                        {
                            file.CopyToAsync(stream);
                            result.Add(new FileUploadResult() { Name = file.FileName, Length = file.Length, Msg = "Arquivo enviado com sucesso", Success = true });
                        }

                    }
                    else
                    {
                        result.Add(new FileUploadResult() { Name = file.FileName + file.ContentType, Msg = "Arquivo não pode ser enviado", Success = false });
                    }
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest($"Arquivo não pode ser enviado: + {e}");
            }
        }


        /// <summary>
        /// Retorno
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("OwnerController/Result")]
        // GET: OwnerController/Result/5
        public async Task<IActionResult> Result(int id)
        {
            try
            {
                var owners = await _repo.GetAll();
                return Ok(owners);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }

        }

        internal class FileUploadResult
        {
            public string Name { get; internal set; }
            public long Length { get; internal set; }
            public string Msg { get; internal set; }
            public Boolean Success { get; internal set; }
        }


    }

   
}

using Bytrade.Dominio;
using Bytrade.Repo.Interfaces;
using BytradeApiOn.Functions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Bytrade.ApiOn.Controllers
{
    [Route("api/Empresa")]
    public class EmpresaController : Controller
    {

        private readonly IEmpresaRepository _empr;

        public EmpresaController(IEmpresaRepository empr)
        {
            _empr = empr;
        }
        /// <summary>
        /// Cadastro de empresa
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("cadastro")]
        public async Task<IActionResult> cadastro(Empresa model)
        {
            try
            {
                _empr.Add(model);
                if(await _empr.SaveChangeAsync()) 
                {
                    return new JsonResult(model);
                }

            }
            catch (Exception err)
            {

                return BadRequest($"Não cadastrou a empresa, segue o erro: {err}");
            }
            return BadRequest("Não cadastrou a empresa");
        }

        /// <summary>
        /// Alteração de empresa
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("alteracao")]
        public async Task<IActionResult> alteracao(Empresa model)
        {
            try
            {
                _empr.Update(model);
                if (await _empr.SaveChangeAsync())
                {
                    return new JsonResult(model);
                }

            }
            catch (Exception err)
            {

                return BadRequest($"Não cadastrou a empresa, segue o erro: {err}");
            }
            return BadRequest("Não cadastrou a empresa");
        }
        [HttpGet("visualizarAtivos")]
        public async Task<IActionResult> visualizarAtivos()
        {
            try
            {
                var empresa = await _empr.GetAllAtivo();

                return new JsonResult (empresa);
            }
            catch (Exception err)
            {

                return BadRequest($"Empresa não encontrada, segue o erro: {err}");
            }

            return BadRequest("Empresa não encontrada");
        }



        [HttpGet("visualizarId")]
        public async Task<IActionResult> visualizarId(int Id)
        {
            try
            {
                var empresa = await _empr.GetAllOwnerById(Id);

                return new JsonResult(empresa);
            }
            catch (Exception err)
            {

                return BadRequest($"Empresa não encontrada, segue o erro: {err}");
            }

            return BadRequest("Empresa não encontrada");
        }

        [HttpGet("geracaoConfig")]
        //public async Task<IActionResult> geracaoConfig(int Id)
        public async Task<IActionResult> geracaoConfig(int Id)
        {
            try
            {   
                //retorno da empresa que irá gerar o arquivo de configuração
                var empresa = await _empr.GetAllOwnerById(Id);
                
                //criação da pasta e o caminho e o nome do arquivo
                var folder = new Folder();
                //string nameFolder = "Upload";
                //folder.createFolder(nameFolder);

                string filename = "Config";
                string nameFolder2 = "Upload/"+filename;
                folder.createFolder(nameFolder2);

                if (System.IO.File.Exists(nameFolder2 + ".zip"))
                {
                    System.IO.File.Delete(nameFolder2 + ".zip");
                }
                
                string Caminho = nameFolder2 + "/" + filename + ".txt";

                //Criação do arquivo e inserido configuração da empresa
                StreamWriter x;
                x = System.IO.File.AppendText(Caminho);

                x.WriteLine("Id Empresa = " + empresa.IdEmpresa);
                x.WriteLine("Id Pessoa = " + empresa.IdPessoa);
                x.WriteLine("Nome Social = " + empresa.NomeSocial);
                x.WriteLine("Tipo Negocio = " + empresa.TipoNegocio);
                x.WriteLine("Id Empresa = " + empresa.Endereco);

                x.Close();
                string PasswordForZipFile = "ourcodeworld123";

                var _zip = new Zip();

                string nameFolder3 = "./Upload/" + filename;
                _zip.compressDirectoryWithPassword(
                    @nameFolder3,
                    @nameFolder3 + ".zip",
                    PasswordForZipFile,
                    9
                );
                Directory.Delete(@nameFolder3, true);

                string filePath = nameFolder3;
                string fileName = filename + ".zip";

                byte[] fileBytes = System.IO.File.ReadAllBytes(nameFolder3+".zip");

                return File(fileBytes, "application/force-download", fileName);


                //return new JsonResult(empresa);
            }
            catch (Exception err)
            {

                return BadRequest($"Empresa não encontrada, segue o erro: {err}");
            }

            return BadRequest("Empresa não encontrada");
        }
    }
}

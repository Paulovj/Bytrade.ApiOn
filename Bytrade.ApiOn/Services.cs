using Bytrade.Dominio;
using Bytrade.Repo.Interfaces;
using BytradeApiOn.Functions;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BytradeApiOff
{
    public class Services : IJob
    {
        private readonly IFileGenerationsRepository _file;


        public Services(
            IFileGenerationsRepository fileGeneretation)
        {
            _file = fileGeneretation;
        }



        public async Task Execute(IJobExecutionContext context)
        {
            var pedingFile = await _file.GetPedingtFile();
            foreach (FileGeneration f in pedingFile)
            {
                string[] arquivo = f.FileName.Split('.');
                string fileName = f.FileName;
                int companyId = f.CompanyId;
                int id = f.Id;

                var caminhoZip = "Download/" + f.FileName;

                if (File.Exists(caminhoZip))
                {

                    // descompactar arquivo 
                    var _zip = new Zip();
                    _zip.ExtractZipContent(
                        @"Download\" + f.FileName,
                        "ourcodeworld123",
                        @"Download\" + arquivo[0]
                    );
                    var caminho = "Download/" + arquivo[0] + "/" + arquivo[0] + ".txt";
                    var ler = new LerAquivo();
                    ler.abrir(caminho, id);
                    Directory.Delete(@"Download/" + arquivo[0], true);
                    File.Delete(@"Download/" + f.FileName);
                }


                // fazendo atualização do arquivo e mudando o status para não repetir;
                f.Status = 1;
                f.DateUpdate = DateTime.Now;

                _file.Update(f);
                if (await _file.SaveChangeAsync())
                {
                    await Console.Out.WriteLineAsync("Arquivo atualizado");
                }
            }


        }


    }
}

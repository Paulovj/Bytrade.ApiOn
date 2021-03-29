using Bytrade.Dominio;
using Bytrade.Repo.Interfaces;
using BytradeApiOn.Functions;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bytrade.ApiOn
{
    public class CronLog : IJob
    {

        private readonly IFileGenerationsRepository _file;
        private readonly ILogRepository _log;


        public CronLog(
            IFileGenerationsRepository fileGeneretation, ILogRepository log)
        {
            _file = fileGeneretation;
            _log = log;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var pedingLog =await _log.GetPedingSql();
            foreach (Log l in pedingLog)
            {
                string sql = l.Sql;
                var command = new SqlCommad();
                bool result = command.gerarLog(sql);

                if (result == true)
                {
                    l.Status = 1;
                    l.DateUpdate = DateTime.Now;
                    _log.Update(l);
                    if (await _file.SaveChangeAsync())
                    {
                        await Console.Out.WriteLineAsync("Arquivo atualizado");
                    }

                }
            }

        }
    }
}

using System;
using System.Collections.Generic;

namespace Bytrade.Dominio
{
    public partial class Log
    {

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int FileGenerationId { get; set; }
        public string Sql { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int Status { get; set; }

        public virtual Company Company { get; set; }
        public virtual FileGeneration FileGeneration { get; set; }
    }
}

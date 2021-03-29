using System;
using System.Collections.Generic;

namespace Bytrade.ApiOn.data
{
    public partial class Empresa
    {
        public int IdEmpresa { get; set; }
        public int IdPessoa { get; set; }
        public string CodEmpresa { get; set; }
        public string NomeSocial { get; set; }
        public string TipoNegocio { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public string IdUsuarioCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public string IdUsuarioAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public string IdUsuarioExclusao { get; set; }
    }
}

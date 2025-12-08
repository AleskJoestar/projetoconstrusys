using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace api_Construsys.Models
{
    [Table("fornecedor")]
    public class Fornecedor
    {
        [Column("id_forne")]
        public int Id { get; set; }

        [Column("nome_forne")]
        public string Nome { get; set; }

        [Column("contato_forne")]
        public string Contato { get; set; }
    }
}

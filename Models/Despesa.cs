using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace api_Construsys.Models
{
    [Table("Despesa")]
    public class Despesa
    {
        [Column("id_despesa")]
        public int Id { get; set; }

        [Column("descricao_desp")]
        public string Descricao { get; set; }

        [Column("valor_desp")]
        public float valor { get; set; }

        [Column("data_desp")]
        public DateTime data { get; set; }


        [Column("id_const_fk")]
        public int IdConstrucao { get; set; }

        [Column("id_forne_fk")]
        public int IdFornecedor { get; set; }

        [ForeignKey("IdConstrucao")]
        public Construcao Construcao { get; set; }

        [ForeignKey("IdFornecedor")]
        public Fornecedor Fornecedor { get; set; }


    }
}


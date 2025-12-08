using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace api_Construsys.Models
{
    [Table("mao_de_obra")]
    public class MaoDeObra
    {
        [Column("id_mao_de_obra")]
        public int Id { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }
        [Column("custo")]
        public float custo { get; set; }

        [Column("id_const_fk")]
        public int IdConstrucao { get; set; }

        [ForeignKey("IdConstrucao")]
        public Construcao Construcao { get; set; }
    }
}


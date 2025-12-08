using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace api_Construsys.Models
{
    [Table("construcaomaterial")]
    public class ConstrucaoMaterial

    {
        [Column("id")]
        public int Id { get; set; }
        [Column("id_construcao")]
        public int IdConstrucao { get; set; }
        [JsonIgnore]
        public Construcao Construcao { get; set; }

        [Column("id_material")]
        public int IdMaterial { get; set; }
        public Material Material { get; set; }

        [Column("quantidade_const_mat")]
        public float Quantidade { get; set; }
    }
}

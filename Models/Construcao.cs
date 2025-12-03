using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using api_Construsys.Models;


namespace api_Construsys.Models
{
    [Table("construcao")]
    public class Construcao
    {
        [Column("id_const")]
        public int Id { get; set; }

        [Column("nome_projeto_const")]
        public string Nome { get; set; }

        [Column("localizacao_const")]
        public string localizacao { get; set; }

        [Column("id_proprietario_fk")]
        public int IdProprietario { get; set; }

        [ForeignKey("IdProprietario")]
        public Proprietario Proprietario { get; set; }
        [JsonIgnore]
        public List<ConstrucaoMaterial> ConstrucaoMateriais { get; set; }

    }
}

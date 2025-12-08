using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace api_Construsys.Models
{
    [Table("Material")]
    public class Material
    {
        [Column("id_material")]
        public int Id { get; set; }

        [Column("nome_material")]
        public string Nome { get; set; }

        [Column("unidade_material")]
        public string Unidade { get; set; }

        public List<ConstrucaoMaterial> ConstrucaoMateriais { get; set; }
    }
}

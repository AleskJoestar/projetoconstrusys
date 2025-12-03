using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace api_Construsys.Dtos
{
    public class ConstrucaoMaterialDto
    {


        [Required(ErrorMessage = "A Construção deve ser Informada.")]
        public int IdConstrucao { get; set; }

        [Required(ErrorMessage = "O Mateial Deve ser Informado")]
        public int IdMaterial { get; set; }

        [Required(ErrorMessage = "A Quantidade Deve ser Informada")]
        public float Quantidade { get; set; }
    }
}

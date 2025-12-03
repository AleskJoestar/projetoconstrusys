using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace api_Construsys.Dtos
{
    public class MaterialDto
    {
        [Required(ErrorMessage = "O nome do material é obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Unidade do material é obrigatoria")]
        public string Unidade { get; set; }
    }
}

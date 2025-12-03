using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace api_Construsys.Dtos
{
    public class ConstrucaoDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "O Nome da Contrução deve ter no minimo 3 caracteres")]
        public string Nome { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "O Endereço da contrução deve ser informado com no minimo 5 caracteres")]
        public string Localizacao { get; set; }


        [Required(ErrorMessage = "O Proprietário da Construção deve ser informado.")]
        public int IdProprietario { get; set; }
    }
}


using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace api_Construsys.Dtos
{
    public class MaoDeObraDto
    {
        [Required]
        [MinLength(10, ErrorMessage = "A Descrição da Mão de Obra deve ser informada")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "O Valor daMão de Obra deve ser Informado")]

        public float custo { get; set; }


        [Required(ErrorMessage = "A Construção deve ser Informada.")]
        public int IdConstrucao { get; set; }
    }
}
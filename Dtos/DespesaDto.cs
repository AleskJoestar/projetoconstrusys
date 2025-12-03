using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace api_Construsys.Dtos
{
    public class DespesaDto
    {
        [Required]
        [MinLength(10, ErrorMessage = "A descrição da Despesa deve ser informada   ")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Valor da Despesa deve ser Informado")]
        public float Valor { get; set; }


        [Required(ErrorMessage = "A Data da Despesa deve ser Informada")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "A Construção dve ser informada ")]
        public int IdConstrucao { get; set; }

        [Required(ErrorMessage = "O Fornecedor Deve ser Informado ")]
        public int IdFornecedor { get; set; }

    }
}
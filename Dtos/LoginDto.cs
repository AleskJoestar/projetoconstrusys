using System.ComponentModel.DataAnnotations;

namespace ApiServico.Models.Dtos
{
    public class LoginDto
    {
        [Required]
        [MinLength(5)]
        public required string Email { get; set; }

        [Required]
        [MinLength(5)]
        public required string Senha { get; set; }
    }
}

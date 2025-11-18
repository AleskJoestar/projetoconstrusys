using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace api_Construsys.Models
{
    [Table("proprietario")]
    public class Proprietario
    {
        [Column("id_proprietario")]
        public int Id { get; set; }

        [Column("nome_proprietario")]
        public string Nome { get; set; }
        [Column("email_proprietario")]
        public string Email { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace api_Construsys.Dtos
{
    public class ConstrucaoResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Localização { get; set; }
       public ProprietarioResponseDto Proprietario { get; set; }

    }

}


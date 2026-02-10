using WebApiBiblioteca.Models;
using WebApiBiblioteca.Dto.Vinculo;

namespace WebApiBiblioteca.Dto.Livro
{
    public class LivroCriacaoDto
    {
        public string Titulo { get; set; }
        public AutorVinculoDto Autor { get; set; }
    }
}

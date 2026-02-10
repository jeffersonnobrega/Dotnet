using WebApiBiblioteca.Dto.Vinculo;
using WebApiBiblioteca.Models;

namespace WebApiBiblioteca.Dto.Livro
{
    public class LivroEdicaoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public AutorVinculoDto Autor { get; set; }
    }
}

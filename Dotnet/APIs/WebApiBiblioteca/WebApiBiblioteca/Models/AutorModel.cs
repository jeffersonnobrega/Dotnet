using System.Text.Json.Serialization;

namespace WebApiBiblioteca.Models
{
    public class AutorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        [JsonIgnore] //com isso o trecho abaixo é ignorado na exibição da api, pois ao criar um autor não preciso exibir a lista de livros
        public ICollection<LivroModel> Livros { get; set; }
    }
}

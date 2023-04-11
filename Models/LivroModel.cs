using System.ComponentModel.DataAnnotations;

namespace ListaDeLivros.Models
{
    public class LivroModel
    {
        [Key]    
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do livro não pode ser nulo!")]
        [StringLength(40, ErrorMessage = "O nome do livro não pode ultrapassar 20 caracteres!") ]
        public string NomeLivro { get; set; }

        [StringLength(30, ErrorMessage = "O nome do Autor não pode ultrapassar 20 caracteres!")]
        [Required(ErrorMessage = "O nome do Autor não pode ser nulo!")]
        public string NomeAutor { get; set; }

        [StringLength(250, ErrorMessage = "A descrição não pode ultrapassar 250 caracteres!")]
        [Required(ErrorMessage = "A Descrição não pode ser nula!")]
        public string Descricao { get; set; }
    }
}

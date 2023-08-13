using ListaDeLivros.Enums;
using System.ComponentModel.DataAnnotations;

namespace ListaDeLivros.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="O nome do usuario não pode ser nulo!")]
        [StringLength(50, ErrorMessage = "O nome não pode ultrapassar 50 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O login não pode ser nulo!")]
        public string Login { get; set; }
        
        [Required(ErrorMessage = "O email não pode ser nulo! ")]
        [EmailAddress(ErrorMessage = " Digite um email válido! ")]
        public string Email { get; set; }
        public PerfilEnum Perfil { get; set; }

        [Required(ErrorMessage = "A senha não pode ser nula!")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

    }
}

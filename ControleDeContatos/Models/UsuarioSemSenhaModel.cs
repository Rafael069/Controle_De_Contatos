using ControleDeContatos.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do Usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o login do Usuário")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o e-mail do Usuário")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é Usuário!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o Perfil do Usuário")]
        public PerfilEnum? Perfil { get; set; }
    }
}

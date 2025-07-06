using ControleDeContatos.Enums;
using ControleDeContatos.Helper;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UsuarioModel
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

        [Required(ErrorMessage = "Digite a senha do Usuário")]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }


        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }


    }

}

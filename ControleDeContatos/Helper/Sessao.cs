using ControleDeContatos.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

namespace ControleDeContatos.Helper
{
    public class Sessao : ISessao
    {

        //HttpContext criando sessões do usuário

        private readonly IHttpContextAccessor _httpContext;


        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public UsuarioModel BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            // Verificação pra ver se veio nulo
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessaoDoUsuario(UsuarioModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }


        public void RemoverSessaoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }

    }
}

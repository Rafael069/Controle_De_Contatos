using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }


        public List<UsuarioModel> BuscarTodos()
        {
           return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
           // Inserir no banco de dados
             usuario.DataCadastro = DateTime.Now;
             usuario.SetSenhaHash();
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;

        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            // Buscar o valor a ser atualizado

            UsuarioModel usuarioDB = ListarPorId(usuario.Id);

            // Verificação

            if (usuarioDB == null) throw new Exception("Houve um erro na atualização do Usuário");


            // Confirmando dados
            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;

            // Salvando no banco
            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            // Buscar o valor a ser Apagado

            UsuarioModel usuarioDB = ListarPorId(id);

            // Verificação

            if (usuarioDB == null) throw new Exception("Houve um erro ao delear usuário");


            // Salvando no banco
            _bancoContext.Usuarios.Remove(usuarioDB);
            _bancoContext.SaveChanges();

            return true;
        }

        
    }
}

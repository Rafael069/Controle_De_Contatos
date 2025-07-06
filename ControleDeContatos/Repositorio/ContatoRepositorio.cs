using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }


        public List<ContatoModel> BuscarTodos(int usuarioId)
        {
           return _bancoContext.Contatos.Where(x => x.UsuarioId == usuarioId).ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
           // Inserir no banco de dados

            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;

        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            // Buscar o valor a ser atualizado

            ContatoModel contatoDB = ListarPorId(contato.Id);

            // Verificação

            if (contatoDB == null) throw new Exception("Houve um erro na atualização do Contato");


            // Confirmando dados
            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            // Salvando no banco
            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
        }

        public bool Apagar(int id)
        {
            // Buscar o valor a ser Apagado

            ContatoModel contatoDB = ListarPorId(id);

            // Verificação

            if (contatoDB == null) throw new Exception("Houve um erro no Delete do Contato");


            // Salvando no banco
            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}

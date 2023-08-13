using ListaDeLivros.Data;
using ListaDeLivros.Models;

namespace ListaDeLivros.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _dataContext;
        public UsuarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<UsuarioModel> BuscarTodos()
        {
            return _dataContext.Usuarios.ToList();
        }
        public UsuarioModel BuscarPorId(int id)
        {
            return _dataContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {

            usuario.DataCadastro = DateTime.Now;
            _dataContext.Usuarios.Add(usuario);
            _dataContext.SaveChanges();
            return usuario;
        }
        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = BuscarPorId(usuario.Id);
            if (usuarioDb == null)
            {
                throw new Exception("Houve um erro na atualização do usuario.");
            }

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Login = usuario.Login;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Perfil = usuario.Perfil;
            usuarioDb.DataAtualizacao = DateTime.Now;

            _dataContext.Usuarios.Update(usuarioDb);
            _dataContext.SaveChanges();
            return usuarioDb;
        }

        public bool Deletar(int id)
        {
            UsuarioModel usuarioDb = BuscarPorId(id);
            if (usuarioDb == null)
            {
                throw new Exception("Houve um erro ao deletar o usuario.");
            }
            _dataContext.Usuarios.Remove(usuarioDb);
            _dataContext.SaveChanges();
            return true;

        }
    }
}

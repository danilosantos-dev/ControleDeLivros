using ListaDeLivros.Models;

namespace ListaDeLivros.Repository
{
    public interface IUsuarioRepository
    {
        List<UsuarioModel> BuscarTodos();
        UsuarioModel BuscarPorId(int id);
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        bool Deletar(int id);
    }
}

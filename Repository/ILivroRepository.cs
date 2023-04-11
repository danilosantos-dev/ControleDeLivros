using ListaDeLivros.Models;

namespace ListaDeLivros.Repository
{
    public interface ILivroRepository
    {
        List<LivroModel> BuscarTodos();
        LivroModel BuscarPorId(int id);
        LivroModel Adicionar(LivroModel livro); 
        LivroModel Atualizar(LivroModel livro);
        bool Deletar(int id);
    }
}

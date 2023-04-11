using ListaDeLivros.Data;
using ListaDeLivros.Models;

namespace ListaDeLivros.Repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly DataContext _dataContext;
        public LivroRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;            
        }
        public List<LivroModel> BuscarTodos()
        {
            return _dataContext.Livros.ToList();
        }
        public LivroModel BuscarPorId(int id)
        {
            return _dataContext.Livros.FirstOrDefault(x => x.Id == id);
        }

        public LivroModel Adicionar(LivroModel livro)
        {
            _dataContext.Livros.Add(livro);
            _dataContext.SaveChanges();
            return livro;
        }
        public LivroModel Atualizar(LivroModel livro)
        {
            LivroModel livroDb = BuscarPorId(livro.Id);
            if(livroDb == null)
            {
                throw new Exception("Houve um erro na atualização do livro.");
            }

            livroDb.NomeLivro = livro.NomeLivro;
            livroDb.NomeAutor = livro.NomeAutor;
            livroDb.Descricao = livro.Descricao;

            _dataContext.Livros.Update(livroDb);
            _dataContext.SaveChanges();
            return livroDb;

        
        }

        public bool Deletar(int id)
        {
            LivroModel livroDb = BuscarPorId(id);
            if (livroDb == null)
            {
                throw new Exception("Houve um erro na atualização do livro.");
            }
            _dataContext.Livros.Remove(livroDb);
            _dataContext.SaveChanges();
            return true;

        }
    }

}

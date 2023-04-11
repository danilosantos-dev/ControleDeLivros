using ListaDeLivros.Models;
using ListaDeLivros.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeLivros.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroRepository _livroRepository;
        public LivroController(ILivroRepository livroRepository)
        {
            _livroRepository= livroRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var livros = _livroRepository.BuscarTodos();
            return View(livros);
        }
     
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(LivroModel livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _livroRepository.Adicionar(livro);
                    TempData["MensagemSucesso"] = "Livro Cadastrado com Sucesso";
                    return RedirectToAction("Index");
                }



                return View(livro);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Falha ao cadastrar seu livro, tente novamente, detalhe do erro {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        public IActionResult Editar(int id)
        {
            LivroModel livro = _livroRepository.BuscarPorId(id);
            return View(livro);
        }

        [HttpPost]
        public IActionResult Atualizar(LivroModel livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _livroRepository.Atualizar(livro);
                    TempData["MensagemSucesso"] = "Seu livro foi atualizado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", livro);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao atualizar seu livro, erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Apagar(int id)
        {
            LivroModel livro = _livroRepository.BuscarPorId(id);
            return View(livro);
        }

        public IActionResult Deletar(int id)
        {
            try
            {
                _livroRepository.Deletar(id);
                TempData["MensagemSucesso"] = "Seu livro foi Deletado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao deletar este livro, erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}

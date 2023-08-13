using ListaDeLivros.Models;
using ListaDeLivros.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeLivros.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var usuarios = _usuarioRepository.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepository.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario Cadastrado com Sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Falha ao cadastrar seu usuario, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepository.BuscarPorId(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Atualizar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepository.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Seu usuario foi atualizado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao atualizar seu usuario, erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Apagar(int id)
        {
            UsuarioModel usuario = _usuarioRepository.BuscarPorId(id);
            return View(usuario);
        }

        [HttpDelete]

        public IActionResult Deletar(int id)
        {
            try
            {
                _usuarioRepository.Deletar(id);
                TempData["MensagemSucesso"] = "Seu contato foi Deletado com sucesso!";
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

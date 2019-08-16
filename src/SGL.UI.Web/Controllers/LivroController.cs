using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGL.ApplicationCore.Entity;
using SGL.ApplicationCore.Interfaces.Services;


namespace SGL.UI.Web.Controllers
{
    public class LivroController : Controller
    {
        private readonly IAppService<Livro> _livroService;
        private readonly IAppService<Autor> _autorService;
        private readonly IAppService<Editora> _editoraService;
        private readonly IAppService<Genero> _generoService;

        public LivroController(IAppService<Livro> livroService, 
            IAppService<Autor> autorService, 
            IAppService<Editora> editoraService,
            IAppService<Genero> generoService)
        {
            _livroService = livroService;
            _autorService = autorService;
            _editoraService = editoraService;
            _generoService = generoService;
        }

        public IActionResult Index()
        {
            var vm = _livroService.ObterTodos();
            return View(vm);
        }


        public IActionResult Buscar(string criterio = null)
        {


            var livros = _livroService
                .ObterTodos();

            if (!string.IsNullOrWhiteSpace(criterio))
            {

                livros =
                        _livroService
                        .Buscar(e =>
                                e.Titulo.ToUpper()
                                .Contains(criterio.ToUpper()) || e.Autor.Nome.ToUpper() .Contains(criterio.ToUpper())
                               );
            }

            return View("Index", livros);

        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = _livroService.ObterPorId(id.Value);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        public IActionResult Create()
        {
            ObterParaDropDowns();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Livro livro)
        {
            if (ModelState.IsValid)
            {
                _livroService.Adicionar(livro);
                return RedirectToAction(nameof(Index));
            }
            ObterParaDropDowns();
            return View(livro);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = _livroService.ObterPorId(id.GetValueOrDefault());
            if (livro == null)
            {
                return NotFound();
            }
            ObterParaDropDowns();
            return View(livro);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Livro livro)
        {
            if (id != livro.LivroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _livroService.Atualizar(livro);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.LivroId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ObterParaDropDowns();
            return View(livro);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = _livroService.ObterPorId(id.GetValueOrDefault());

            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var livro = _livroService.ObterPorId(id);
            _livroService.Remover(livro);
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id) {
            return _livroService.ObterTodos()
                            .Any(e => e.LivroId == id);
        }

        private void ObterParaDropDowns()
        {
            ViewData["AutorId"] = new SelectList(_autorService.ObterTodos(), "AutorId", "Nome");
            ViewData["EditoraId"] = new SelectList(_editoraService.ObterTodos(), "EditoraId", "Descricao");
            ViewData["GeneroId"] = new SelectList(_generoService.ObterTodos(), "GeneroId", "Descricao");
        }
    }
}

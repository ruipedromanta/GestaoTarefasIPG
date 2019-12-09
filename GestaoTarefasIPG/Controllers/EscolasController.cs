using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoTarefasIPG.Models;

namespace GestaoTarefasIPG.Controllers
{
    public class EscolasController : Controller
    {
        private readonly IPGDbContext _context;

        private const int NUMERO_ESCOLAS_POR_PAGINA = 2;
        private const int NUMERO_PAGINAS_ANTES_E_DEPOIS = 2;

        public EscolasController(IPGDbContext context)
        {
            _context = context;
        }

        // GET: Escolas
        public async Task<IActionResult> Index(int page = 1)
        {
            //return View(await _context.Escola.ToListAsync());
            decimal numeroEscolas = _context.Escola.Count();

            EscolasViewModel vm = new EscolasViewModel {
                Escolas = _context.Escola
                .OrderBy(p => p.NomeEscola)
                .Skip((page - 1) * NUMERO_ESCOLAS_POR_PAGINA)
                .Take(NUMERO_ESCOLAS_POR_PAGINA),

                CurrentPage = page,

                FirstPageShow = Math.Max(1, page - NUMERO_PAGINAS_ANTES_E_DEPOIS),

                TotalPages = (int)Math.Ceiling(numeroEscolas / NUMERO_ESCOLAS_POR_PAGINA)
            };

            vm.LastPageShow = Math.Min(vm.TotalPages, page + NUMERO_PAGINAS_ANTES_E_DEPOIS);

            return View(vm);
        }

        // GET: Escolas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escola = await _context.Escola
                .FirstOrDefaultAsync(m => m.EscolaId == id);
            if (escola == null)
            {
                return NotFound();
            }

            return View(escola);
        }

        // GET: Escolas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Escolas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EscolaId,NomeEscola,Telefone")] Escola escola)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escola);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));

                ViewBag.Title = "Escola adicionada com sucesso";
                ViewBag.Message = "Nova escola criada com sucesso";

                return View("Success");
            }
            return View(escola);
        }

        // GET: Escolas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escola = await _context.Escola.FindAsync(id);
            if (escola == null)
            {
                return NotFound();
            }
            return View(escola);
        }

        // POST: Escolas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EscolaId,NomeEscola,Telefone")] Escola escola)
        {
            if (id != escola.EscolaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escola);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscolaExists(escola.EscolaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));

                ViewBag.Title = "Escola editada com sucesso";
                ViewBag.Message = "A escola foi editada com sucesso";

                return View("Success");
            }
            return View(escola);
        }

        // GET: Escolas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escola = await _context.Escola
                .FirstOrDefaultAsync(m => m.EscolaId == id);
            if (escola == null)
            {
                return NotFound();
            }

            return View(escola);
        }

        // POST: Escolas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var escola = await _context.Escola.FindAsync(id);
            _context.Escola.Remove(escola);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

            ViewBag.Title = "Escola apagada com sucesso";
            ViewBag.Message = "A escola foi apagada com sucesso";

            return View("Success");
        }

        private bool EscolaExists(int id)
        {
            return _context.Escola.Any(e => e.EscolaId == id);
        }
    }
}

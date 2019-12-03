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
    public class DepartamentoController : Controller
    {
        private readonly IPGDbContext _context;

        public int PaginasTamanho = 5;

        public DepartamentoController(IPGDbContext context)
        {
            _context = context;
        }

        // GET: Departamento
        public IActionResult Index(int page = 1, string searchString = null) {
            var departamento = from p in _context.Departamento
                               select p;

            if(!String.IsNullOrEmpty(searchString)) {
                departamento = departamento.Where(p => p.NomeDepartamento.Contains(searchString));
            }



            decimal nuDepartamento = _context.Departamento.Count();
            int NUMERO_PAGINAS_ANTES_DEPOIS = ((int)nuDepartamento / PaginasTamanho);

            if (nuDepartamento % PaginasTamanho == 0) {
                NUMERO_PAGINAS_ANTES_DEPOIS -= 1;
            }

            DepartamentoVModel dp = new DepartamentoVModel {
                Departamento = departamento.OrderBy(p => p.NomeDepartamento).Skip((page -1) * PaginasTamanho).Take(PaginasTamanho),
                PagAtual = page,
                PriPagina = Math.Max(1, page - NUMERO_PAGINAS_ANTES_DEPOIS),
                TotPaginas = (int)Math.Ceiling(nuDepartamento / PaginasTamanho)
            };

            dp.UltPagina = Math.Min(dp.TotPaginas, page + NUMERO_PAGINAS_ANTES_DEPOIS);

            return View(dp);
        }

        // GET: Departamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamento
                .FirstOrDefaultAsync(m => m.DepartamentoId == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // GET: Departamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departamento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartamentoId,NomeDepartamento")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departamento);
                await _context.SaveChangesAsync();

                ViewBag.Title = "O Departamento foi adicionado com sucesso";
                ViewBag.Message = "O novo Departamento foi criado com sucesso";

                return View("Success");
            }
            return View(departamento);
        }

        // GET: Departamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamento.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }

        // POST: Departamento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartamentoId,NomeDepartamento")] Departamento departamento)
        {
            if (id != departamento.DepartamentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentoExists(departamento.DepartamentoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                ViewBag.Title = "O Departamento foi editado com sucesso";
                ViewBag.Message = "O novo Departamento foi editado com sucesso";

                return View("Success");

            }
            return View(departamento);
        }

        // GET: Departamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamento
                .FirstOrDefaultAsync(m => m.DepartamentoId == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // POST: Departamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departamento = await _context.Departamento.FindAsync(id);
            _context.Departamento.Remove(departamento);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            ViewBag.Title = "O Departamento foi apagado com sucesso";
            ViewBag.Message = "O novo Departamento foi apagado com sucesso";

            return View("Success");
        }

        private bool DepartamentoExists(int id)
        {
            return _context.Departamento.Any(e => e.DepartamentoId == id);
        }
    }
}

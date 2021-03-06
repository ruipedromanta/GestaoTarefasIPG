﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoTarefasIPG.Models;
using Microsoft.AspNetCore.Authorization;

namespace GestaoTarefasIPG.Controllers {
    public class EscolasController : Controller {
        private readonly IPGDbContext _context;

        private const int NUMERO_ESCOLAS_POR_PAGINA = 10;
        private const int NUMERO_PAGINAS_ANTES_E_DEPOIS = 2;

        public EscolasController(IPGDbContext context) {
            _context = context;
        }

        // GET: Escolas
        //public async Task<IActionResult> Index(int page = 1){

        //public IActionResult Index(int page=1, string searchString = null) {
        public async Task<IActionResult> Index(int page = 1, string searchString = "", string sort = "true") {
            var Escola = from p in _context.Escola select p;

            if (!String.IsNullOrEmpty(searchString)) {
                Escola = Escola.Where(p => p.NomeEscola.Contains(searchString));
            }


            //return View(await _context.Escola.ToListAsync());
            decimal numeroEscolas = _context.Escola.Count();

            EscolasViewModel vm = new EscolasViewModel {
                Sort = sort,

                CurrentPage = page,

                FirstPageShow = Math.Max(1, page - NUMERO_PAGINAS_ANTES_E_DEPOIS),

                TotalPages = (int)Math.Ceiling(numeroEscolas / NUMERO_ESCOLAS_POR_PAGINA)
            };

            if (sort.Equals("true")) {
                vm.Escolas = Escola.OrderBy(p => p.NomeEscola).Skip((page - 1) * NUMERO_ESCOLAS_POR_PAGINA).Take(NUMERO_ESCOLAS_POR_PAGINA);
            } else {
                vm.Escolas = Escola.OrderByDescending(p => p.NomeEscola).Skip((page - 1) * NUMERO_ESCOLAS_POR_PAGINA).Take(NUMERO_ESCOLAS_POR_PAGINA);
            }

            vm.StringProcura = searchString;

            vm.LastPageShow = Math.Min(vm.TotalPages, page + NUMERO_PAGINAS_ANTES_E_DEPOIS);

            return View(vm);
        }

        // GET: Escolas/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var escola = await _context.Escola
                .FirstOrDefaultAsync(m => m.EscolaId == id);
            if (escola == null) {
                return NotFound();
            }

            return View(escola);
        }

        // GET: Escolas/Create
        [Authorize(Policy = "Gerir")]

        public IActionResult Create() {
            return View();
        }

        // POST: Escolas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EscolaId,NomeEscola,Telefone")] Escola escola) {
            if (ModelState.IsValid) {

                if (_context.Escola.FirstOrDefault(p => p.NomeEscola == escola.NomeEscola) == null) {
                    _context.Add(escola);
                    
                 if   (_context.Escola.Select(p => p.Telefone == escola.Telefone) == null) {
                        _context.Add(escola);
                    }
                    await _context.SaveChangesAsync();
                    ViewBag.Title = "A Escola foi criada com sucesso";

                    return View("Success");
                } else {


                    ModelState.AddModelError("NomeEscola","Não é possível adicionar escolas com nomes repetidos.");
                    ModelState.AddModelError("Telefone", "Não é possível adicionar escolas com nomes repetidos.");
                    return View(escola);

                   


                }


            }
            return View(escola);
        }


        // GET: Escolas/Edit/5
        [Authorize(Policy = "Gerir")]
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var escola = await _context.Escola.FindAsync(id);
            if (escola == null) {
                return NotFound();
            }
            return View(escola);
        }

        // POST: Escolas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EscolaId,NomeEscola,Telefone")] Escola escola) {
            if (id != escola.EscolaId) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    if (_context.Escola.FirstOrDefault(p => p.NomeEscola == escola.NomeEscola) == null) {
                        _context.Update(escola);
                        await _context.SaveChangesAsync();
                        ViewBag.Title = "A Escola foi editada com sucesso";

                        return View("Success");
                    } else {
                        
                        ModelState.AddModelError("NomeEscola", "Não é possível adicionar escolas com nomes repetidos.");
                        return View(escola);
                        {

                        }
                       

                     
                    }
                } catch (DbUpdateConcurrencyException) {
                    if (!EscolaExists(escola.EscolaId)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));

                ViewBag.Title = "Escola editada com sucesso";
                //ViewBag.Message = "A escola foi editada com sucesso";

                return View("Success");
            }
            return View(escola);
        }

        // GET: Escolas/Delete/5
        [Authorize(Policy = "Gerir")]
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var escola = await _context.Escola
                .FirstOrDefaultAsync(m => m.EscolaId == id);
            if (escola == null) {
                return NotFound();
            }

            return View(escola);
        }

        // POST: Escolas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var escola = await _context.Escola.FindAsync(id);
            _context.Escola.Remove(escola);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

            ViewBag.Title = "Escola apagada com sucesso";
            //ViewBag.Message = "A escola foi apagada com sucesso";

            return View("Success");
        }

        private bool EscolaExists(int id) {
            return _context.Escola.Any(e => e.EscolaId == id);
        }
    }
}

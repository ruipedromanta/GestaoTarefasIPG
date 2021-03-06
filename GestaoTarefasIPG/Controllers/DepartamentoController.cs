﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoTarefasIPG.Models;
using Microsoft.AspNetCore.Authorization;


namespace GestaoTarefasIPG.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IPGDbContext _context;

        public int PaginasTamanho = 10;

        public DepartamentoController(IPGDbContext context)
        {
            _context = context;
        }

        // GET: Departamento
        public async Task<IActionResult> Index(int page =1, string searchString ="", string sort = "true" ) {
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
                Sort = sort,
                PagAtual = page,
                PriPagina = Math.Max(1, page - NUMERO_PAGINAS_ANTES_DEPOIS),
                TotPaginas = (int)Math.Ceiling(nuDepartamento / PaginasTamanho)
            };

            if (sort.Equals("true")) {
                dp.Departamento = departamento.OrderBy(p => p.NomeDepartamento).Skip((page - 1) * PaginasTamanho).Take(PaginasTamanho);
            } else {
                dp.Departamento = departamento.OrderByDescending(p => p.NomeDepartamento).Skip((page - 1) * PaginasTamanho).Take(PaginasTamanho); 
            }

            dp.UltPagina = Math.Min(dp.TotPaginas, page + NUMERO_PAGINAS_ANTES_DEPOIS);
            dp.StringProcura = searchString;


            //var IPGDbContext = _context.Departamento.Include(p => p.Escolas);
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
                //.Include(p => p.Escolas)
                .FirstOrDefaultAsync(m => m.DepartamentoId == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // GET: Departamento/Create
        [Authorize(Policy = "Gerir")]
        
        public IActionResult Create()
        {
           // ViewData["EscolaId"] = new SelectList(_context.Escola, "EscolaId", "NomeEscola", "Telefone");

            return View();
        }

        // POST: Departamento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("DepartamentoId,NomeDepartamento,EscolaId")] Departamento departamento) {
            if (ModelState.IsValid) {

                if (_context.Departamento.FirstOrDefault(p => p.NomeDepartamento == departamento.NomeDepartamento) == null) {
                    _context.Add(departamento);
                    await _context.SaveChangesAsync();
                    ViewBag.Title = "O Departamento foi criado com sucesso";
                    
                    return View("Success");
                } else {


                    ModelState.AddModelError("NomeDepartamento", "Não é possível adicionar nomes repetidos.");
                   // ViewData["EscolaId"] = new SelectList(_context.Escola, "EscolaId", "NomeEscola", "Telefone", departamento.EscolaId);
                    return View(departamento);


                }
             }
            

            var NomeDepartamento = _context.Departamento
                .FirstOrDefault(p => p.NomeDepartamento == departamento.NomeDepartamento);

            //ViewData["EscolaId"] = new SelectList(_context.Escola, "EscolaId", "NomeEscola", "Telefone");
            return View(departamento);
        

            
        }

        // GET: Departamento/Edit/5
        [Authorize(Policy = "Gerir")]
        
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
            //ViewData["EscolaId"] = new SelectList(_context.Escola, "EscolaId", "NomeEscola", "Telefone");
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
                try {
                    if (_context.Departamento.FirstOrDefault(p => p.NomeDepartamento == departamento.NomeDepartamento) == null) {
                        _context.Update(departamento);
                        await _context.SaveChangesAsync();
                        ViewBag.Title = "O Departamento foi editado com sucesso";

                        return View("Success");
                    } else {
                       
                        ModelState.AddModelError("NomeDepartamento", "Não é possível adicionar departamentos com nomes repetidos.");
                        return View(departamento);
                        {

                        }
                    ViewBag.Title = "O Departamento foi editado com sucesso";

                        return View("Edit");
                    }
                } catch (DbUpdateConcurrencyException) {
                    if (!DepartamentoExists(departamento.DepartamentoId)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                
               

            }
            ViewData["EscolaId"] = new SelectList(_context.Escola, "EscolaId", "NomeEscola", "Telefone");
            return View(departamento);
        }

        // GET: Departamento/Delete/5
        [Authorize(Policy = "Gerir")]
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamento
                //.Include(p => p.Escolas)
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
            ViewBag.Title = "O Departamento foi apagado com sucesso";
            

            return View("Success");
        }

        private bool DepartamentoExists(int id)
        {
            return _context.Departamento.Any(e => e.DepartamentoId == id);
        }
    }
}

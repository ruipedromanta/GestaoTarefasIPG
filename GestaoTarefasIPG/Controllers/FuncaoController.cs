﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoTarefasIPG.Models;

namespace GestaoTarefasIPG.Controllers
{
    public class FuncaoController : Controller
    {
        private readonly IPGDbContext _context;

        public FuncaoController(IPGDbContext context)
        {
            _context = context;
        }

        // GET: Funcao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Funcao.ToListAsync());
        }

        // GET: Funcao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcao = await _context.Funcao
                .FirstOrDefaultAsync(m => m.FuncaoId == id);
            if (funcao == null)
            {
                return NotFound();
            }

            return View(funcao);
        }

        // GET: Funcao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FuncaoId,NomeFuncao")] Funcao funcao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcao);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));

                ViewBag.Title = "Funcao adicionada com sucesso";
                ViewBag.Message = "Nova funcao criada com sucesso";

                return View("Success");
            }
            return View(funcao);
        }

        // GET: Funcao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcao = await _context.Funcao.FindAsync(id);
            if (funcao == null)
            {
                return NotFound();
            }
            return View(funcao);
        }

        // POST: Funcao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FuncaoId,NomeFuncao")] Funcao funcao)
        {
            if (id != funcao.FuncaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncaoExists(funcao.FuncaoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));

                ViewBag.Title = "Funcao editada com sucesso";
                ViewBag.Message = "A Funcao foi editada com sucesso";

                return View("Success");
            }
            return View(funcao);
        }

        // GET: Funcao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcao = await _context.Funcao
                .FirstOrDefaultAsync(m => m.FuncaoId == id);
            if (funcao == null)
            {
                return NotFound();
            }

            return View(funcao);
        }

        // POST: Funcao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcao = await _context.Funcao.FindAsync(id);
            _context.Funcao.Remove(funcao);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

            ViewBag.Title = "Funcao apagada com sucesso";
            ViewBag.Message = "A funcao foi apagada com sucesso";

            return View("Success");
        }

        private bool FuncaoExists(int id)
        {
            return _context.Funcao.Any(e => e.FuncaoId == id);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PontoId_API.Context;
using PontoId_API.Models;

namespace PontoId_API.Controllers
{
    public class EscolasController : Controller
    {
        private readonly AppDbContext _context;

        public EscolasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Escolas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Escolas.ToListAsync());
        }

        // GET: Escolas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Escolas == null)
            {
                return NotFound();
            }

            var escola = await _context.Escolas
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EscolaId,NomeEscola,BairroEscola,CidadeEscola,EstadoEscola,CepEscola,ComplementoEscola,TelefoneEscola,LogoEscola")] Escola escola)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escola);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(escola);
        }

        // GET: Escolas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Escolas == null)
            {
                return NotFound();
            }

            var escola = await _context.Escolas.FindAsync(id);
            if (escola == null)
            {
                return NotFound();
            }
            return View(escola);
        }

        // POST: Escolas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EscolaId,NomeEscola,BairroEscola,CidadeEscola,EstadoEscola,CepEscola,ComplementoEscola,TelefoneEscola,LogoEscola")] Escola escola)
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
                return RedirectToAction(nameof(Index));
            }
            return View(escola);
        }

        // GET: Escolas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Escolas == null)
            {
                return NotFound();
            }

            var escola = await _context.Escolas
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
            if (_context.Escolas == null)
            {
                return Problem("Entity set 'AppDbContext.Escolas'  is null.");
            }
            var escola = await _context.Escolas.FindAsync(id);
            if (escola != null)
            {
                _context.Escolas.Remove(escola);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscolaExists(int id)
        {
          return _context.Escolas.Any(e => e.EscolaId == id);
        }
    }
}

using System;
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
    public class TurmasController : Controller
    {
        private readonly AppDbContext _context;

        public TurmasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Turmas
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Turmas.Include(t => t.Escola);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Turmas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Turmas == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas
                .Include(t => t.Escola)
                .FirstOrDefaultAsync(m => m.TurmaId == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        // GET: Turmas/Create
        public IActionResult Create()
        {
            ViewBag.NomeEscola = new SelectList(_context.Escolas, "EscolaId", "NomeEscola");
            return View();
        }

        // POST: Turmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TurmaId,TurmaNumero,PeriodoAula,EscolaId,QuantidadeAlunos")] Turma turma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.NomeEscola = new SelectList(_context.Escolas, "EscolaId", "NomeEscola", turma.EscolaId);
            return View(turma);
        }

        // GET: Turmas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Turmas == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas.FindAsync(id);
            var escola = await _context.Escolas.FindAsync(turma.EscolaId);
            if (turma == null)
            {
                return NotFound();
            }
            ViewBag.NomeEscola = new SelectList(_context.Escolas, "EscolaId", "NomeEscola", escola.NomeEscola);
            return View(turma);
        }

        // POST: Turmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TurmaId,TurmaNumero,PeriodoAula,EscolaId,QuantidadeAlunos")] Turma turma)
        {
            if (id != turma.TurmaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmaExists(turma.TurmaId))
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
            ViewData["EscolaId"] = new SelectList(_context.Escolas, "EscolaId", "BairroEscola", turma.EscolaId);
            return View(turma);
        }

        // GET: Turmas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Turmas == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas
                .Include(t => t.Escola)
                .FirstOrDefaultAsync(m => m.TurmaId == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        // POST: Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Turmas == null)
            {
                return Problem("Entity set 'AppDbContext.Turmas'  is null.");
            }
            var turma = await _context.Turmas.FindAsync(id);
            if (turma != null)
            {
                _context.Turmas.Remove(turma);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurmaExists(int id)
        {
          return _context.Turmas.Any(e => e.TurmaId == id);
        }
    }
}

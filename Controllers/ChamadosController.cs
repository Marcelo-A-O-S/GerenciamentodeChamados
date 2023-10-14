using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using gerenciamentodechamados.Models;
using gerenciamentodechamados.Context;

namespace gerenciamentodechamados.Controllers
{
    public class ChamadosController : Controller
    {
        private readonly AppDbContext _context;

        public ChamadosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Chamadoes
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Chamadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.chamados == null)
            {
                return NotFound();
            }

            var chamado = await _context.chamados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chamado == null)
            {
                return NotFound();
            }

            return View(chamado);
        }

        // GET: Chamadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chamadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Tecnico,dataDeVencimento,nivelPrioridade,status,notas,dataDeConclusao,tipoDeManutenção")] Chamado _chamado)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(_chamado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return BadRequest("Erro nos dados!");
        }

        // GET: Chamadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.chamados == null)
            {
                return NotFound();
            }

            var chamado = await _context.chamados.FindAsync(id);
            if (chamado == null)
            {
                return NotFound();
            }
            return View(chamado);
        }

        // POST: Chamadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Tecnico,dataDeVencimento,nivelPrioridade,status,notas,dataDeConclusao,tipoDeManutenção")] Chamado chamado)
        {
            if (id != chamado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chamado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChamadoExists(chamado.Id))
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
            return View(chamado);
        }

        // GET: Chamadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.chamados == null)
            {
                return NotFound();
            }

            var chamado = await _context.chamados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chamado == null)
            {
                return NotFound();
            }

            return View(chamado);
        }

        // POST: Chamadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.chamados == null)
            {
                return Problem("Entity set 'AppDbContext.chamados'  is null.");
            }
            var chamado = await _context.chamados.FindAsync(id);
            if (chamado != null)
            {
                _context.chamados.Remove(chamado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChamadoExists(int id)
        {
          return (_context.chamados?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> List()
        {
            var list = _context.chamados.ToList();
            return View(list);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestorEquipamentos.DataBase;
using GestorEquipamentos.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace GestorEquipamentos.Controllers
{
    [Authorize]
    public class ReservaController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;        

        public ReservaController(AppDbContext context)
        {
            _context = context;
        }
                
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            return View(await _context.ReservaModel.Where(r => r.UsuarioId == userId).ToListAsync());
        }

        // GET: Reserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var reservaModel = await _context.ReservaModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservaModel == null)
            {
                return NotFound();
            }

            return View(reservaModel);
        }

        // GET: Reserva/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,ProdutoId,Status,DataSolicitacao,DataInicio,DataTermino")] ReservaModel reservaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservaModel);
        }

        // GET: Reserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaModel = await _context.ReservaModel.FindAsync(id);
            if (reservaModel == null)
            {
                return NotFound();
            }
            return View(reservaModel);
        }

        // POST: Reserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,ProdutoId,Status,DataSolicitacao,DataInicio,DataTermino")] ReservaModel reservaModel)
        {
            if (id != reservaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaModelExists(reservaModel.Id))
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
            return View(reservaModel);
        }

        // GET: Reserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaModel = await _context.ReservaModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservaModel == null)
            {
                return NotFound();
            }

            return View(reservaModel);
        }

        // POST: Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservaModel = await _context.ReservaModel.FindAsync(id);
            if (reservaModel != null)
            {
                _context.ReservaModel.Remove(reservaModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaModelExists(int id)
        {
            return _context.ReservaModel.Any(e => e.Id == id);
        }
    }
}

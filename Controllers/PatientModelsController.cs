using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniHospitalProject.Data;
using MiniHospitalProject.Models;

namespace MiniHospitalProject.Controllers
{
    public class PatientModelsController : Controller
    {
        private readonly MiniHospitalProjectContext _context;

        public PatientModelsController(MiniHospitalProjectContext context)
        {
            _context = context;
        }

        // GET: PatientModels
        public async Task<IActionResult> Index()
        {
              return _context.PatientTBL != null ? 
                          View(await _context.PatientTBL.ToListAsync()) :
                          Problem("Entity set 'MiniHospitalProjectContext.PatientTBL'  is null.");
        }

        // GET: PatientModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PatientTBL == null)
            {
                return NotFound();
            }

            var patientModel = await _context.PatientTBL
                .FirstOrDefaultAsync(m => m.PId == id);
            if (patientModel == null)
            {
                return NotFound();
            }

            return View(patientModel);
        }

        // GET: PatientModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PId,PatientFirstName,PatientLastName,PatientHistory,Contact,PatientAddress")] PatientModel patientModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientModel);
        }

        // GET: PatientModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PatientTBL == null)
            {
                return NotFound();
            }

            var patientModel = await _context.PatientTBL.FindAsync(id);
            if (patientModel == null)
            {
                return NotFound();
            }
            return View(patientModel);
        }

        // POST: PatientModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PId,PatientFirstName,PatientLastName,PatientHistory,Contact,PatientAddress")] PatientModel patientModel)
        {
            if (id != patientModel.PId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientModelExists(patientModel.PId))
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
            return View(patientModel);
        }

        // GET: PatientModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PatientTBL == null)
            {
                return NotFound();
            }

            var patientModel = await _context.PatientTBL
                .FirstOrDefaultAsync(m => m.PId == id);
            if (patientModel == null)
            {
                return NotFound();
            }

            return View(patientModel);
        }

        // POST: PatientModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PatientTBL == null)
            {
                return Problem("Entity set 'MiniHospitalProjectContext.PatientTBL'  is null.");
            }
            var patientModel = await _context.PatientTBL.FindAsync(id);
            if (patientModel != null)
            {
                _context.PatientTBL.Remove(patientModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientModelExists(int id)
        {
          return (_context.PatientTBL?.Any(e => e.PId == id)).GetValueOrDefault();
        }
    }
}

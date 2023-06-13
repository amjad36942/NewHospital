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
    public class DepartmentModelsController : Controller
    {
        private readonly MiniHospitalProjectContext _context;

        public DepartmentModelsController(MiniHospitalProjectContext context)
        {
            _context = context;
        }

        // GET: DepartmentModels
        public async Task<IActionResult> Index()
        {
              return _context.DepartmentTBL != null ? 
                          View(await _context.DepartmentTBL.ToListAsync()) :
                          Problem("Entity set 'MiniHospitalProjectContext.DepartmentTBL'  is null.");
        }

        // GET: DepartmentModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DepartmentTBL == null)
            {
                return NotFound();
            }

            var departmentModel = await _context.DepartmentTBL
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (departmentModel == null)
            {
                return NotFound();
            }

            return View(departmentModel);
        }

        // GET: DepartmentModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DepartmentModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentId,DepartmentName")] DepartmentModel departmentModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departmentModel);
        }

        // GET: DepartmentModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DepartmentTBL == null)
            {
                return NotFound();
            }

            var departmentModel = await _context.DepartmentTBL.FindAsync(id);
            if (departmentModel == null)
            {
                return NotFound();
            }
            return View(departmentModel);
        }

        // POST: DepartmentModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentId,DepartmentName")] DepartmentModel departmentModel)
        {
            if (id != departmentModel.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentModelExists(departmentModel.DepartmentId))
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
            return View(departmentModel);
        }

        // GET: DepartmentModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DepartmentTBL == null)
            {
                return NotFound();
            }

            var departmentModel = await _context.DepartmentTBL
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (departmentModel == null)
            {
                return NotFound();
            }

            return View(departmentModel);
        }

        // POST: DepartmentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DepartmentTBL == null)
            {
                return Problem("Entity set 'MiniHospitalProjectContext.DepartmentTBL'  is null.");
            }
            var departmentModel = await _context.DepartmentTBL.FindAsync(id);
            if (departmentModel != null)
            {
                _context.DepartmentTBL.Remove(departmentModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentModelExists(int id)
        {
          return (_context.DepartmentTBL?.Any(e => e.DepartmentId == id)).GetValueOrDefault();
        }
    }
}

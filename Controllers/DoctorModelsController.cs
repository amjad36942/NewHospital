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
    public class DoctorModelsController : Controller
    {
        private readonly MiniHospitalProjectContext _context;

        public DoctorModelsController(MiniHospitalProjectContext context)
        {
            _context = context;
        }

        // GET: DoctorModels
        public async Task<IActionResult> Index()
        {
            var miniHospitalProjectContext = _context.DoctorTBL.Include(d => d.Department);
            return View(await miniHospitalProjectContext.ToListAsync());
        }

        // GET: DoctorModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DoctorTBL == null)
            {
                return NotFound();
            }

            var doctorModel = await _context.DoctorTBL
                .Include(d => d.Department)
                .FirstOrDefaultAsync(m => m.DoctorId == id);
            if (doctorModel == null)
            {
                return NotFound();
            }

            return View(doctorModel);
        }

        // GET: DoctorModels/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.DepartmentTBL, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: DoctorModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoctorId,DoctorFirstName,DoctorLastName,Contact,Email,Fees,DepartmentId")] DoctorModel doctorModel)
        {
            
           
                _context.Add(doctorModel);
                await _context.SaveChangesAsync();
               
                return RedirectToAction(nameof(Index));
          
           // ViewData["DepartmentId"] = new SelectList(_context.DepartmentTBL, "DepartmentId", "DepartmentName", doctorModel.DepartmentId);
         
        }

        // GET: DoctorModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DoctorTBL == null)
            {
                return NotFound();
            }

            var doctorModel = await _context.DoctorTBL.FindAsync(id);
            if (doctorModel == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.DepartmentTBL, "DepartmentId", "DepartmentName", doctorModel.DepartmentId);
            return View(doctorModel);
        }

        // POST: DoctorModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoctorId,DoctorFirstName,DoctorLastName,Contact,Email,Fees,DepartmentId")] DoctorModel doctorModel)
        {
            if (id != doctorModel.DoctorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorModelExists(doctorModel.DoctorId))
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
            ViewData["DepartmentId"] = new SelectList(_context.DepartmentTBL, "DepartmentId", "DepartmentName", doctorModel.DepartmentId);
            return View(doctorModel);
        }

        // GET: DoctorModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DoctorTBL == null)
            {
                return NotFound();
            }

            var doctorModel = await _context.DoctorTBL
                .Include(d => d.Department)
                .FirstOrDefaultAsync(m => m.DoctorId == id);
            if (doctorModel == null)
            {
                return NotFound();
            }

            return View(doctorModel);
        }

        // POST: DoctorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DoctorTBL == null)
            {
                return Problem("Entity set 'MiniHospitalProjectContext.DoctorTBL'  is null.");
            }
            var doctorModel = await _context.DoctorTBL.FindAsync(id);
            if (doctorModel != null)
            {
                _context.DoctorTBL.Remove(doctorModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorModelExists(int id)
        {
          return (_context.DoctorTBL?.Any(e => e.DoctorId == id)).GetValueOrDefault();
        }
    }
}

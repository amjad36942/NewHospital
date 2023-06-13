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
    public class DoctorDaysModelsController : Controller
    {
        private readonly MiniHospitalProjectContext _context;

        public DoctorDaysModelsController(MiniHospitalProjectContext context)
        {
            _context = context;
        }

        // GET: DoctorDaysModels
        public async Task<IActionResult> Index()
        {
              return _context.DoctorDaysTBL != null ? 
                          View(await _context.DoctorDaysTBL.ToListAsync()) :
                          Problem("Entity set 'MiniHospitalProjectContext.DoctorDaysTBL'  is null.");
        }

        // GET: DoctorDaysModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DoctorDaysTBL == null)
            {
                return NotFound();
            }

            var doctorDaysModel = await _context.DoctorDaysTBL
                .FirstOrDefaultAsync(m => m.ScheduleId == id);
            if (doctorDaysModel == null)
            {
                return NotFound();
            }

            return View(doctorDaysModel);
        }

        // GET: DoctorDaysModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoctorDaysModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScheduleId,DoctorDay,TimeSlot,DoctorDate,Isavailable,DoctorFirstName,DoctorLastName")] DoctorDaysModel doctorDaysModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctorDaysModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctorDaysModel);
        }

        // GET: DoctorDaysModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DoctorDaysTBL == null)
            {
                return NotFound();
            }

            var doctorDaysModel = await _context.DoctorDaysTBL.FindAsync(id);
            if (doctorDaysModel == null)
            {
                return NotFound();
            }
            return View(doctorDaysModel);
        }

        // POST: DoctorDaysModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScheduleId,DoctorDay,TimeSlot,DoctorDate,Isavailable,DoctorFirstName,DoctorLastName")] DoctorDaysModel doctorDaysModel)
        {
            if (id != doctorDaysModel.ScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorDaysModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorDaysModelExists(doctorDaysModel.ScheduleId))
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
            return View(doctorDaysModel);
        }

        // GET: DoctorDaysModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DoctorDaysTBL == null)
            {
                return NotFound();
            }

            var doctorDaysModel = await _context.DoctorDaysTBL
                .FirstOrDefaultAsync(m => m.ScheduleId == id);
            if (doctorDaysModel == null)
            {
                return NotFound();
            }

            return View(doctorDaysModel);
        }

        // POST: DoctorDaysModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DoctorDaysTBL == null)
            {
                return Problem("Entity set 'MiniHospitalProjectContext.DoctorDaysTBL'  is null.");
            }
            var doctorDaysModel = await _context.DoctorDaysTBL.FindAsync(id);
            if (doctorDaysModel != null)
            {
                _context.DoctorDaysTBL.Remove(doctorDaysModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorDaysModelExists(int id)
        {
          return (_context.DoctorDaysTBL?.Any(e => e.ScheduleId == id)).GetValueOrDefault();
        }
    }
}

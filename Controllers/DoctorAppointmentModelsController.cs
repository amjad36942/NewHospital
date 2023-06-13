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
    public class DoctorAppointmentModelsController : Controller
    {
        private readonly MiniHospitalProjectContext _context;

        public DoctorAppointmentModelsController(MiniHospitalProjectContext context)
        {
            _context = context;
        }

        // GET: DoctorAppointmentModels
        public async Task<IActionResult> Index()
        {
              return _context.doctorAppointmentTBL != null ? 
                          View(await _context.doctorAppointmentTBL.ToListAsync()) :
                          Problem("Entity set 'MiniHospitalProjectContext.doctorAppointmentTBL'  is null.");
        }

        // GET: DoctorAppointmentModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.doctorAppointmentTBL == null)
            {
                return NotFound();
            }

            var doctorAppointmentModel = await _context.doctorAppointmentTBL
                .FirstOrDefaultAsync(m => m.AppId == id);
            if (doctorAppointmentModel == null)
            {
                return NotFound();
            }

            return View(doctorAppointmentModel);
        }

        // GET: DoctorAppointmentModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoctorAppointmentModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppId,AppointmentDay,AppointmentDate,PId,DepartmentId,DocId,TotalFee")] DoctorAppointmentModel doctorAppointmentModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctorAppointmentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctorAppointmentModel);
        }

        // GET: DoctorAppointmentModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.doctorAppointmentTBL == null)
            {
                return NotFound();
            }

            var doctorAppointmentModel = await _context.doctorAppointmentTBL.FindAsync(id);
            if (doctorAppointmentModel == null)
            {
                return NotFound();
            }
            return View(doctorAppointmentModel);
        }

        // POST: DoctorAppointmentModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppId,AppointmentDay,AppointmentDate,PId,DepartmentId,DocId,TotalFee")] DoctorAppointmentModel doctorAppointmentModel)
        {
            if (id != doctorAppointmentModel.AppId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorAppointmentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorAppointmentModelExists(doctorAppointmentModel.AppId))
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
            return View(doctorAppointmentModel);
        }

        // GET: DoctorAppointmentModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.doctorAppointmentTBL == null)
            {
                return NotFound();
            }

            var doctorAppointmentModel = await _context.doctorAppointmentTBL
                .FirstOrDefaultAsync(m => m.AppId == id);
            if (doctorAppointmentModel == null)
            {
                return NotFound();
            }

            return View(doctorAppointmentModel);
        }

        // POST: DoctorAppointmentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.doctorAppointmentTBL == null)
            {
                return Problem("Entity set 'MiniHospitalProjectContext.doctorAppointmentTBL'  is null.");
            }
            var doctorAppointmentModel = await _context.doctorAppointmentTBL.FindAsync(id);
            if (doctorAppointmentModel != null)
            {
                _context.doctorAppointmentTBL.Remove(doctorAppointmentModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorAppointmentModelExists(int id)
        {
          return (_context.doctorAppointmentTBL?.Any(e => e.AppId == id)).GetValueOrDefault();
        }
    }
}

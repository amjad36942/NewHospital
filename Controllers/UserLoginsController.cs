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
    public class UserLoginsController : Controller
    {
        private readonly MiniHospitalProjectContext _context;

        public UserLoginsController(MiniHospitalProjectContext context)
        {
            _context = context;
        }

        // GET: UserLogins
        public IActionResult UserLog()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserLog(UserLoginModel user)
        {

           

                var user1 = _context.UserLoginTBL.Where(x => x.UserEmail == user.UserEmail && x.Password == user.Password).SingleOrDefault();
                ViewBag.role = user1.role;

                if (user1 != null)
                {

                    if (ViewBag.role == "admin")
                    {

                 //   HttpContext.Session.SetString("Role", "admin");
                        return RedirectToAction("Index", "Home");
                    }

                    else if (ViewBag.role == "Patient")
                    {

                  //  HttpContext.Session.SetString("Role", "Patient");
                        return RedirectToAction("Patient", "Home");
                    }
                else if (ViewBag.role == "Doctor")
                {

                  //  HttpContext.Session.SetString("Role", "Doctor");
                    return RedirectToAction("Doctor", "Home");
                }

                else
                    {
                       

                        return RedirectToAction("Index", "Home");
                    }

                

             

            }

            return View();
        }
        public IActionResult MainPage()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
              return _context.UserLoginTBL != null ? 
                          View(await _context.UserLoginTBL.ToListAsync()) :
                          Problem("Entity set 'MiniHospitalProjectContext.UserLoginTBL'  is null.");
        }

        // GET: UserLogins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserLoginTBL == null)
            {
                return NotFound();
            }

            var userLoginModel = await _context.UserLoginTBL
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userLoginModel == null)
            {
                return NotFound();
            }

            return View(userLoginModel);
        }

        // GET: UserLogins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserLogins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserName,UserEmail,Password,role")] UserLoginModel userLoginModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userLoginModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userLoginModel);
        }

        // GET: UserLogins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserLoginTBL == null)
            {
                return NotFound();
            }

            var userLoginModel = await _context.UserLoginTBL.FindAsync(id);
            if (userLoginModel == null)
            {
                return NotFound();
            }
            return View(userLoginModel);
        }

        // POST: UserLogins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserName,UserEmail,Password,role")] UserLoginModel userLoginModel)
        {
            if (id != userLoginModel.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userLoginModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserLoginModelExists(userLoginModel.UserId))
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
            return View(userLoginModel);
        }

        // GET: UserLogins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserLoginTBL == null)
            {
                return NotFound();
            }

            var userLoginModel = await _context.UserLoginTBL
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userLoginModel == null)
            {
                return NotFound();
            }

            return View(userLoginModel);
        }

        // POST: UserLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserLoginTBL == null)
            {
                return Problem("Entity set 'MiniHospitalProjectContext.UserLoginTBL'  is null.");
            }
            var userLoginModel = await _context.UserLoginTBL.FindAsync(id);
            if (userLoginModel != null)
            {
                _context.UserLoginTBL.Remove(userLoginModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserLoginModelExists(int id)
        {
          return (_context.UserLoginTBL?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}

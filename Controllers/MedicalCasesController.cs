using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MedicalCasesController : Controller
    {
        private readonly ApplicationContext _context;

        public MedicalCasesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: MedicalCases
        public async Task<IActionResult> Index()
        {
            return View(await _context.MedicalCases.ToListAsync());
        }

        // GET: MedicalCases/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalCase = await _context.MedicalCases
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalCase == null)
            {
                return NotFound();
            }

            return View(medicalCase);
        }

        // GET: MedicalCases/Create
        public IActionResult Create()
        {
            ViewData["StatusList"] = new SelectList(Enum.GetValues(typeof(MedicalCaseStatus)));
            return View();
        }

        // POST: MedicalCases/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MedicalCase medicalCase)
        {
            if (ModelState.IsValid)
            {
                medicalCase.Id = Guid.NewGuid();
                medicalCase.CreatedAt = DateTime.UtcNow;
                medicalCase.UpdatedAt = DateTime.UtcNow;

                _context.Add(medicalCase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["StatusList"] = new SelectList(Enum.GetValues(typeof(MedicalCaseStatus)));
            return View(medicalCase);
        }

        // GET: MedicalCases/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalCase = await _context.MedicalCases.FindAsync(id);
            if (medicalCase == null)
            {
                return NotFound();
            }
            return View(medicalCase);
        }

        // POST: MedicalCases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PatientId,DoctorId,OpeningDate,ClosingDate,Status,CreatedAt,UpdatedAt")] MedicalCase medicalCase)
        {
            if (id != medicalCase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalCase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalCaseExists(medicalCase.Id))
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
            return View(medicalCase);
        }

        // GET: MedicalCases/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalCase = await _context.MedicalCases
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalCase == null)
            {
                return NotFound();
            }

            return View(medicalCase);
        }

        // POST: MedicalCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var medicalCase = await _context.MedicalCases.FindAsync(id);
            if (medicalCase != null)
            {
                _context.MedicalCases.Remove(medicalCase);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalCaseExists(Guid id)
        {
            return _context.MedicalCases.Any(e => e.Id == id);
        }
    }
}

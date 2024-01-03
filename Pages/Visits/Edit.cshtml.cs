using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectSemestru.Data;
using ProiectSemestru.Models;

namespace ProiectSemestru.Pages.Visits
{
    public class EditModel : PageModel
    {
        private readonly ProiectSemestru.Data.ProiectSemestruContext _context;

        public EditModel(ProiectSemestru.Data.ProiectSemestruContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Visit Visit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Visit == null)
            {
                return NotFound();
            }

            var visit =  await _context.Visit.FirstOrDefaultAsync(m => m.Id == id);
            if (visit == null)
            {
                return NotFound();
            }
            Visit = visit;
               ViewData["ConsultationID"] = new SelectList(_context.Consultation, "Id", "name");
               ViewData["PatientID"] = new SelectList(_context.Patient, "Id", "firstName");
               ViewData["DoctorID"] = new SelectList(_context.Doctor, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Visit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitExists(Visit.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VisitExists(int id)
        {
          return (_context.Visit?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

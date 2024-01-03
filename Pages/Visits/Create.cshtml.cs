using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectSemestru.Data;
using ProiectSemestru.Models;

namespace ProiectSemestru.Pages.Visits
{
    public class CreateModel : PageModel
    {
        private readonly ProiectSemestru.Data.ProiectSemestruContext _context;

        public CreateModel(ProiectSemestru.Data.ProiectSemestruContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ConsultationID"] = new SelectList(_context.Consultation, "Id", "name");
            ViewData["PatientID"] = new SelectList(_context.Patient, "Id", "firstName");
            ViewData["DoctorID"] = new SelectList(_context.Doctor, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Visit Visit { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Visit == null || Visit == null)
            {
                return Page();
            }

            _context.Visit.Add(Visit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

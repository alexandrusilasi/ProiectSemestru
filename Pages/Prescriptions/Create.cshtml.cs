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

namespace ProiectSemestru.Pages.Prescriptions
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
            ViewData["VisitID"] = new SelectList(_context.Visit.Include(v => v.Patient), "Id", "DisplayInfo");
            return Page();
        }

        [BindProperty]
        public Prescription Prescription { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Prescription == null || Prescription == null)
            {
                return Page();
            }

            _context.Prescription.Add(Prescription);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

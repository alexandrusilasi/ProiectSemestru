using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectSemestru.Data;
using ProiectSemestru.Models;

namespace ProiectSemestru.Pages.Consultations
{
    public class DeleteModel : PageModel
    {
        private readonly ProiectSemestru.Data.ProiectSemestruContext _context;

        public DeleteModel(ProiectSemestru.Data.ProiectSemestruContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Consultation Consultation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Consultation == null)
            {
                return NotFound();
            }

            var consultation = await _context.Consultation.FirstOrDefaultAsync(m => m.Id == id);

            if (consultation == null)
            {
                return NotFound();
            }
            else 
            {
                Consultation = consultation;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Consultation == null)
            {
                return NotFound();
            }
            var consultation = await _context.Consultation.FindAsync(id);

            if (consultation != null)
            {
                Consultation = consultation;
                _context.Consultation.Remove(Consultation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

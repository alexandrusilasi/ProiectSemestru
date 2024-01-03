using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectSemestru.Data;
using ProiectSemestru.Models;

namespace ProiectSemestru.Pages.Visits
{
    public class DeleteModel : PageModel
    {
        private readonly ProiectSemestru.Data.ProiectSemestruContext _context;

        public DeleteModel(ProiectSemestru.Data.ProiectSemestruContext context)
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

            var visit = await _context.Visit.FirstOrDefaultAsync(m => m.Id == id);

            if (visit == null)
            {
                return NotFound();
            }
            else 
            {
                Visit = visit;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Visit == null)
            {
                return NotFound();
            }
            var visit = await _context.Visit.FindAsync(id);

            if (visit != null)
            {
                Visit = visit;
                _context.Visit.Remove(Visit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

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
    public class DetailsModel : PageModel
    {
        private readonly ProiectSemestru.Data.ProiectSemestruContext _context;

        public DetailsModel(ProiectSemestru.Data.ProiectSemestruContext context)
        {
            _context = context;
        }

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
    }
}

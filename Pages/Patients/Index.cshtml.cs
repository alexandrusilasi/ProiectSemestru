using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectSemestru.Data;
using ProiectSemestru.Models;

namespace ProiectSemestru.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly ProiectSemestru.Data.ProiectSemestruContext _context;

        public IndexModel(ProiectSemestru.Data.ProiectSemestruContext context)
        {
            _context = context;
        }

        public IList<Patient> Patient { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Patient != null)
            {
                Patient = await _context.Patient.ToListAsync();
            }
        }
    }
}

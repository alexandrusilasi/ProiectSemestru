﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly ProiectSemestru.Data.ProiectSemestruContext _context;

        public IndexModel(ProiectSemestru.Data.ProiectSemestruContext context)
        {
            _context = context;
        }

        public IList<Visit> Visit { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Visit != null)
            {
                Visit = await _context.Visit
                .Include(v => v.Consultation)
                .Include(v => v.Doctor)
                .Include(v => v.Patient).ToListAsync();
            }
        }
    }
}

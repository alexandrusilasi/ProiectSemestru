﻿using System;
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
    public class EditModel : PageModel
    {
        private readonly ProiectSemestru.Data.ProiectSemestruContext _context;

        public EditModel(ProiectSemestru.Data.ProiectSemestruContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Prescription Prescription { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Prescription == null)
            {
                return NotFound();
            }

            var prescription =  await _context.Prescription.FirstOrDefaultAsync(m => m.Id == id);
            if (prescription == null)
            {
                return NotFound();
            }
            Prescription = prescription;
           ViewData["VisitID"] = new SelectList(_context.Visit, "Id", "Id");
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

            _context.Attach(Prescription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrescriptionExists(Prescription.Id))
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

        private bool PrescriptionExists(int id)
        {
          return (_context.Prescription?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

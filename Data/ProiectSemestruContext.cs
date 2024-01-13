using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectSemestru.Models;

namespace ProiectSemestru.Data
{
    public class ProiectSemestruContext : DbContext
    {
        public ProiectSemestruContext (DbContextOptions<ProiectSemestruContext> options)
            : base(options)
        {
        }

        public DbSet<ProiectSemestru.Models.Patient> Patient { get; set; } = default!;
        public DbSet<ProiectSemestru.Models.Consultation> Consultation { get; set; } = default!;
        public DbSet<ProiectSemestru.Models.Visit>? Visit { get; set; }
        public DbSet<ProiectSemestru.Models.Doctor>? Doctor { get; set; }
        public DbSet<ProiectSemestru.Models.Prescription>? Prescription { get; set; }
    }
}

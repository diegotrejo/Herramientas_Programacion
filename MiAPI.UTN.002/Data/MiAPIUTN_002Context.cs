using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiApp.UTN.Modelos;

namespace MiAPI.UTN._002.Data
{
    public class MiAPIUTN_002Context : DbContext
    {
        public MiAPIUTN_002Context (DbContextOptions<MiAPIUTN_002Context> options)
            : base(options)
        {
        }

        public DbSet<Cargo> Cargos { get; set; } = default!;
        public DbSet<Persona> Personas { get; set; } = default!;
        public DbSet<Empleado> Empleados { get; set; } = default!;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.UTN.Modelos
{
    public class Empleado
    {
        public int Id { get; set; }         // PK
        public double Salario { get; set; }
        public double Comisiono { get; set; }
        public DateTime FechaIngreso { get; set; }


        // Relaciones
        public int PersonaId { get; set; }     // FK a Persona
        public Persona? Persona { get; set; }

        public int CargoId { get; set; }       // FK a Cargo
        public Cargo? Cargo { get; set; }
    }
}

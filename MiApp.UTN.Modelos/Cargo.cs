using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.UTN.Modelos
{
    public class Cargo
    {
        public int Id { get; set; }         // PK
        public string Name { get; set; }
        public string Description { get; set; }


        // Relaciones
        public List<Empleado>? Empleados { get; set; }
    }
}

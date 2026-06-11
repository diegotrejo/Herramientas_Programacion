using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.UTN.Modelos
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }         // PK 


        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        // Relaciones
        public Empleado? Empleado { get; set; }
    }
}

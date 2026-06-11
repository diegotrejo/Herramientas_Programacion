using Api.Consummer;
using MiApp.UTN.Modelos;

namespace MiApp.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Crud<Cargo>.Endpoint = "https://localhost:7055/api/cargos";
            Crud<Persona>.Endpoint = "https://localhost:7055/api/personas";

            //var nuevoCargo = Crud<Cargo>.Create( new Cargo { 
            //    Description = "Cargo de prueba", 
            //    Name = "Prueba" 
            //});

            //var nuevaPersona = Crud<Persona>.Create(new Persona
            //{
            //    Nombre = "Juan",
            //    Apellido = "Perez",
            //    Direccion = "Calle Falsa 123",
            //    Email = "abc@cxy.com",
            //    Telefono = "1234567890"
            //});

            //Crud<Cargo>.Delete("1");
            Crud<Cargo>.Update("2", new Cargo
            {
                Id = 2,
                Name = "Cargo actualizado",
                Description = "Descripción actualizada"
            });

            Console.ReadLine();
        }
    }
}

using System.Drawing;

namespace comercio_programacion_2.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public Cliente(string _nombre, string _apellido, string _domicilio, string _telefono, string _email)
        {
            
            Nombre = _nombre;
            Apellido = _apellido;
            Domicilio = _domicilio;
            Telefono = _telefono;
            Email = _email;
        }   
    }
}

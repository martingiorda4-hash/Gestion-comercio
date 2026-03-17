namespace comercio_programacion_2.Models
{
    public class Provedoor
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string Cuit { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        public Provedoor(string _razonSocial, string _cuit, string _email, string _telefono)
        {
            RazonSocial = _razonSocial;
            Cuit = _cuit;
            Email = _email;
            Telefono = _telefono;
        }
            
    }
}

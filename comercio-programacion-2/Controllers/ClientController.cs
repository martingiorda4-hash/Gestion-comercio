using System.Collections.Generic;
using comercio_programacion_2.Models;

namespace comercio_programacion_2.Controllers
{
    public static class ClientController
    {
        private static List<Client> clientes = new List<Client>();

        public static List<Client> Listar()
        {
            return clientes;
        }

        public static Client BuscarPorId(int id)
        {
            foreach (Client client in clientes)
            {
                if (client.Id == id)
                {
                    return client;
                }
            }
            return null;
        }

        public static bool Agregar(Client c)
        {
            foreach (Client client in clientes)
            {
                if (client.Id == c.Id)
                {
                    return false;
                }
            }
            clientes.Add(c);
            return true;
        }

        public static bool Modificar(Client c)
        {
            foreach (Client client in clientes)
            {
                if (client.Id == c.Id)
                {
                    client.Nombre = c.Nombre;
                    client.Apellido = c.Apellido;
                    client.Email = c.Email;
                    client.Telefono = c.Telefono;
                    client.Domicilio = c.Domicilio;
                    return true;
                }
            }
            return false;
        }

        public static bool Eliminar(Client c)
        {
            foreach (Client client in clientes)
            {
                if (client.Id == c.Id)
                {
                    clientes.Remove(client);
                    return true;
                }
            }
            return false;
        }
    }
}

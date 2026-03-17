using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using comercio_programacion_2.Models;

namespace comercio_programacion_2.Controllers
{
    public static class ClientController
    {
        private static List<Cliente> clientes = new List<Cliente>();
        private static string connectionString = "Data Source=localhost;Initial Catalog=AbmClientes;Integrated Security=True";
        private static SqlConnection _conn = new SqlConnection(connectionString);

        
        public static List<Cliente> Listar()
        {
            try
            {
                clientes.Clear();
                string consulta = "SELECT * FROM Clientes";


                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(consulta, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Cliente client = new Cliente(
                            reader["nombre"].ToString(),
                            reader["apellido"].ToString(),
                            reader["domicilio"].ToString(),
                            reader["telefono"].ToString(),
                            reader["email"].ToString()
                        );
                        clientes.Add(client);
                    }
                    reader.Close();
                }
                return clientes;
            }
            catch (System.Exception ex)
            {

                throw new System.Exception("Error al listar clientes: "+ ex.Message);
            }
            
            
        }
        public static Cliente BuscarPorId(int id)
        {
            try
            {
                clientes.Clear();
                string consultaBuscar = $"SELECT * FROM Clientes WHERE idCliente = {id}";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(consultaBuscar, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Cliente client = new Cliente(
                            reader["nombre"].ToString(),
                            reader["apellido"].ToString(),
                            reader["domicilio"].ToString(),
                            reader["telefono"].ToString(),
                            reader["email"].ToString()
                        );
                        client.Id = id;
                        clientes.Add(client);

                        reader.Close();
                        return client;
                    }
                    
                }
                
                return null;
            }
            catch (System.Exception exs)
            {

                throw new System.Exception("Error al buscar un cliente: " + exs.Message);
            }
            
        }
        public static void Agregar(Cliente c)
        {
            try
            {
                string consultaAgregar = $"INSERT INTO Clientes (nombre,apellido,domicilio,telefono,email) VALUES ( '{c.Nombre}','{c.Apellido}','{c.Domicilio}', '{c.Telefono}','{c.Email}') ";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(consultaAgregar, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();


                    clientes.Add(c);

                }




                
            }
            catch (System.Exception ex)
            {

                throw new System.Exception("Error al agregar un cliente: "+  ex.Message);
            }
           


       
            
            
        }
        public static void Modificar(Cliente c)
        {
            try
            {
                string consultaModificar = $"UPDATE Clientes SET nombre = '{c.Nombre}', apellido = '{c.Apellido}', domicilio = '{c.Domicilio}', telefono = '{c.Telefono}', email = '{c.Email}' WHERE idCliente = {c.Id}";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(consultaModificar, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    

                    foreach (Cliente client in clientes)
                    {
                        if (client.Id == c.Id)
                        {
                            client.Nombre = c.Nombre;
                            client.Apellido = c.Apellido;
                            client.Domicilio = c.Domicilio;
                            client.Telefono = c.Telefono;
                            client.Email = c.Email;
                        }
                    }
                }
               

            }
            catch (System.Exception ex)
            {

                throw new System.Exception("Error al modificar un cliente: "+ ex.Message);
            }
           
        }
            
            
        public static void Eliminar(int _id)
        {
            try
            {
                string consultaEliminar = $"DELETE FROM Clientes WHERE idCliente = '{_id}'";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(consultaEliminar, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    

                    for (int i = 0; i < clientes.Count; i++) 
                    {
                        if (clientes[i].Id == _id)
                        {
                            clientes.RemoveAt(i);
                            break;
                        }
                    }
                }


            }
            catch (System.Exception ex)
            {

                throw new System.Exception("Error al eliminar un cliente: "+ ex.Message);
            }
           
        }
        
            
    }
                
          

            
            
            
            

            
            
            




}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using comercio_programacion_2.Models;

namespace comercio_programacion_2.Controllers
{
    public static class ProviderController
    {
        private static List<Provedoor> proveedores = new List<Provedoor>();
        private static string connectionString = "Data Source=localhost;Initial Catalog=AbmClientes;Integrated Security=True";
        private static SqlConnection _conn = new SqlConnection(connectionString);

       public static List<Provedoor> Listar()
       {
            try
            {
                proveedores.Clear();
                string consulta = "SELECT * FROM Proveedores";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    conexion.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Provedoor provider = new Provedoor(
                            reader["razonSocial"].ToString(),
                            reader["cuit"].ToString(),
                            reader["email"].ToString(),
                            reader["telefono"].ToString()
                            );

                        proveedores.Add(provider);
                    }
                    reader.Close();
                }
                return proveedores;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al listar proveedores: "+ ex.Message);
            }
            
       }
        public static Provedoor BuscarId(int _id)
        {
            try
            {
                
                proveedores.Clear();
                string consultaBuscar = $"SELECT * FROM Proveedores WHERE id = {_id}";
                using (SqlConnection conexion = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(consultaBuscar, conexion))
                {
                    conexion.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Provedoor provider = new Provedoor(
                            reader["razonSocial"].ToString(),
                            reader["cuit"].ToString(),
                            reader["email"].ToString(),
                            reader["telefono"].ToString()
                        );
                        provider.Id = _id;
                        reader.Close();
                        return provider;
                    }
                }
                return null;
                
            }
            catch (Exception ex)
            {

                throw new Exception ("Error al buscar un proveedor: "+ex.Message);
            }
            
        }
        public static void Agregar(Provedoor p)
        {
            try
            {
                string consultaAgregar = $"INSERT INTO Proveedores (razonSocial,cuit,email,telefono) VALUES ('{p.RazonSocial}','{p.Cuit}','{p.Email}','{p.Telefono}')";
                using (SqlConnection conexionAgregar = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(consultaAgregar, conexionAgregar))
                {
                    conexionAgregar.Open();
                    cmd.ExecuteNonQuery();
                    
                   
                    proveedores.Add(p);
                }
               
            }
            catch (Exception ex)
            {

                throw new Exception("Error al agregar un proveedor: "+ ex.Message);
            }

            
        }
        public static void Modificar(Provedoor p)
        {
            try
            {
                string consultaModificar = $"UPDATE Proveedores SET razonSocial = '{p.RazonSocial}',cuit = '{p.Cuit}', email = '{p.Email}', telefono = '{p.Telefono}' WHERE id = {p.Id}";
                using (SqlConnection conexionModificar = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(consultaModificar, conexionModificar))
                {
                    conexionModificar.Open();

                    cmd.ExecuteNonQuery();
                   

                    foreach (Provedoor item in proveedores)
                    {
                        if (item.Id == p.Id)
                        {
                            item.RazonSocial = p.RazonSocial;
                            item.Cuit = p.Cuit;
                            item.Email = p.Email;
                            item.Telefono = p.Telefono;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al modificar un proveedor: "+ ex.Message);
            }
            

        }
        public static void Eliminar(int _id)
        {
            try
            {
                string consultaEliminar = $"DELETE FROM Proveedores WHERE id = '{_id}'";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(consultaEliminar, conn))
                {
                    conn.Open();

                    cmd.ExecuteNonQuery();
                    

                    for (int i = 0; i < proveedores.Count; i++) 
                    {
                        if (proveedores[i].Id == _id)
                        {
                            proveedores.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al eliminar un proveedor: "+ ex.Message);
            }
            
        }
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercio_programacion_2
{
    public static class ProductController
    {
        private static List<Producto> productos = new List<Producto>();
        private static string connectionString = "Data Source=localhost;Initial Catalog=AbmClientes;Integrated Security=True";
        private static SqlConnection _conn = new SqlConnection(connectionString);

        public static List<Producto> Listar()
        {
            try
            {
                productos.Clear();
                string query = "SELECT * FROM Productos";
                using(SqlConnection conexion = new SqlConnection(connectionString))
                using(SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    conexion.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Producto product = new Producto(
                                reader["nombre"].ToString(),
                                reader["descripcion"].ToString(),
                                decimal.Parse( reader["precio"].ToString()),
                                int.Parse(reader["stock"].ToString())
                        );
                        productos.Add(product);    
                            
                    }
                    reader.Close();

                }

                return productos;
            }
            catch (Exception ex )
            {

                throw new Exception("Error al listar productos: "+ ex.Message); 
            }
           
        }
        public static Producto BuscarPorId(int _id)
        {
            try
            {
                string query = $"SELECT * FROM Productos WHERE id = {_id}";
                using (SqlConnection conexion = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    conexion.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Producto product = new Producto(
                                reader["nombre"].ToString(),
                                reader["descripcion"].ToString(),
                                decimal.Parse(reader["precio"].ToString()),
                                int.Parse(reader["stock"].ToString())
                        );
                        product.Id = _id;
                        
                        reader.Close();
                        return product;

                    }
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al buscar el producto: "+ ex.Message);
            }
        }
        public static void Agregar(Producto p)
        {
            try
            {
                string query = $"INSERT INTO Productos(nombre, descripcion, precio, stock) VALUES('{p.Nombre}','{p.Descripcion}',{p.Precio},{p.Stock})";
                using (SqlConnection conexion = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();

                    productos.Add(p);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al agregar el producto: " + ex.Message);
            }
        }
        public static void Modificar(Producto p)
        {
            try
            {
                string query = $"UPDATE Productos SET nombre = @nombre, descripcion = @descripcion, precio = @precio, stock = @stock WHERE id = @id";
                using (SqlConnection conexion = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", p.Descripcion);
                    cmd.Parameters.AddWithValue("@precio", p.Precio);
                    cmd.Parameters.AddWithValue("@stock", p.Stock);
                    cmd.Parameters.AddWithValue("@id", p.Id);
                    conexion.Open();
                    cmd.ExecuteNonQuery();

                    foreach(Producto item in productos)
                    {
                        if(item.Id == p.Id)
                        {
                            item.Nombre = p.Nombre;
                            item.Descripcion = p.Descripcion;
                            item.Precio = p.Precio;
                            item.Stock = p.Stock;
                            break;
                        }
                    }
                    productos.Add(p);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al modificar el producto: "+ ex.Message);
            }
        }
        public static void Eliminar(int _id)
        {
            try
            {
                string query = $"DELETE FROM Productos WHERE id = {_id}";
                using (SqlConnection conexion = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();

                    for (int i = 0; i < productos.Count; i++)
                    {
                        if(productos[i].Id == _id)
                        {
                            productos.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al eliminar el producto: "+ ex.Message);
            }
        }
    }
}

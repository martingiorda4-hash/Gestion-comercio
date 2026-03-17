using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comercio_programacion_2
{
    public partial class FrmProductList : Form
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=AbmClientes;Integrated Security=True";

        public FrmProductList()
        {
            InitializeComponent();
        }

        private void FrmProductList_Load(object sender, EventArgs e)
        {
            dgvProductos.Rows.Clear();
            List<Producto> productos = ProductController.Listar();
            foreach(Producto product in productos)
            {
                dgvProductos.Rows.Add(product.Nombre,product.Descripcion,product.Precio,product.Stock);
            }
            Buscar(txtBuscador.Text);
        }
        private void Buscar(string _busqueda)
        {
            try
            {
                string sqlBusqueda = "SELECT * FROM Productos";
                if(_busqueda != null && _busqueda.Length >= 2)
                {
                    sqlBusqueda += " WHERE nombre LIKE '%" + _busqueda + "%'";
                }
                SqlDataAdapter adapter = new SqlDataAdapter(sqlBusqueda,connectionString);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvProductos.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dgvProductos.Rows.Add(
                            row["nombre"].ToString(),
                            row["descripcion"].ToString(),
                            row["precio"].ToString(),
                            row["stock"].ToString()
                           

                        );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: "+ ex.Message);
                throw;
            }
        }

        private void txtBuscador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Buscar(txtBuscador.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Buscar(txtBuscador.Text);
        }
    }
}

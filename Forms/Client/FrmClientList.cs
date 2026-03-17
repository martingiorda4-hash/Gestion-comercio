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
using comercio_programacion_2.Controllers;
using comercio_programacion_2.Models;

namespace comercio_programacion_2.Forms.Client
{
    public partial class FrmClientList : Form
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=AbmClientes;Integrated Security=True";

        public FrmClientList()
        {
            InitializeComponent();
        }

        private void FrmClientList_Load(object sender, EventArgs e)
        {
            dgvClientes.Rows.Clear();
            List<Cliente> clientes = ClientController.Listar();

            foreach (Cliente item in clientes)
            {
                dgvClientes.Rows.Add(item.Nombre, item.Apellido, item.Domicilio, item.Telefono, item.Email);
            }
            Buscar(txtBuscador.Text);
            
            
        }
        private void Buscar(string _busqueda)
        {
            try
            {
                string buscarCliente = "SELECT * FROM Clientes";

                if(_busqueda != null && _busqueda.Length >= 2)
                {
                    buscarCliente +=  " WHERE nombre LIKE '%" + _busqueda + "%'";
                }
                SqlDataAdapter adapter = new SqlDataAdapter(buscarCliente, connectionString);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvClientes.Rows.Clear();
                foreach(DataRow row in dt.Rows)
                {
                    dgvClientes.Rows.Add(
                            row["nombre"].ToString(),
                            row["apellido"].ToString(),
                            row["domicilio"].ToString(),
                            row["telefono"].ToString(),
                            row["email"].ToString()

                        );
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar" + ex.Message);
                throw;
            }
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {

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



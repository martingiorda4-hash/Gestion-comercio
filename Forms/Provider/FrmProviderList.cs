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

namespace comercio_programacion_2.Forms.Provider
{
    public partial class FrmProviderList : Form
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=AbmClientes;Integrated Security=True";

        public FrmProviderList()
        {
            InitializeComponent();
        }

        private void FrmProviderList_Load(object sender, EventArgs e)
        {
            dgvProveedores.Rows.Clear();
            List<Provedoor> providers = ProviderController.Listar();

            foreach(Provedoor item in providers)
            {
                dgvProveedores.Rows.Add(item.RazonSocial,item.Cuit,item.Email,item.Telefono);
            }
            Buscar(txtBuscador.Text);
        }
        private void Buscar(string _busqueda)
        {
            try
            {
                string sqlBusqueda = "SELECT * FROM Proveedores";
                if (_busqueda != null && _busqueda.Length >= 2)
                {
                    sqlBusqueda += " WHERE razonSocial LIKE '%" + _busqueda + "%'";
                }
                SqlDataAdapter adapter = new SqlDataAdapter(sqlBusqueda, connectionString);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvProveedores.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dgvProveedores.Rows.Add(
                            row["razonSocial"].ToString(),
                            row["cuit"].ToString(),
                            row["email"].ToString(),
                            row["telefono"].ToString()


                        );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message);
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

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

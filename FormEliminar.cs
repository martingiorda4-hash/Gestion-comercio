using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using comercio_programacion_2.Controllers;
using comercio_programacion_2.Forms.Client;
using comercio_programacion_2.Forms.Provider;
using comercio_programacion_2.Models;

namespace comercio_programacion_2
{
    public partial class FormEliminar : Form
    {
        public FormEliminar()
        {
            InitializeComponent();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("El id ingresado no es valido. Debe ser un numero entero");
            }

            try
            {
                Cliente cliente = ClientController.BuscarPorId(id);
                if (cliente != null)
                {
                    FrmClient frmClient = new FrmClient(cliente);
                    frmClient.Show();

                    FormDeseaEliminar formDeseaEliminar = new FormDeseaEliminar("Cliente", id);
                    formDeseaEliminar.ShowDialog();

                    this.Close();
                    return;
                }


                Provedoor provedoor = ProviderController.BuscarId(id);
                if (provedoor != null)
                {
                    FrmProvider frmProvider = new FrmProvider(provedoor);
                    frmProvider.Show();

                    FormDeseaEliminar formEliminar = new FormDeseaEliminar("Proveedor", id);
                    formEliminar.ShowDialog();

                    this.Close();
                    return;
                }

                Producto producto = ProductController.BuscarPorId(id);
                if(producto != null)
                {
                    FrmProduct frmProduct = new FrmProduct(producto);
                    frmProduct.Show();

                    FormDeseaEliminar formDeseaEliminar = new FormDeseaEliminar("Producto", id);
                    formDeseaEliminar.ShowDialog();

                    this.Close();
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error al buscar el id", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MessageBox.Show("No se encontró el id", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

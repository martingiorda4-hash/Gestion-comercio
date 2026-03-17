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
    public partial class BuscarCliente : Form
    {
        
        public BuscarCliente()
        {
            InitializeComponent();
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Debe ingresar un numero entero para el id");
                return;
            }

            try
            {
                Cliente cliente = ClientController.BuscarPorId(id);
                if (cliente != null)
                {
                    FrmClient frmClient = new FrmClient(cliente);
                    frmClient.Show();
                    return;
                }




                Provedoor provedoor = ProviderController.BuscarId(id);
                if (provedoor != null)
                {
                    FrmProvider frmProvider = new FrmProvider(provedoor);
                    frmProvider.Show();
                    return;
                }

                Producto producto = ProductController.BuscarPorId(id);
                if(producto != null)
                {
                    FrmProduct frmProduct = new FrmProduct(producto);
                    frmProduct.Show();
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error al buscar un id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

           MessageBox.Show("No se encontró el id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);




        }
    }
}

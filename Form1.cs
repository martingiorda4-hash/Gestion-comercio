using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using comercio_programacion_2.Controllers;
using comercio_programacion_2.Forms.Client;
using comercio_programacion_2.Forms.Provider;
using comercio_programacion_2.Models;


namespace comercio_programacion_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClient frmClient = new FrmClient(null);
            frmClient.Show();
        }

        private void editarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            BuscarCliente formBuscar = new BuscarCliente();
            formBuscar.Show();
            

        }

        private void verTodosClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            FrmClientList frmClientList = new FrmClientList();
            frmClientList.Show();
        }

        private void eliminarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEliminar formEliminar = new FormEliminar();
            formEliminar.Show();
        }


        private void nuevoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProvider frmProvider =  new FrmProvider(null);
            frmProvider.Show();
        }

        private void editarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarCliente buscarCliente = new BuscarCliente();
            buscarCliente.Show();
        }

        private void verTodosProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProviderList frmProviderList = new FrmProviderList();
            frmProviderList.Show();
        }

        private void eliminarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEliminar frmProvider = new FormEliminar();
            frmProvider.ShowDialog();
        }

       

        private void nuevoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmProduct frmProduct = new FrmProduct(null);
            frmProduct.Show();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarCliente frmBuscar = new BuscarCliente();
            frmBuscar.Show();
        }

        private void verTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProductList frmProductList = new FrmProductList();
            frmProductList.Show();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEliminar formEliminar = new FormEliminar();
            formEliminar.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class FormDeseaEliminar : Form
    {
        private int id;
        private string tipo;
        public FormDeseaEliminar(string _tipo,int _id)
        {
            InitializeComponent();
            id = _id;
            tipo = _tipo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is FrmClient)
                {
                    frm.Close();
                    break;
                }
                else if (frm is FrmProduct)
                {
                    frm.Close();
                    break;
                }
                else if (frm is FrmProvider)
                {
                    frm.Close();
                    break;
                }
            }
            try
            {
                if (tipo == "Cliente")
                {
                    ClientController.Eliminar(id);
                    MessageBox.Show("Cliente eliminado correctamente. ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (tipo == "Proveedor")
                {
                    ProviderController.Eliminar(id);
                    MessageBox.Show("Proveedor eliminado correctamente. ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if(tipo == "Producto")
                {
                    ProductController.Eliminar(id);
                    MessageBox.Show("Producto eliminado correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error al eliminar.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
            this.Close();
             
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(Form frm in Application.OpenForms)
            {
                if(frm is FrmClient)
                {
                    frm.Close();
                    break;
                }
                else if(frm is FrmProduct)
                {
                    frm.Close();
                    break;
                }
                else if(frm is FrmProvider)
                {
                    frm.Close();
                    break;
                }
            }
            
            this.Close();
        }
    }
}

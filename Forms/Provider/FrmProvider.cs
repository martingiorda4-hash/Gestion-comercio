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
using comercio_programacion_2.Models;

namespace comercio_programacion_2.Forms.Provider
{
    public partial class FrmProvider : Form
    {
        bool editando = false;
        int idActual;
        public FrmProvider(Provedoor proveedor)
        {
            InitializeComponent();

            if(proveedor != null)
            {
                editando = true;
                idActual = proveedor.Id;
                txtRazonSocial.Text = proveedor.RazonSocial;
                txtCuit.Text = proveedor.Cuit;
                txtEmail.Text = proveedor.Email;
                txtTelefono.Text = proveedor.Telefono;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())return;

            try
            {
                Provedoor provedoor = new Provedoor(txtRazonSocial.Text, txtCuit.Text, txtEmail.Text, txtTelefono.Text);
                provedoor.Id = idActual;
                if (editando)
                {
                    ProviderController.Modificar(provedoor);
                    MessageBox.Show("Proveedor modificado correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form formProvider = null;
                    

                    foreach (Form frm in Application.OpenForms)
                    {
                        if (frm is FrmProvider)
                        {
                            formProvider = frm;
                        }
                        
                    }
                    if (formProvider != null)
                    {
                        formProvider.Close();
                    }
                   

                }
                else
                {
                    ProviderController.Agregar(provedoor);
                    MessageBox.Show("Proveedor agregado correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Form formProvider = null;

                    foreach (Form frm in Application.OpenForms)
                    {
                        if (frm is FrmProvider)
                        {
                            formProvider = frm;
                        }

                    }
                    if (formProvider != null)
                    {
                        formProvider.Close();
                    }
                }
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool ValidarDatos()
        {
            if(txtRazonSocial.Text.Trim() == "")
            {
                MessageBox.Show("La razon social es obligatoria.", "Validacion" , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRazonSocial.Focus();
                return false;
            }
            if(txtCuit.Text.Trim() == "")
            {
                MessageBox.Show("El cuit es obligatorio.", "Validacion" ,MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCuit.Focus();
                return false;
            }
            if(txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("El email es obligatorio", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            if(txtTelefono.Text.Trim() == "")
            {
                MessageBox.Show("El telefono es obligatorio.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }
            if(!int.TryParse(txtTelefono.Text,out int _))
            {
                MessageBox.Show("El telefono debe contener solo numeros.","Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }
            return true;

            
        }
    }
}

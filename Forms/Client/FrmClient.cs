using System.Linq;
using System.Windows.Forms;
using comercio_programacion_2.Controllers;
using comercio_programacion_2.Models;

namespace comercio_programacion_2.Forms.Client
{
    public partial class FrmClient : Form
    {
        bool editando = false;
        int idActual;
        public FrmClient(Cliente cliente)
        {
            InitializeComponent();

            if(cliente != null)
            {
                editando = true;
                idActual = cliente.Id;

                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtDomicilio.Text = cliente.Domicilio;
                txtTelefono.Text = cliente.Telefono;    
                txtEmail.Text = cliente.Email;
            }
            
        }
        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, System.EventArgs e)
        {
            if(!ValidarDatos())return;
            try
            {
                Cliente cliente = new Cliente(txtNombre.Text, txtApellido.Text, txtDomicilio.Text, txtTelefono.Text, txtEmail.Text);
                cliente.Id = idActual;

                if (editando)
                {


                    ClientController.Modificar(cliente);
                    MessageBox.Show("Cliente modificado correctamente.","Exito",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form clienteForm = null;

                    foreach (Form frm in Application.OpenForms)
                    {
                        
                        if (frm is FrmClient)
                        {
                            clienteForm = frm;
                        }

                    }
                    if (clienteForm != null)
                    {
                        clienteForm.Close();
                    }
                   


                }
                else
                {

                    ClientController.Agregar(cliente);
                    MessageBox.Show("Cliente agregado correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form clienteForm = null;

                    foreach (Form frm in Application.OpenForms)
                    {
                        if (frm is FrmClient)
                        {
                            clienteForm = frm;
                        }


                    }
                    if (clienteForm != null)
                    {
                        clienteForm.Close();
                    }


                }
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
                
        }
        private bool ValidarDatos()
        {
            if(txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("El nombre es obligatorio.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            if (txtApellido.Text.Trim() == "")
            {
                MessageBox.Show("El apellido es obligatorio.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }
            if (txtDomicilio.Text.Trim() == "")
            {
                MessageBox.Show("El domicilio es obligatorio.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDomicilio.Focus();
                return false;
            }
            if (txtTelefono.Text.Trim() == "")
            {
                MessageBox.Show("El telefono es obligatorio.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }
            if (!int.TryParse(txtTelefono.Text,out _))
            {
                MessageBox.Show("El telefono debe contener solo numeros.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("El email es obligatorio.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            return true;
        }
               
               


                
                
                
                

                



    }
}

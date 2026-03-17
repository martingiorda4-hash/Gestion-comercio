using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using comercio_programacion_2.Forms.Client;

namespace comercio_programacion_2
{
    public partial class FrmProduct : Form
    {
        private bool EstamosEditando = false;
        private int idActual;
        public FrmProduct(Producto product)
        {
            InitializeComponent();

            if(product != null)
            {
                EstamosEditando = true;
                idActual = product.Id;

                txtNombre.Text = product.Nombre;
                txtDescripcion.Text = product.Descripcion;
                txtPrecio.Text = product.Precio.ToString();
                txtStock.Text = product.Stock.ToString();
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(!ValidarDatos()) return;

            try
            {
                if (EstamosEditando)
                {
                    Producto producto = new Producto(txtNombre.Text,txtDescripcion.Text,decimal.Parse(txtPrecio.Text),int.Parse(txtStock.Text));
                    producto.Id = idActual;

                    ProductController.Modificar(producto);
                    MessageBox.Show("Producto modificado correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form productoForm = null;
                    

                    foreach (Form frm in Application.OpenForms)
                    {
                        
                        if (frm is FrmProduct)
                        {
                            productoForm = frm;
                        }

                    }
                    if (productoForm != null)
                    {
                        productoForm.Close();
                    }
                    
                }
                else
                {
                    ProductController.Agregar(new Producto(txtNombre.Text, txtDescripcion.Text, decimal.Parse(txtPrecio.Text), int.Parse(txtStock.Text)));
                    MessageBox.Show("Producto agregado correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form productoForm = null;

                    foreach (Form frm in Application.OpenForms)
                    {
                        if (frm is FrmProduct)
                        {
                            productoForm = frm;
                        }
                    }
                    if (productoForm != null)
                    {
                        productoForm.Close();
                    }
                }
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            if (txtDescripcion.Text.Trim() == "")
            {
                MessageBox.Show("La descripcion es obligatoria.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }
            if(!decimal.TryParse(txtPrecio.Text, out _))
            {
                MessageBox.Show("El precio debe contener solo numeros.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return false;
            }
            if (txtPrecio.Text.Trim() == "")
            {
                MessageBox.Show("El precio es obligatorio.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return false;
            }
            if (!int.TryParse(txtStock.Text, out _))
            {
                MessageBox.Show("El stock debe contener solo numeros.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return false;
            }
            if (txtStock.Text.Trim() == "")
            {
                MessageBox.Show("El stock es obligatorio.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return false;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

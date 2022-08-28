using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PEA2.Dominio;
using PEA2.Logic;

namespace PEA2.AppWin
{

    public partial class ProductoEdit : Form
    {
        Producto producto;
        public ProductoEdit(Producto producto)
        {
            InitializeComponent();
            this.producto = producto;
        }

        private void ProductoEdit_Load(object sender, EventArgs e)
        {
            cargardatos();
            if (producto.ID > 0)
            {
                asignarControles();
            }
        }
        private void cargardatos()
        {
            cboCategoria.DataSource = CategoriaBL.Listar();
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "ID";
        }

        private void asignarObjeto()
        {
            this.producto.Nombre = txtNombre.Text;
            this.producto.Marca = txtMarca.Text;
            this.producto.Precio = decimal.Parse(txtPrecio.Text);
            this.producto.Stock = int.Parse(txtStock.Text);
            this.producto.IdCategoria = int.Parse(cboCategoria.SelectedValue.ToString());
        }

        private void asignarControles()
        {
            txtNombre.Text = this.producto.Nombre;
            txtMarca.Text = this.producto.Marca;
            //txtPrecio.Text = decimal.Parse(producto.Precio.ToString());
            cboCategoria.SelectedValue = this.producto.IdCategoria;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            asignarObjeto();
            double pMax = double.Parse(txtPrecio.Text);
            if (pMax > 2500)
            {
                MessageBox.Show("El precio sobrepasa los limites", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int sMin = int.Parse(txtStock.Text);
            if (sMin < 6)
            {
                MessageBox.Show("El stock no es suficiente", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}

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
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            var listado = ProductoBL.Listar();
            dgvListado.Rows.Clear();
            foreach (var producto in listado)
            {
                dgvListado.Rows.Add(producto.ID, producto.Nombre, producto.Marca, producto.IdCategoria, producto.Precio, producto.Stock);
            }
        }

        private void nuevoRegistro(object sender, EventArgs e)
        {
            var nuevoProducto = new Producto();
            var frm = new ProductoEdit(nuevoProducto);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var exito = ProductoBL.Insertar(nuevoProducto);
                if (exito)
                {
                    MessageBox.Show("El producto ha sido registrado", "Producto",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                }
                else
                {
                    MessageBox.Show("El producto no se ha podido registrar", "Producto",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void editarRegistro(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count > 0)
            {
                int filaActual = dgvListado.CurrentRow.Index;
                var idProducto = int.Parse(dgvListado.Rows[filaActual].Cells[0].Value.ToString());
                var productoEditar = ProductoBL.BuscarPorId(idProducto);
                var frm = new ProductoEdit(productoEditar);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var exito = ProductoBL.Actualizar(productoEditar);
                    if (exito)
                    {
                        MessageBox.Show("El producto ha sido actualizado", "Producto",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido completar la actualizacion", "Producto",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void eliminarRegistro(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count > 0)
            {
                int filaActual = dgvListado.CurrentRow.Index;
                var idProducto = int.Parse(dgvListado.Rows[filaActual].Cells[0].Value.ToString());
                var nombreProducto = dgvListado.Rows[filaActual].Cells[1].Value.ToString();
                var rpta = MessageBox.Show("Realmente desea eliminar el producto" + nombreProducto + " ?",
                    "Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rpta == DialogResult.Yes)
                {
                    var exito = ProductoBL.Eliminar(idProducto);
                    if (exito)
                    {
                        MessageBox.Show("El producto ha sido eliminado", "Producto",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido eliminar el producto", "Producto",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

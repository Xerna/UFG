using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }
        CRUD_productos crud = new CRUD_productos();

        private void btn_guardar_Click(object sender, EventArgs e)
        {
         

            if (!string.IsNullOrEmpty(txt_productos.Text) && !string.IsNullOrEmpty(txt_descripcion.Text) && !string.IsNullOrEmpty(txt_cantidadStock.Text) && !string.IsNullOrEmpty(txt_precioVenta.Text) && !string.IsNullOrEmpty(cb_estado.Text))
            {
                
                crud.Producto = txt_productos.Text.Trim();
                crud.Descripcion= txt_descripcion.Text.Trim();
                crud.CantidadEnStock = Convert.ToInt32(txt_cantidadStock.Text);
                crud.PrecioVenta = Convert.ToDouble(txt_precioVenta.Text);
                crud.Estado = Convert.ToChar(cb_estado.Text);
                
                long id = crud.AgregarProdcutos();
                if (id > 0)
                {
                    MessageBox.Show("agregado");
                    limpiar();
                    refrescarGrid();
                }
            }
            else { MessageBox.Show("Rellene los campos", "validación de numero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            refrescarGrid();
        }

        public void refrescarGrid()
        {
            dataGridView1.DataSource = crud.GetProductos();
        }

        public void limpiar(){
            refrescarGrid();
            txt_id.Clear();
            txt_productos.Clear();
            txt_descripcion.Clear();
            txt_cantidadStock.Clear();
            txt_precioVenta.Clear();
            cb_estado.SelectedIndex = -1;}

        private void txt_cantidadStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)) {
                e.Handled = false;
            }
             else if(char.IsControl(e.KeyChar)) {
                e.Handled = false;
            }else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten datos numericos", "validación de numero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void txt_precioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == ',') && (!txt_cantidadStock.Text.Contains(",")))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten datos numericos", "validación de numero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.CurrentRow;
                txt_id.Text = row.Cells[0].Value.ToString();
                txt_productos.Text = row.Cells[1].Value.ToString();
                txt_descripcion.Text = row.Cells[2].Value.ToString();
                txt_cantidadStock.Text = row.Cells[3].Value.ToString();
                txt_precioVenta.Text = row.Cells[4].Value.ToString();
                cb_estado.Text = row.Cells[5].Value.ToString();
            }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            int indiceEstado = cb_estado.SelectedIndex;

            if (!txt_id.Text.Equals(""))
            {
                string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (!string.IsNullOrEmpty(id))
                {

                    crud.IdProducto = Convert.ToInt64(id);
                    crud.Producto = txt_productos.Text.Trim();
                    crud.Descripcion = txt_descripcion.Text.Trim();
                    crud.CantidadEnStock = Convert.ToInt32(txt_cantidadStock.Text);
                    crud.PrecioVenta = Convert.ToDouble(txt_precioVenta.Text);
                    crud.Estado = Convert.ToChar(cb_estado.Text);


                    int affect = crud.EditarProducto();
                    if (affect > 0)
                    {
                        MessageBox.Show("actualizado");
                        limpiar();
                        refrescarGrid();
                    }


                }
            }
            else { MessageBox.Show("Seleccione una celda para actualizar", "Precaución", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
             if (!txt_id.Text.Equals(""))
            {
                string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (!String.IsNullOrEmpty(id))
                {

                    crud.IdProducto = Convert.ToInt64(id);
                    int affect = crud.EliminarProducto();

                    if (affect >= 1)
                    {
                        MessageBox.Show("eliminado");
                        refrescarGrid();
                        limpiar();
                    }
                }
            }
            else { MessageBox.Show("Seleccione una celda para eliminar", "Precaución", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_buscar.Text)) {
                crud.Producto = txt_buscar.Text.Trim();
                dataGridView1.DataSource = crud.buscarProdcutos();
            } else { MessageBox.Show("Ingrese algo para buscar", "Precaución", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            
        }

        private void btn_mostrarTodo_Click(object sender, EventArgs e)
        {
            txt_buscar.Clear();
            refrescarGrid();
        }
    }
}

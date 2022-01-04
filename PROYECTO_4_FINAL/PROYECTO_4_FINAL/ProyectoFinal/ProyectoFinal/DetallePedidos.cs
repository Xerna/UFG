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
    public partial class DetallePedidos : Form
    {
        public DetallePedidos()
        {
            InitializeComponent();
        }
        CRUD_detallePedido crud = new CRUD_detallePedido();

        private void button3_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void llenarCbIDPedido()
        {
            cb_IdPedido.DataSource = crud.cargarIdPedido();
            cb_IdPedido.DisplayMember = "idPedido";
            cb_IdPedido.ValueMember = "idPedido";
            cb_IdPedido.SelectedIndex = -1;
            cb_buscar.DataSource = crud.cargarIdPedido();
            cb_buscar.DisplayMember = "idPedido";
            cb_buscar.ValueMember = "idPedido";
            cb_buscar.SelectedIndex = -1;
        }

        private void llenarCbIDProducto()
        {
            cb_idProducto.DataSource = crud.cargarIdProducto();
            cb_idProducto.DisplayMember = "idProducto";
            cb_idProducto.ValueMember = "idProducto";
            cb_idProducto.SelectedIndex = -1;
        }

        private void DetallePedidos_Load(object sender, EventArgs e)
        {
            refrescarGrid();
            llenarCbIDProducto();
            llenarCbIDPedido();
        }

        private void refrescarGrid()
        {
            dataGridView1.DataSource = crud.GetDetallePedido();

        }

        private void limpiar(){
            txt_id.Clear();
            cb_IdPedido.SelectedIndex = -1;
            cb_idProducto.SelectedIndex = -1;
            txt_precioUnidad.Clear();
            txt_numeroLinea.Clear();
            cb_estado.SelectedIndex = -1;
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cb_IdPedido.Text) && !string.IsNullOrEmpty(cb_idProducto.Text) && !string.IsNullOrEmpty(txt_precioUnidad.Text) && !string.IsNullOrEmpty(txt_numeroLinea.Text) && !string.IsNullOrEmpty(cb_estado.Text))
            {
                crud.IdPedido = Convert.ToInt64(cb_IdPedido.Text);
                crud.IdProducto = Convert.ToInt64(cb_idProducto.Text);
                crud.PrecioUnidad = Convert.ToDouble(txt_precioUnidad.Text);
                crud.NumeroLinea = Convert.ToInt32(txt_numeroLinea.Text.Trim());
                crud.Estado =  Convert.ToChar(cb_estado.Text.Trim());

                long id = crud.AgregarDetallePedido();
                if (id > 0)
                {
                    MessageBox.Show("agregado");
                    limpiar();
                    refrescarGrid();
                }
            }
            else { MessageBox.Show("rellene los campos"); }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.CurrentRow;
                txt_id.Text = row.Cells[0].Value.ToString();
                cb_IdPedido.Text = row.Cells[1].Value.ToString();
                cb_idProducto.Text = row.Cells[2].Value.ToString();
                txt_precioUnidad.Text = row.Cells[3].Value.ToString();
                txt_numeroLinea.Text = row.Cells[4].Value.ToString();
                cb_estado.Text = row.Cells[5].Value.ToString();

            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            if (!txt_id.Text.Equals(""))
            {
                string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (!string.IsNullOrEmpty(id))
                {
                    crud.IdDetallePedido = Convert.ToInt64(txt_id.Text);
                    crud.IdPedido = Convert.ToInt64(cb_IdPedido.Text);
                    crud.IdProducto = Convert.ToInt64(cb_idProducto.Text);
                    crud.PrecioUnidad = Convert.ToDouble(txt_precioUnidad.Text);
                    crud.NumeroLinea = Convert.ToInt32(txt_numeroLinea.Text.Trim());
                    crud.Estado = Convert.ToChar(cb_estado.Text.Trim());
 

                    int affect = crud.EditarDetallePedido();
                    if (affect > 0)
                    {
                        MessageBox.Show("actualizado");
                        limpiar();
                        refrescarGrid();
                    }


                }
            }
            else { MessageBox.Show("a"); }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!txt_id.Text.Equals(""))
            {
                string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (!String.IsNullOrEmpty(id))
                {

                    crud.IdDetallePedido= Convert.ToInt64(id);
                    int affect = crud.EliminarDetallePedido();

                    if (affect >= 1)
                    {
                        MessageBox.Show("eliminado");
                        refrescarGrid();
                        limpiar();
                    }
                }
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(cb_buscar.Text))
            {
                crud.IdPedido = Convert.ToInt64(cb_buscar.Text.Trim());
                dataGridView1.DataSource = crud.buscarDetallePedido();
            }
            else { MessageBox.Show("Ingrese algo para buscar", "Precaución", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void btn_mostrarTodo_Click(object sender, EventArgs e)
        {
            cb_buscar.SelectedIndex = -1;
            refrescarGrid();
        }

        private void txt_precioUnidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == ',') && (!txt_precioUnidad.Text.Contains(",")))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten datos numericos decimal", "validación de numero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_numeroLinea_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten datos numericos enteros", "validación de numero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void ç_Click(object sender, EventArgs e)
        {
            TablaPedidos ta = new TablaPedidos();
            ta.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tablaProducto tb = new tablaProducto();
            tb.Show();
        }
    }
}

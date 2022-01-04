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
    public partial class Pedidos : Form
    {
        public Pedidos()
        {
            InitializeComponent();
        }

        private readonly CRUD_pedidos crud = new CRUD_pedidos();

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
           
            
            if (!string.IsNullOrEmpty(cb_idCliente.Text) && !string.IsNullOrEmpty(dtp_pedido.Text) && !string.IsNullOrEmpty(dtp_esperada.Text) && !string.IsNullOrEmpty(txt_comentarios.Text) && !string.IsNullOrEmpty(cb_estado.Text))
            {
               
                                

                crud.IdCliente = Convert.ToInt64(cb_idCliente.Text);
                crud.FechaPedido = Convert.ToDateTime(dtp_pedido.Text);
                crud.FechaEsperada =Convert.ToDateTime(dtp_esperada.Text);
                crud.Comentarios = txt_comentarios.Text.Trim();
                crud.Estado = cb_estado.Text.Trim();
                
                long id = crud.AgregarPedido();
                if (id > 0)
                {
                    MessageBox.Show("agregado");
                    limpiar();
                    refrescarGrid();
                }
            }
            else { MessageBox.Show("rellene los campos"); }
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {
            llenarCbCli();
            refrescarGrid();
        }

      


    private void limpiar(){
            refrescarGrid();
            txt_idPedido.Clear();
            cb_idCliente.SelectedIndex = -1;
            dtp_pedido.Value = DateTime.Now.Date;
            dtp_esperada.Value = DateTime.Now.Date;
            txt_comentarios.Clear();
            cb_estado.SelectedIndex = -1;
            
        }

    private void refrescarGrid() {
            dataGridView1.DataSource = crud.GetPedidos();

        }

        private void txt_actualizar_Click(object sender, EventArgs e)
        {
          

            if (!txt_idPedido.Text.Equals(""))
            {
                string id = dataGridView1.CurrentRow.Cells["idPedido"].Value.ToString();
                if (!string.IsNullOrEmpty(id))
                {
                 
                    crud.IdPedido = Convert.ToInt64(id);
                    crud.IdCliente = Convert.ToInt64(cb_idCliente.Text);
                    crud.FechaPedido = Convert.ToDateTime(dtp_pedido.Text);
                    crud.FechaEsperada = Convert.ToDateTime(dtp_esperada.Text);
                    crud.Comentarios = txt_comentarios.Text.Trim();
                    crud.Estado = cb_estado.Text.Trim();
                    
                    int affect = crud.EditarPedido();
                    if (affect > 0)
                    {
                        MessageBox.Show("actualizado");
                        limpiar();
                        refrescarGrid();
                    }


                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.CurrentRow;
                txt_idPedido.Text = row.Cells[0].Value.ToString();
                cb_idCliente.Text = row.Cells[1].Value.ToString();
                dtp_pedido.Text = row.Cells[2].Value.ToString();
                dtp_esperada.Text = row.Cells[3].Value.ToString();
                txt_comentarios.Text = row.Cells[4].Value.ToString();
                cb_estado.Text = row.Cells[5].Value.ToString();
                
            }
        }

        private void txt_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    
           //metodo para llenar el comboBox de idClientes y ordenarlo
        private void llenarCbCli(){
            cb_buscar.DataSource = crud.cargarClientes();
            cb_buscar.DisplayMember = "idCliente";
            cb_buscar.ValueMember = "idCliente";
            cb_idCliente.DataSource = crud.cargarClientes();
            cb_idCliente.DisplayMember = "idCliente";
            cb_idCliente.ValueMember = "idCliente";
            cb_idCliente.SelectedIndex = -1;
            cb_buscar.SelectedIndex = -1;
        }

        private void txt_eliminar_Click(object sender, EventArgs e)
        {
            if (!txt_idPedido.Text.Equals(""))
            {
                string id = dataGridView1.CurrentRow.Cells["idPedido"].Value.ToString();
                if (!String.IsNullOrEmpty(id))
                {

                    crud.IdPedido = Convert.ToInt64(id);
                    int affect = crud.EliminarPedido();

                    if (affect >= 1)
                    {
                        MessageBox.Show("eliminado");
                        refrescarGrid();
                        limpiar();
                    }
                }
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_mostrarTodo_Click(object sender, EventArgs e)
        {
            cb_buscar.SelectedIndex = -1;
            refrescarGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            crud.IdCliente = Convert.ToInt64(cb_buscar.Text.Trim());
            dataGridView1.DataSource = crud.buscarPedido();
        }
    }
}

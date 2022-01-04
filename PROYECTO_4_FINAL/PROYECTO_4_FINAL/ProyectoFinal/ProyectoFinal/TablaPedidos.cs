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
    public partial class TablaPedidos : Form
    {
        public TablaPedidos()
        {
            InitializeComponent();
        }
        CRUD_pedidos crud = new CRUD_pedidos();

        private void TablaPedidos_Load(object sender, EventArgs e)
        {
            
                dataGridView1.DataSource = crud.GetPedidos();

            
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

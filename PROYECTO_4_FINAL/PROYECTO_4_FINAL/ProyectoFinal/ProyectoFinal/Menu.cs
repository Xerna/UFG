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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clientes cl = new Clientes();
            cl.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pedidos p1 = new Pedidos();
            p1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Productos p1 = new Productos();
            p1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DetallePedidos p1 = new DetallePedidos();
            p1.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_pedidos_Click(object sender, EventArgs e)
        {
            Pedidos cl = new Pedidos();
            cl.Show();
            this.Hide();
        }

        private void btn_productos_Click(object sender, EventArgs e)
        {
            Productos cl = new Productos();
            cl.Show();
            this.Hide();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            DetallePedidos cl = new DetallePedidos();
            cl.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            InformacionAutores cl = new InformacionAutores();
            cl.Show();
            this.Hide();
        }
    }
}

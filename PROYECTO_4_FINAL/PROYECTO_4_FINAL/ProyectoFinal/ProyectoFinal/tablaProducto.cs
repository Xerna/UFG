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
    public partial class tablaProducto : Form
    {
        public tablaProducto()
        {
            InitializeComponent();
        }
        CRUD_productos crud = new CRUD_productos();

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void tablaProducto_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = crud.GetProductos();
        }
    }
}

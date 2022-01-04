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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private readonly CRUD_Clientes crud = new CRUD_Clientes();

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            int indiceEstado = cb_estado.SelectedIndex;

            if (!string.IsNullOrEmpty(txt_nombres.Text) && !string.IsNullOrEmpty(txt_apellidos.Text) && !string.IsNullOrEmpty(txt_telefono.Text) && !string.IsNullOrEmpty(txt_direccion.Text) && !string.IsNullOrEmpty(cb_departamento.Text) && !string.IsNullOrEmpty(cb_estado.Text))
            {
                char seleccionEs = Convert.ToChar(cb_estado.Items[indiceEstado].ToString());


                crud.Nombres = txt_nombres.Text.Trim();
                crud.Apellidos = txt_apellidos.Text.Trim();
                crud.Telefono = txt_telefono.Text.Trim();
                crud.Direccion = txt_direccion.Text.Trim();
                crud.Departamento = cb_departamento.Text.Trim();
                crud.Ciudad = cb_ciudad.Text.Trim();
                crud.Estado = seleccionEs;
                long id = crud.AgregarCliente();
                if (id > 0)
                {
                    MessageBox.Show("agregado");
                    limpiar();
                    refrescarGrid();
                }
            }
            else { MessageBox.Show("rellene los campos"); }
        }

        public void refrescarGrid()
        {
            dataGridView1.DataSource = crud.GetClientes();
        }

    

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cb_departamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_departamento.SelectedIndex)
            {
                case 0:
                    cb_ciudad.Items.Clear();
                    cb_ciudad.Items.Add("Ahuachapán");
                    cb_ciudad.Items.Add("Apaneca");
                    cb_ciudad.Items.Add("Atiquizaya");
                    cb_ciudad.Items.Add("Concepción de Ataco");
                    cb_ciudad.Items.Add("El Refugio");
                    cb_ciudad.Items.Add("Guaymango");
                    cb_ciudad.Items.Add("Jujutla");
                    cb_ciudad.Items.Add("San Francisco Menéndez");
                    cb_ciudad.Items.Add("San Lorenzo");
                    cb_ciudad.Items.Add("San Pedro Puxtla");
                    cb_ciudad.Items.Add("Tacuba");
                    cb_ciudad.Items.Add("Turín");
                    break;
                case 1:
                    cb_ciudad.Items.Clear();
                    cb_ciudad.Items.Add("Cinquera");
                    cb_ciudad.Items.Add("Dolores");
                    cb_ciudad.Items.Add("Guacotecti");
                    cb_ciudad.Items.Add("Ilobasco");
                    cb_ciudad.Items.Add("Jutiapa");
                    cb_ciudad.Items.Add("San Isidro");
                    cb_ciudad.Items.Add("Sensuntepeque");
                    cb_ciudad.Items.Add("Tejutepeque");
                    cb_ciudad.Items.Add("Victoria");
                    break;

                case 2:
                    cb_ciudad.Items.Clear();
                    cb_ciudad.Items.Add("Agua Caliente");
                    cb_ciudad.Items.Add("Arcatao");
                    cb_ciudad.Items.Add("Azacualpa");
                    cb_ciudad.Items.Add("Chalatenango");
                    cb_ciudad.Items.Add("Citalá");
                    cb_ciudad.Items.Add("Comalapa");
                    cb_ciudad.Items.Add("Concepción Quezaltepeque");
                    cb_ciudad.Items.Add("Dulce Nombre de María");
                    cb_ciudad.Items.Add("El Carrizal");
                    cb_ciudad.Items.Add("El Paraíso");
                    cb_ciudad.Items.Add("La Laguna");
                    cb_ciudad.Items.Add("La Palma");
                    cb_ciudad.Items.Add("La Reina");
                    cb_ciudad.Items.Add("Las Vueltas");
                    cb_ciudad.Items.Add("Nombre de Jesús");
                    cb_ciudad.Items.Add("Nueva Concepción");
                    cb_ciudad.Items.Add("Nueva Trinidad");
                    cb_ciudad.Items.Add("Ojos de Agua");
                    cb_ciudad.Items.Add("Potonico");
                    cb_ciudad.Items.Add("San Antonio de la Cruz");
                    cb_ciudad.Items.Add("San Antonio los Ranchos");
                    cb_ciudad.Items.Add("San Fernando");
                    cb_ciudad.Items.Add("San Francisco Lempa");
                    cb_ciudad.Items.Add("San Francisco Morazán");
                    cb_ciudad.Items.Add("San Ignacio");
                    cb_ciudad.Items.Add("San Isidro Labrador");
                    cb_ciudad.Items.Add("San José Cancasque");
                    cb_ciudad.Items.Add("San José Las Flores");
                    cb_ciudad.Items.Add("San Luis del Carmen");
                    cb_ciudad.Items.Add("San Miguel de Mercedes");
                    cb_ciudad.Items.Add("San Rafael");
                    cb_ciudad.Items.Add("Santa Rita");
                    break;

                case 3:
                    cb_ciudad.Items.Clear();
                    cb_ciudad.Items.Add("Candelaria");
                    cb_ciudad.Items.Add("Cojutepeque");
                    cb_ciudad.Items.Add("El Carmen");
                    cb_ciudad.Items.Add("El Rosario");
                    cb_ciudad.Items.Add("Monte San Juan");
                    cb_ciudad.Items.Add("Oratorio de Concepción");
                    cb_ciudad.Items.Add("San Bartolomé Perulapía");
                    cb_ciudad.Items.Add("San Cristóbal");
                    cb_ciudad.Items.Add("San José Guayabal");
                    cb_ciudad.Items.Add("San Pedro Perulapán");
                    cb_ciudad.Items.Add("San Rafael Cedros");
                    cb_ciudad.Items.Add("San Ramón");
                    cb_ciudad.Items.Add("Santa Cruz Analquito");
                    cb_ciudad.Items.Add("Santa Cruz Michapa");
                    cb_ciudad.Items.Add("Suchitoto");
                    break;

                case 4:
                    cb_ciudad.Items.Clear();
                    cb_ciudad.Items.Add("Antiguo Cuscatlán");
                    cb_ciudad.Items.Add("Chiltiupán");
                    cb_ciudad.Items.Add("Ciudad Arce");
                    cb_ciudad.Items.Add("Colón");
                    cb_ciudad.Items.Add("Comasagua");
                    cb_ciudad.Items.Add("Huizúcar");
                    cb_ciudad.Items.Add("Jayaque");
                    cb_ciudad.Items.Add("Jicalapa");
                    cb_ciudad.Items.Add("La libertad");
                    cb_ciudad.Items.Add("Nuevo Cuscatlán");
                    cb_ciudad.Items.Add("Opico");
                    cb_ciudad.Items.Add("Quezaltepeque");
                    cb_ciudad.Items.Add("Sacacoyo");
                    cb_ciudad.Items.Add("San José Villanueva");
                    cb_ciudad.Items.Add("San Matías");
                    cb_ciudad.Items.Add("San Pablo Tacachico");
                    cb_ciudad.Items.Add("Santa Tecla");
                    cb_ciudad.Items.Add("Talnique");
                    cb_ciudad.Items.Add("Tamanique");
                    cb_ciudad.Items.Add("Teotepeque");
                    cb_ciudad.Items.Add("Tepecoyo");
                    cb_ciudad.Items.Add("Zaragoza");
                    break;

                case 5:
                    cb_ciudad.Items.Clear();
                    cb_ciudad.Items.Add("Cuyultitán");
                    cb_ciudad.Items.Add("El Rosario");
                    cb_ciudad.Items.Add("Jerusalén");
                    cb_ciudad.Items.Add("Mercedes La Ceiba");
                    cb_ciudad.Items.Add("Olocuilta");
                    cb_ciudad.Items.Add("Paraíso de Osorio");
                    cb_ciudad.Items.Add("San Antonio Masahuat");
                    cb_ciudad.Items.Add("San Emigdio");
                    cb_ciudad.Items.Add("San Francisco Chinameca");
                    cb_ciudad.Items.Add("San Juan Nonualco");
                    cb_ciudad.Items.Add("San Juan Talpa");
                    cb_ciudad.Items.Add("San Juan Tepezontes");
                    cb_ciudad.Items.Add("San Luis La Herradura");
                    cb_ciudad.Items.Add("San Luis Talpa");
                    cb_ciudad.Items.Add("San Miguel Tepezontes");
                    cb_ciudad.Items.Add("San Pedro Masahuat");
                    cb_ciudad.Items.Add("San Pedro Nonualco");
                    cb_ciudad.Items.Add("San Rafael Obrajuelo");
                    cb_ciudad.Items.Add("Santa María Ostuma");
                    cb_ciudad.Items.Add("Santiago Nonualco");
                    cb_ciudad.Items.Add("Tapalhuaca");
                    cb_ciudad.Items.Add("Zacatecoluca");
                    cb_ciudad.Items.Add("");
                    break;

                case 6:
                    cb_ciudad.Items.Clear();
                    cb_ciudad.Items.Add("Anamoros");
                    cb_ciudad.Items.Add("Bolívar");
                    cb_ciudad.Items.Add("Concepcion de Oriente");
                    cb_ciudad.Items.Add("Conchagua");
                    cb_ciudad.Items.Add("El Carmen");
                    cb_ciudad.Items.Add("El Sauce");
                    cb_ciudad.Items.Add("Intipuca");
                    cb_ciudad.Items.Add("La Unión");
                    cb_ciudad.Items.Add("Lislique");
                    cb_ciudad.Items.Add("Meanguera del Golfo");
                    cb_ciudad.Items.Add("Nueva Esparta");
                    cb_ciudad.Items.Add("Pasaquina");
                    cb_ciudad.Items.Add("Polorós");
                    cb_ciudad.Items.Add("San Alejo");
                    cb_ciudad.Items.Add("San José");
                    cb_ciudad.Items.Add("Santa Rosa de Lima");
                    cb_ciudad.Items.Add("Yayantique");
                    cb_ciudad.Items.Add("Yucuaiquín");
                    break;

                case 7:
                    cb_ciudad.Items.Clear();
                    cb_ciudad.Items.Add("Arambala");
                    cb_ciudad.Items.Add("Cacaopera");
                    cb_ciudad.Items.Add("Chilanga");
                    cb_ciudad.Items.Add("Chilanga");
                    cb_ciudad.Items.Add("Corinto");
                    cb_ciudad.Items.Add("Delicias de Concepción");
                    cb_ciudad.Items.Add("El Divisadero");
                    cb_ciudad.Items.Add("El Rosario");
                    cb_ciudad.Items.Add("Gualococti");
                    cb_ciudad.Items.Add("Guatajiagua");
                    cb_ciudad.Items.Add("Joateca");
                    cb_ciudad.Items.Add("Jocoaitique");
                    cb_ciudad.Items.Add("Jocoro");
                    cb_ciudad.Items.Add("Lolotiquillo");
                    cb_ciudad.Items.Add("Meanguera");
                    cb_ciudad.Items.Add("Osicala");
                    cb_ciudad.Items.Add("Perquín");
                    cb_ciudad.Items.Add("San Carlos");
                    cb_ciudad.Items.Add("San Fernando");
                    cb_ciudad.Items.Add("San Francisco Gotera");
                    cb_ciudad.Items.Add("San Isidro");
                    cb_ciudad.Items.Add("San Simón");
                    cb_ciudad.Items.Add("Sensembra");
                    cb_ciudad.Items.Add("Sociedad");
                    cb_ciudad.Items.Add("Torola");
                    cb_ciudad.Items.Add("Yamabal");
                    cb_ciudad.Items.Add("Yoloaiquín");
                    break;
                case 8:
                    cb_ciudad.Items.Clear();
                    cb_ciudad.Items.Add("Carolina");
                    cb_ciudad.Items.Add("Chapeltique");
                    cb_ciudad.Items.Add("Chinameca");
                    cb_ciudad.Items.Add("Chirilagua");
                    cb_ciudad.Items.Add("Ciudad Barrios");
                    cb_ciudad.Items.Add("Comacarán");
                    cb_ciudad.Items.Add("El Tránsito");
                    cb_ciudad.Items.Add("Lolotique");
                    cb_ciudad.Items.Add("Moncagua");
                    cb_ciudad.Items.Add("Nueva Guadalupe");
                    cb_ciudad.Items.Add("Nuevo Edén de San Juan");
                    cb_ciudad.Items.Add("Quelepa");
                    cb_ciudad.Items.Add("San Antonio");
                    cb_ciudad.Items.Add("San Gerardo");
                    cb_ciudad.Items.Add("San Jorge");
                    cb_ciudad.Items.Add("San Luis de la Reina");
                    cb_ciudad.Items.Add("San Miguel");
                    cb_ciudad.Items.Add("San Rafael Oriente");
                    cb_ciudad.Items.Add("Sesori");
                    cb_ciudad.Items.Add("Uluazapa");

                    break;

                case 9:
                    cb_ciudad.Items.Clear();
                    cb_ciudad.Items.Add("Aguilares");
                    cb_ciudad.Items.Add("Apopa");
                    cb_ciudad.Items.Add("Ayutuxtepeque");
                    cb_ciudad.Items.Add("Cuscatancingo");
                    cb_ciudad.Items.Add("Delgado");
                    cb_ciudad.Items.Add("El Paisnal");
                    cb_ciudad.Items.Add("Guazapa");
                    cb_ciudad.Items.Add("Ilopango");
                    cb_ciudad.Items.Add("Mejicanos");
                    cb_ciudad.Items.Add("Nejapa");
                    cb_ciudad.Items.Add("Panchimalco");
                    cb_ciudad.Items.Add("Rosario de Mora");
                    cb_ciudad.Items.Add("San Marcos");
                    cb_ciudad.Items.Add("San Martín");
                    cb_ciudad.Items.Add("San Salvador");
                    cb_ciudad.Items.Add("Santiago Texacuangos");
                    cb_ciudad.Items.Add("Santo Tomás");
                    cb_ciudad.Items.Add("Soyapango");
                    cb_ciudad.Items.Add("Tonacatepeque");

                    break;

                case 10:
                    cb_ciudad.Items.Clear();
                    cb_ciudad.Items.Add("Apastepeque");
                    cb_ciudad.Items.Add("Guadalupe");
                    cb_ciudad.Items.Add("San Cayetano Istepeque");
                    cb_ciudad.Items.Add("San Esteban Catarina");
                    cb_ciudad.Items.Add("San Ildefonso");
                    cb_ciudad.Items.Add("San Lorenzo");
                    cb_ciudad.Items.Add("San Sebastián");
                    cb_ciudad.Items.Add("Santa Clara");
                    cb_ciudad.Items.Add("Santo Domingo");
                    cb_ciudad.Items.Add("San Vicente");
                    cb_ciudad.Items.Add("Tecoluca");
                    cb_ciudad.Items.Add("Tepetitán");
                    cb_ciudad.Items.Add("Verapaz");

                    break;

                case 11:
                    cb_ciudad.Items.Clear();
                    cb_ciudad.Items.Add("Candelaria de la Frontera");
                    cb_ciudad.Items.Add("Chalchuapa");
                    cb_ciudad.Items.Add("Coatepeque");
                    cb_ciudad.Items.Add("El Congo");
                    cb_ciudad.Items.Add("El Porvenir");
                    cb_ciudad.Items.Add("Metapán");
                    cb_ciudad.Items.Add("Masahuat");
                    cb_ciudad.Items.Add("San Antonio Pajonal");
                    cb_ciudad.Items.Add("San Sebastián Salitrillo");
                    cb_ciudad.Items.Add("Santa Ana");
                    cb_ciudad.Items.Add("Santa Rosa Guachipilín");
                    cb_ciudad.Items.Add("Santiago de la Frontera");
                    cb_ciudad.Items.Add("Texistepeque");

                    break;

                case 12:
                    cb_ciudad.Items.Clear();
                    cb_ciudad.Items.Add("Acajutla");
                    cb_ciudad.Items.Add("Armenia");
                    cb_ciudad.Items.Add("Caluco");
                    cb_ciudad.Items.Add("Cuisnahuat");
                    cb_ciudad.Items.Add("Izalco");
                    cb_ciudad.Items.Add("Juayúa");
                    cb_ciudad.Items.Add("Nahuizalco");
                    cb_ciudad.Items.Add("Nahulingo");
                    cb_ciudad.Items.Add("Salcoatitán");
                    cb_ciudad.Items.Add("San Antonio del Monte");
                    cb_ciudad.Items.Add("San Julián");
                    cb_ciudad.Items.Add("Santa Catarina Masahuat");
                    cb_ciudad.Items.Add("Santa Isabel Ishuatán");
                    cb_ciudad.Items.Add("Santo Domingo");
                    cb_ciudad.Items.Add("Sonsonate");
                    cb_ciudad.Items.Add("Sonzacate");
                    break;

                case 13:
                    cb_ciudad.Items.Clear();
                    cb_ciudad.Items.Add("Alegría");
                    cb_ciudad.Items.Add("Berlín");
                    cb_ciudad.Items.Add("California");
                    cb_ciudad.Items.Add("Concepción Batres");
                    cb_ciudad.Items.Add("El Triunfo");
                    cb_ciudad.Items.Add("Ereguayquín");
                    cb_ciudad.Items.Add("Estanzuelas");
                    cb_ciudad.Items.Add("Jiquilisco");
                    cb_ciudad.Items.Add("Jucuapa");
                    cb_ciudad.Items.Add("Jucuarán");
                    cb_ciudad.Items.Add("Mercedes Umaña");
                    cb_ciudad.Items.Add("Nueva Granada");
                    cb_ciudad.Items.Add("Ozatlán");
                    cb_ciudad.Items.Add("Puerto El Triunfo");
                    cb_ciudad.Items.Add("San Agustín");
                    cb_ciudad.Items.Add("San Buenaventura");
                    cb_ciudad.Items.Add("San Dionisio");
                    cb_ciudad.Items.Add("San Francisco Javier");
                    cb_ciudad.Items.Add("Santa Elena");
                    cb_ciudad.Items.Add("Santa María");
                    cb_ciudad.Items.Add("Santiago de María");
                    cb_ciudad.Items.Add("Tecapán");
                    cb_ciudad.Items.Add("Usulután");
                    break;
            }
        }

        private void txt_actualizar_Click(object sender, EventArgs e)
        {
            int indiceEstado = cb_estado.SelectedIndex;

            if (!txt_id.Text.Equals(""))
            {
                string id = dataGridView1.CurrentRow.Cells["idCliente"].Value.ToString();
                if (!string.IsNullOrEmpty(id))
                {
                    char seleccionEs = Convert.ToChar(cb_estado.Items[indiceEstado].ToString());
                    crud.IdClientes = Convert.ToInt64(id);
                    crud.Nombres = txt_nombres.Text.Trim();
                    crud.Apellidos = txt_apellidos.Text.Trim();
                    crud.Telefono = txt_telefono.Text.Trim();
                    crud.Direccion = txt_direccion.Text.Trim();
                    crud.Departamento = cb_departamento.Text.Trim();
                    crud.Ciudad = cb_ciudad.Text.Trim();
                    crud.Estado = seleccionEs;

                    int affect = crud.EditarCliente();
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

        public void limpiar()
        {
            refrescarGrid();
            txt_id.Clear();
            txt_nombres.Clear();
            txt_apellidos.Clear();
            txt_telefono.Clear();
            txt_direccion.Clear();
            cb_departamento.SelectedIndex = -1;
            cb_ciudad.Items.Clear();
            cb_estado.SelectedIndex = -1;

           

        }

        private void txt_eliminar_Click(object sender, EventArgs e)
        {
            if (!txt_id.Text.Equals(""))
            {
                string id = dataGridView1.CurrentRow.Cells["idCliente"].Value.ToString();
                if (!String.IsNullOrEmpty(id))
                {

                    crud.IdClientes = Convert.ToInt64(id);
                    int affect = crud.EliminarCliente();

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

        private void txt_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            refrescarGrid();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            crud.ApellidosBusqueda = txt_buscar.Text.Trim();
            dataGridView1.DataSource = crud.buscarCliente();
        }

        private void btn_mostrarTodo_Click(object sender, EventArgs e)
        {
            txt_buscar.Clear();
            refrescarGrid();
        }

  

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.CurrentRow;
                txt_id.Text = row.Cells[0].Value.ToString();
                txt_nombres.Text = row.Cells[1].Value.ToString();
                txt_apellidos.Text = row.Cells["apellidos"].Value.ToString();
                txt_telefono.Text = row.Cells["telefono"].Value.ToString();
                txt_direccion.Text = row.Cells["direccion"].Value.ToString();
                string departamento = row.Cells["departamento"].Value.ToString();
                cb_departamento.SelectedIndex = dep(departamento);
                cb_ciudad.Text = row.Cells["ciudad"].Value.ToString();
                cb_estado.Text = row.Cells["estado"].Value.ToString();
            }
        }

        public int dep(string departamento)
        {
            int index = 0;
            if (departamento == "Ahuachapán")
            {
                index = 0;
            }
            else if (departamento == "Cabañas") { index = 1; }
            else if (departamento == "Chalatenango") { index = 2; }
            else if (departamento == "Cuscatlán ") { index = 3; }
            else if (departamento == "La Libertad") { index = 4; }
            else if (departamento == "La Paz") { index = 5; }
            else if (departamento == "La Unión") { index = 6; }
            else if (departamento == "Morazán") { index = 7; }
            else if (departamento == "San Miguel") { index = 8; }
            else if (departamento == "San Salvador") { index = 9; }
            else if (departamento == "San Vicente") { index = 10; }
            else if (departamento == "Santa Ana") { index = 11; }
            else if (departamento == "Sonsonate") { index = 12; }
            else if (departamento == "Usulután") { index = 13; }
            /*devuelve el numero del departamento de combobox*/
            return index;
        }

        private void btn_search_Click_1(object sender, EventArgs e)
        {
         
        }

        private void btn_mostrarTodo_Click_1(object sender, EventArgs e)
        {
            txt_buscar.Clear();
            refrescarGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_buscar.Text)) { 
            crud.ApellidosBusqueda = txt_buscar.Text.Trim();
            dataGridView1.DataSource = crud.buscarCliente();
            }
            else { MessageBox.Show("Ingrese algo para buscar", "Precaución", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
            
        }

        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show("Solo se admiten datos numericos ", "validación de numero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}

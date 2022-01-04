using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    class CRUD_Clientes
    {
        //atributos 

        private long idClientes;
        private string nombres;
        private string apellidos;
        private string telefono;
        private string direccion;
        private string ciudad;
        private string departamento;
        private char estado;
        private string apellidosBusqueda;

        //constructor vacio
        public CRUD_Clientes(){}

        //Constructor 
        public CRUD_Clientes(long idClientes, string nombres, string apellidos, string telefono, string direccion, string ciudad, string departamento, char estado, string apellidosBusqueda)
        {
            this.idClientes = idClientes;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.direccion = direccion;
            this.ciudad = ciudad;
            this.departamento = departamento;
            this.estado = estado;
            this.apellidosBusqueda = apellidosBusqueda;
        }

        //constructor vacio


        //Encapsulamiento
        public long IdClientes { get => idClientes; set => idClientes = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Departamento { get => departamento; set => departamento = value; }
        public char Estado { get => estado; set => estado = value; }
        public string ApellidosBusqueda { get => apellidosBusqueda; set => apellidosBusqueda = value; }

        //Metodo para rellenar la tabla
        public DataTable GetClientes()
        {
            DataTable mydt = new DataTable();
            Conexion conectar = new Conexion();
            SqlConnection conn = conectar.ConexionServer();
            //idDireccion,nombre,apellidos,email,telefono,apodo
            string sql = "SELECT * FROM clientes;";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader mydr = null;
            try
            {
                conn.Open();
                mydr = cmd.ExecuteReader();
                mydt.Load(mydr);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return mydt;


        }
        //fin de Metodo para rellenar la tabla

        //Metodo para guardar datos en la tabla clientes
        public long AgregarCliente()
        {
            long id = 0;
            Conexion conectar = new Conexion();
            SqlConnection conn = conectar.ConexionServer();
            string insertSql = "Insert Into clientes (nombres,apellidos,telefono,direccion,ciudad,departamento,estado) values(@nombres,@apellidos,@telefono,@direccion,@ciudad,@departamento,@estado); SELECT IDENT_CURRENT('clientes') as id";
            SqlCommand cmd = new SqlCommand(insertSql, conn);
            cmd.Parameters.AddWithValue("@nombres", this.nombres);
            cmd.Parameters.AddWithValue("@apellidos", this.apellidos);
            cmd.Parameters.AddWithValue("@telefono", this.telefono);
            cmd.Parameters.AddWithValue("@direccion", this.direccion);
            cmd.Parameters.AddWithValue("@ciudad", this.ciudad);
            cmd.Parameters.AddWithValue("@departamento", this.departamento);
            cmd.Parameters.AddWithValue("@estado", this.estado);
            try
            {
                conn.Open();
                id = Convert.ToInt64(cmd.ExecuteScalar());
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return id;
        }
        //fin metodo para guardar datos en la tabla clientes

        //metodo para editar datos en la tabla clientes
        public int EditarCliente()
        {
            int affected = 0;
            Conexion conectar = new Conexion();
            SqlConnection conn = conectar.ConexionServer();

            string updateSql = "UPDATE clientes SET nombres=@nombre ,apellidos=@apellidos, telefono=@telefono, direccion=@direccion, ciudad=@ciudad, departamento=@departamento, estado=@estado WHERE idCliente= @idCliente;";
            SqlCommand cmd = new SqlCommand(updateSql, conn);
            cmd.Parameters.AddWithValue("@nombre", this.nombres);
            cmd.Parameters.AddWithValue("@apellidos", this.apellidos);
            cmd.Parameters.AddWithValue("@telefono", this.telefono);
            cmd.Parameters.AddWithValue("@direccion", this.direccion);
            cmd.Parameters.AddWithValue("@ciudad", this.ciudad);
            cmd.Parameters.AddWithValue("@departamento", this.departamento);
            cmd.Parameters.AddWithValue("@estado", this.estado);
            cmd.Parameters.AddWithValue("@idCliente", this.idClientes);
            try
            {
                conn.Open();
                affected = cmd.ExecuteNonQuery();
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return affected;
        }
        //fin metodo para editar datos en la tabla clientes

        //metodo para eliminar datos en la tabla clientes
        public int EliminarCliente()
        {
            int affected = 0;
            Conexion conectar = new Conexion();
            SqlConnection conn = conectar.ConexionServer();
            string deleteSql = "delete from clientes where idCliente=@idCliente;";
            SqlCommand cmd = new SqlCommand(deleteSql, conn);
            cmd.Parameters.AddWithValue("@idCliente", this.idClientes);
            try
            {
                conn.Open();
                affected = cmd.ExecuteNonQuery();
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return affected;
        }
        //Fin metodo para eliminar datos en la tabla clientes

        //metodo para buscar
        public DataTable buscarCliente()
        {

            DataTable mydt = new DataTable();
            Conexion conectar = new Conexion();
            SqlConnection conn = conectar.ConexionServer();


            string sql = "SELECT * FROM clientes where apellidos like '%" + ApellidosBusqueda + "%';";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader mydr = null;
            try
            {
                conn.Open();
                mydr = cmd.ExecuteReader();
                mydt.Load(mydr);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return mydt;


        }
    }
}

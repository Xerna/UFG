using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    class CRUD_pedidos
    {
        private long idPedido;
        private long idCliente;
        private DateTime fechaPedido;
        private DateTime fechaEsperada;
        private string comentarios;
        private string estado;
       

        //constructor vacio
        public CRUD_pedidos(){}

        //constrctor 
        public CRUD_pedidos(long idPedido, long idCliente, DateTime fechaPedido, DateTime fechaEntregado, string comentarios, string estado)
        {
            this.idPedido = idPedido;
            this.idCliente = idCliente;
            this.fechaPedido = fechaPedido;
            this.fechaEsperada = fechaEntregado;
            this.comentarios = comentarios;
            this.estado = estado;
        }

        //Encapsulamiento
        public long IdPedido { get => idPedido; set => idPedido = value; }
        public long IdCliente { get => idCliente; set => idCliente = value; }
        public DateTime FechaPedido { get => fechaPedido; set => fechaPedido = value; }
        public DateTime FechaEsperada { get => fechaEsperada; set => fechaEsperada = value; }
        public string Comentarios { get => comentarios; set => comentarios = value; }
        public string Estado { get => estado; set => estado = value; }


        //Metodo para rellenar la tabla
        public DataTable GetPedidos()
        {
            DataTable mydt = new DataTable();
            Conexion conectar = new Conexion();
            SqlConnection conn = conectar.ConexionServer();
            //idDireccion,nombre,apellidos,email,telefono,apodo
            string sql = "SELECT * FROM pedidos;";
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
        public long AgregarPedido()
        {
            long id = 0;
            Conexion conectar = new Conexion();
            SqlConnection conn = conectar.ConexionServer();
            string insertSql = "Insert Into pedidos(idCliente,fechaPedido,fechaEsperada,comentario,estado) values(@idCliente, @fechaPedido,@fechaEsperada,@comentarios,@estado); SELECT IDENT_CURRENT('pedidos') as id";
            SqlCommand cmd = new SqlCommand(insertSql, conn);
            cmd.Parameters.AddWithValue("@idCliente", this.IdCliente);
            cmd.Parameters.AddWithValue("@fechaPedido", this.fechaPedido);
            cmd.Parameters.AddWithValue("@fechaEsperada", this.fechaEsperada);
            cmd.Parameters.AddWithValue("@comentarios", this.comentarios);
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
        public int EditarPedido()
        {
            int affected = 0;
            Conexion conectar = new Conexion();
            SqlConnection conn = conectar.ConexionServer();
           
            
            string updateSql = "UPDATE pedidos SET idCliente = @idCliente, fechaPedido=@fechaPedido, fechaEsperada=@fechaEsperada, comentario=@comentarios, estado=@estado WHERE idPedido= @idPedido;";
            SqlCommand cmd = new SqlCommand(updateSql, conn);
            cmd.Parameters.AddWithValue("@idCliente", this.idCliente);
            cmd.Parameters.AddWithValue("@fechaPedido", fechaPedido);
            cmd.Parameters.AddWithValue("@fechaEsperada", fechaEsperada);
            cmd.Parameters.AddWithValue("@comentarios", this.comentarios);
            cmd.Parameters.AddWithValue("@estado", this.estado);
            cmd.Parameters.AddWithValue("@idPedido", this.idPedido); 
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
        public int EliminarPedido()
        {
            int affected = 0;
            Conexion conectar = new Conexion();
            SqlConnection conn = conectar.ConexionServer();
            string deleteSql = "delete from pedidos where idPedido=@idPedido;";
            SqlCommand cmd = new SqlCommand(deleteSql, conn);
            cmd.Parameters.AddWithValue("@idPedido", this.idPedido);
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

        //metodo para cargar el comboBox de idClientes para no generar un error a la hora de ingresar la 
        //lave foranea
        public DataTable cargarClientes(){
            Conexion cn = new Conexion();
            SqlDataAdapter da = new SqlDataAdapter("CARGARIDCL", cn.ConexionServer());
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }


        //metodo para buscar pedido
        public DataTable buscarPedido()
        {

            DataTable mydt = new DataTable();
            Conexion conectar = new Conexion();
            SqlConnection conn = conectar.ConexionServer();


            string sql = "SELECT * FROM pedidos where idCliente like '%" + idCliente + "%';";

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

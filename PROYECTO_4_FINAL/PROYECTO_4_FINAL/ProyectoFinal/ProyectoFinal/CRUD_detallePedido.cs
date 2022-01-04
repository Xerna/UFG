using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    class CRUD_detallePedido
    {
        private long idDetallePedido;
        private long idPedido;
        private long idProducto;
        private double precioUnidad;
        private int numeroLinea;
        private char estado;

       

        //constructor vacio
        public CRUD_detallePedido() { }

        //Constructor
        public CRUD_detallePedido(long idDetallePedido, long idPedido, long idProducto, double precioUnidad, int numeroLinea, char estado)
        {
            this.idDetallePedido = idDetallePedido;
            this.idPedido = idPedido;
            this.idProducto = idProducto;
            this.precioUnidad = precioUnidad;
            this.numeroLinea = numeroLinea;
            this.estado = estado;
        }
        //Encapsulamiento
        public long IdDetallePedido { get => idDetallePedido; set => idDetallePedido = value; }
        public long IdPedido { get => idPedido; set => idPedido = value; }
        public long IdProducto { get => idProducto; set => idProducto = value; }
        public double PrecioUnidad { get => precioUnidad; set => precioUnidad = value; }
        public int NumeroLinea { get => numeroLinea; set => numeroLinea = value; }
        public char Estado { get => estado; set => estado = value; }

        //Metodo para rellenar la tabla
        public DataTable GetDetallePedido()
        {
            DataTable mydt = new DataTable();
            Conexion conectar = new Conexion();
            SqlConnection conn = conectar.ConexionServer();
            //idDireccion,nombre,apellidos,email,telefono,apodo
            string sql = "SELECT * FROM detallePedido;";
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
        public long AgregarDetallePedido()
        {
            long id = 0;
            Conexion conectar = new Conexion();
            SqlConnection conn = conectar.ConexionServer();
            string insertSql = "Insert Into detallePedido (idPedido,idProducto,precioUnidad,numeroLinea,estado) values(@idPedido,@idProducto,@precioUnidad,@numeroLinea,@estado); SELECT IDENT_CURRENT('detallePedido') as id";
            SqlCommand cmd = new SqlCommand(insertSql, conn);
            cmd.Parameters.AddWithValue("@idPedido", this.idPedido);
            cmd.Parameters.AddWithValue("@idProducto", this.idProducto);
            cmd.Parameters.AddWithValue("@precioUnidad", this.precioUnidad);
            cmd.Parameters.AddWithValue("@numeroLinea", this.numeroLinea);
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
        public int EditarDetallePedido()
        {
            int affected = 0;
            Conexion conectar = new Conexion();
            SqlConnection conn = conectar.ConexionServer();

            string updateSql = "UPDATE detallePedido SET idPedido = @idPedido, idProducto = @idProducto, precioUnidad = @precioUnidad, numeroLinea = @numeroLinea, estado=@estado  WHERE idDetallePedido = @id;";
            SqlCommand cmd = new SqlCommand(updateSql, conn);
            cmd.Parameters.AddWithValue("@idPedido", this.idPedido);
            cmd.Parameters.AddWithValue("@idProducto", this.idProducto);
            cmd.Parameters.AddWithValue("@precioUnidad", this.precioUnidad);
            cmd.Parameters.AddWithValue("@numeroLinea", this.numeroLinea);
            cmd.Parameters.AddWithValue("@estado", this.estado);
            cmd.Parameters.AddWithValue("@id", this.idDetallePedido);
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
        public int EliminarDetallePedido()
        {
            int affected = 0;
            Conexion conectar = new Conexion();
            SqlConnection conn = conectar.ConexionServer();
            string deleteSql = "delete from detallePedido where idDetallePedido=@id;";
            SqlCommand cmd = new SqlCommand(deleteSql, conn);
            cmd.Parameters.AddWithValue("@id", this.IdDetallePedido);
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
        public DataTable buscarDetallePedido()
        {

            DataTable mydt = new DataTable();
            Conexion conectar = new Conexion();
            SqlConnection conn = conectar.ConexionServer();


           string sql = "SELECT * FROM detallePedido where idPedido like '%" + idPedido+ "%';";

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

        public DataTable cargarIdPedido()
        {
            Conexion cn = new Conexion();
            SqlDataAdapter da = new SqlDataAdapter("cargarIdPedido", cn.ConexionServer());
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public DataTable cargarIdProducto()
        {
            Conexion cn = new Conexion();
            SqlDataAdapter da = new SqlDataAdapter("cargarIdProducto", cn.ConexionServer());
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
    }
}

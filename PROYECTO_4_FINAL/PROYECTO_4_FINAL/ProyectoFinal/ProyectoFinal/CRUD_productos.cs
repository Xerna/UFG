using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    class CRUD_productos
    {
        private long idProducto;
        private string producto;
        private string descripcion;
        private int cantidadEnStock;
        private double precioVenta;
        private char estado;

      

        //constructor vacio
        public CRUD_productos() { }

        //constrctor 
        public CRUD_productos(long idProducto, string producto, string descripcion, int cantidadEnStock, double precioVenta, char estado)
        {
            this.idProducto = idProducto;
            this.producto = producto;
            this.descripcion = descripcion;
            this.cantidadEnStock = cantidadEnStock;
            this.precioVenta = precioVenta;
            this.estado = estado;
        }

        //Encapsulamiento
        public long IdProducto { get => idProducto; set => idProducto = value; }
        public string Producto { get => producto; set => producto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int CantidadEnStock { get => cantidadEnStock; set => cantidadEnStock = value; }
        public double PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public char Estado { get => estado; set => estado = value; }



        //Metodo para rellenar la tabla
        public DataTable GetProductos()
        {
            DataTable mydt = new DataTable();
            Conexion conectar = new Conexion();
            SqlConnection conn = conectar.ConexionServer();
            //idDireccion,nombre,apellidos,email,telefono,apodo
            string sql = "SELECT * FROM productos;";
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
        public long AgregarProdcutos()
        {
            long id = 0;
            Conexion conectar = new Conexion();
            SqlConnection conn = conectar.ConexionServer();
            string insertSql = "Insert Into productos(producto,descripcion,cantidadEnStock,precioVenta,estado) values(@producto,@descripcion,@cantidadEnStock,@precioVenta,@estado); SELECT IDENT_CURRENT('productos') as id";
            SqlCommand cmd = new SqlCommand(insertSql, conn);
            cmd.Parameters.AddWithValue("@producto", this.producto);
            cmd.Parameters.AddWithValue("@descripcion", this.descripcion);
            cmd.Parameters.AddWithValue("@cantidadEnStock", this.cantidadEnStock);
            cmd.Parameters.AddWithValue("@precioVenta", this.precioVenta);
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
        public int EditarProducto()
        {
            int affected = 0;
            Conexion conectar = new Conexion();
            SqlConnection conn = conectar.ConexionServer();


            string updateSql = "UPDATE productos SET  producto=@producto,  descripcion=@descripcion, cantidadEnStock=@cantidadEnStock, precioVenta=@precioVenta, estado = @estado WHERE idProducto= @idProducto;";
            SqlCommand cmd = new SqlCommand(updateSql, conn);
            cmd.Parameters.AddWithValue("@producto", this.producto);
            cmd.Parameters.AddWithValue("@descripcion", this.descripcion);
            cmd.Parameters.AddWithValue("@cantidadEnStock", this.cantidadEnStock);
            cmd.Parameters.AddWithValue("@precioVenta", this.precioVenta);
            cmd.Parameters.AddWithValue("@estado", this.estado);
            cmd.Parameters.AddWithValue("@idProducto", this.idProducto);

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
        public int EliminarProducto()
        {
            int affected = 0;
            Conexion conectar = new Conexion();
            SqlConnection conn = conectar.ConexionServer();
            string deleteSql = "delete from productos where idProducto=@idProductos;";
            SqlCommand cmd = new SqlCommand(deleteSql, conn);
            cmd.Parameters.AddWithValue("@idProductos", this.idProducto);
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

     
        //metodo para buscar pedido
        public DataTable buscarProdcutos()
        {

            DataTable mydt = new DataTable();
            Conexion conectar = new Conexion();
            SqlConnection conn = conectar.ConexionServer();


            string sql = "SELECT * FROM productos where producto like '%" + producto+ "%';";

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

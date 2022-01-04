using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    class Conexion
    {
        public SqlConnection ConexionServer()
        {

            SqlConnection conn;

            try
            {
                string cadenaConexion = "Data Source=XERNA\SQLEXPRESS;Initial Catalog=Pedidos;Integrated Security=True";
                conn = new SqlConnection(cadenaConexion);

            }
            catch (Exception ex)
            {
                throw new ArgumentException("error al conectar", ex);

            }
            return conn;
        }
    }
}

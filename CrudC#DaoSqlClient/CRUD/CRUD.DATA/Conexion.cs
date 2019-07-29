using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CRUD.DATA
{
    public class Conexion
    {
        public SqlConnection objConexion;
        public SqlCommand objCommand;
        public SqlDataReader objDataReader;
        private String conexionString;
            
        public Conexion() {
            try
            {
                conexionString = Properties.Settings.Default.ConexionStringBandas;
                objConexion = new SqlConnection(conexionString);
            }
            catch(Exception e){
                System.Console.WriteLine(e.Message.ToString());
            }
        }
    }
}

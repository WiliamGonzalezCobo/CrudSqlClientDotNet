using System;
using System.Collections.Generic;
using CRUD.DATA;
using CRUD.ENTIDADES;
using System.Data.SqlClient;
using System.Data;


namespace CRUD.DAO
{
    public class Banda
    {
        private Conexion objConx;
        private string  SqlConnex { get; set; }

        public Banda()
        {
            objConx = new Conexion();
            SqlConnex = "";
        }
        /// <summary>
        /// insertamos un registro de banda en base de datos.
        /// </summary>
        /// <param name="objBanda"></param>
        public String insertBanda(BandaClass objBanda)
        {

            String insert = "INSERT INTO [dbo].[tb_bandas]"
                             + "([vchNombre],[vchTipo])"
               + "VALUES('" + objBanda.StrNombre + "','" + objBanda.StrTipo + "')";
            return ejecutarSqlQuery(insert);

        }

        /// <summary>
        /// insertamos un registro de banda en base de datos usando procedimiento almacenado.
        /// </summary>
        /// <param name="objBanda"></param>
        public String insertBandasp(BandaClass objBanda)
        {
            try
            {
                objConx.objCommand = new SqlCommand("sp_Tb_bandas_Insert", objConx.objConexion);
                objConx.objCommand.CommandType = CommandType.StoredProcedure;
                objConx.objCommand.Parameters.AddWithValue("@vchNombre", objBanda.StrNombre);
                objConx.objCommand.Parameters.AddWithValue("@vchTipo", objBanda.StrTipo);

                objConx.objConexion.Open();
                objConx.objCommand.ExecuteNonQuery();

                return "Se inserto el Registro Correctamente.";
            }
            catch (Exception e)
            {

                return "Error Insertando Registro: "+ e.Message;

            }
            finally
            {
                if (objConx.objConexion != null)
                {
                    objConx.objConexion.Close();
                }
            }



        }


        /// <summary>
        /// Leemos una banda por el numreo de id de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BandaClass readBandaXiD(int id, out string Mensaje)
        {
            try
            {
                BandaClass objBanda = null;
                Mensaje = string.Empty;
                //Comúnmente estas consultas no se realizan en el código si no se consultan mediante 
                //procedimientos almacenados.
                string select = "select idBanda,vchNombre,vchTipo from tb_bandas where idBanda=" + id;
                objConx.objConexion.Open();
                objConx.objCommand = new SqlCommand(select, objConx.objConexion);
                objConx.objDataReader = objConx.objCommand.ExecuteReader();

                if (objConx.objDataReader.Read())
                {
                    objBanda = new BandaClass();
                    objBanda.Ibanda = Convert.ToInt32(objConx.objDataReader["idBanda"].ToString());
                    objBanda.StrNombre = objConx.objDataReader["vchNombre"].ToString();
                    objBanda.StrTipo = objConx.objDataReader["vchTipo"].ToString();
                    Mensaje = "Registro Encontrado";
                }
                else
                {
                    Mensaje = "Registro No Encontrado";
                }
                return objBanda;
            }
            catch (Exception e)
            {
                Mensaje = e.Message.ToString();
                return null;
            }
            finally
            {
                if (objConx.objConexion != null)
                {
                    objConx.objConexion.Close();
                }

            }

        }

        /// <summary>
        /// Trae Todos registros de Bandas
        /// </summary>
        /// <param name="Mensaje"></param>
        /// <returns></returns>
        public List<BandaClass> readBandas(out String Mensaje)
        {
            try
            {
                List<BandaClass> listBanda = new List<BandaClass>();
                BandaClass objBanda = null;
                int cont = 0;
                Mensaje = String.Empty;

                objConx.objCommand = new SqlCommand("sp_Tb_bandas_Select", objConx.objConexion);
                objConx.objCommand.CommandType = CommandType.StoredProcedure;
                objConx.objConexion.Open();
                objConx.objDataReader = objConx.objCommand.ExecuteReader();

                while (objConx.objDataReader.Read())
                {
                    cont++;
                    objBanda = new BandaClass();
                    objBanda.Ibanda = Convert.ToInt32(objConx.objDataReader["idBanda"].ToString());
                    objBanda.StrNombre = objConx.objDataReader["vchNombre"].ToString();
                    objBanda.StrTipo = objConx.objDataReader["vchTipo"].ToString();
                    listBanda.Add(objBanda);
                }

                Mensaje = cont + "Registros";
                return listBanda;
            }
            catch (SqlException e)
            {
                Mensaje = e.Message.ToString();
                return null;
            }
            finally
            {
                if (objConx.objConexion != null)
                {
                    objConx.objConexion.Close();
                }

            }

        }

        /// <summary>
        /// Modificamos un registro de banda en la base de datos Invocando Procedimiento almacenado.
        /// </summary>
        /// <param name="objBanda"></param>
        public String updateBanda(BandaClass objBanda)
        {
            String Mensaje = String.Empty;
            try
            {

                objConx.objCommand = new SqlCommand("sp_Tb_bandas_Update", objConx.objConexion);
                objConx.objCommand.CommandType = CommandType.StoredProcedure;
                objConx.objCommand.Parameters.AddWithValue("@idBanda", objBanda.Ibanda);
                objConx.objCommand.Parameters.AddWithValue("@vchNombre", objBanda.StrNombre);
                objConx.objCommand.Parameters.AddWithValue("@vchTipo", objBanda.StrTipo);
                objConx.objConexion.Open();
                objConx.objCommand.ExecuteNonQuery();
                return Mensaje = "Modificado Exitosamente";
            }
            catch (SqlException e)
            {
                return Mensaje += e.Message.ToString();
            }
            finally
            {
                if (objConx.objConexion != null)
                {
                    objConx.objConexion.Close();
                }
            }
        }

        /// <summary>
        /// borrar un registro de banda
        /// </summary>
        /// <param name="id"></param>
        public String deleteBanda(int id)
        {
            objConx.objConexion.Open();
            objConx.objCommand = new SqlCommand ("sp_delete_banda",objConx.objConexion);
            objConx.objCommand.CommandType = CommandType.StoredProcedure;
            objConx.objCommand.Parameters.AddWithValue("@idBanda",id);
            objConx.objCommand.ExecuteNonQuery();
            objConx.objConexion.Close();

            return "Eliminación Exitosa.";
        }

        /// <summary>
        /// Ejecuta las sentencias Delete,Insert,Update
        /// </summary>
        /// <param name="sql"></param>
        public String ejecutarSqlQuery(String sql)
        {
            try
            {
                objConx.objConexion.Open();
                objConx.objCommand = new SqlCommand(sql, objConx.objConexion);
                //ExecuteNonQuery permite ejecutar sentencias del tipo insert,delete,update
                objConx.objCommand.ExecuteNonQuery();  

                return "Borrado Exitosamente.";
            }
            catch (Exception e)
            {
                return "Error Eliminado: " + e.Message.ToString();
            }
            finally
            {
                if (objConx.objConexion != null)
                {
                    objConx.objConexion.Close();
                }

            }
        }

    }
}

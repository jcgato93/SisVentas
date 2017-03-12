using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    /// <summary>
    /// Clase en la CapaDatos para realizar El backup
    /// </summary>
    public class DBackUp
    {

        public DBackUp()
        {

        }
        //Realizar Back Up
        /// <summary>
        /// realiza el Back up con el spback_up
        /// </summary>
        /// <param name="Backup"></param>
        /// <returns></returns>
        public string Back_Up()
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spback_up";
                SqlCmd.CommandType = CommandType.StoredProcedure;




                //Ejecutamos nuestro comando
                 SqlCmd.ExecuteNonQuery();
                rpta = "Se realizo la copia de\nSeguridad de forma Exitosa!";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;
        }

    }
}

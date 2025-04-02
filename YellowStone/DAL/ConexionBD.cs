using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ConexionBD
    {
        /// <summary>
        /// Función que devuelve una conexión abierta con la BD
        /// Pre: nada
        /// Post: puede haber un error al conectarse con la BD
        /// </summary>
        /// <returns> Devuelve la conexión con la base de datos </returns>
        public static SqlConnection getConexion()
        {
            SqlConnection miConexion = new SqlConnection();
            try
            {
                miConexion.ConnectionString
                    = "server=rubengarcia.database.windows.net;database=RubenBD;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;";
                miConexion.Open();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return miConexion;

        }
    }
}

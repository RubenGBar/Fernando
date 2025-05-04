using Microsoft.Data.SqlClient;
using ENT;

namespace DAL
{
    public class ListadosDAL
    {
        /// <summary>
        /// Función que devuelve un listado de nombre de invernaderos
        /// Pre: nada
        /// Post: nada
        /// </summary>
        /// <returns>List<Invernadero></returns>
        public static List<string> obtenerListadoNombreInvernaderosDAL()
        {
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            Invernadero oInvernadero = null;
            List<string> listadoNombreInvernaderos = new List<string>();
            try
            {
                miConexion = ConexionBD.getConexion();
                miComando.CommandText = "SELECT * FROM Invernadero";
                miComando.Connection = miConexion;
                SqlDataReader miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oInvernadero = new Invernadero();
                        if (miLector["Id"] != System.DBNull.Value)
                        {
                            oInvernadero.Id = (int)miLector["Id"];
                        }
                        if (miLector["Nombre"] != System.DBNull.Value)
                        {
                            oInvernadero.Nombre = (string)miLector["Nombre"];
                        }
                        listadoNombreInvernaderos.Add(oInvernadero.Nombre);
                    }
                }
                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            return listadoNombreInvernaderos;
        }

        /// <summary>
        /// Función que devuelve un listado de fechas
        /// Pre: nada
        /// Post: nada
        /// </summary>
        /// <returns>List<Invernadero></returns>
        public static List<DateTime> obtenerListadoFechasDAL(int IdInvernadero)
        {
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            DateTime oFecha;
            List<DateTime> listadoFechas = new List<DateTime>();
            try
            {
                miConexion = ConexionBD.getConexion();
                miComando.CommandText = "SELECT * FROM Temperaturas WHERE IdInvernadero = @IdInvernadero";
                miComando.Parameters.AddWithValue("@IdInvernadero", IdInvernadero);
                miComando.Connection = miConexion;
                SqlDataReader miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oFecha = new DateTime();
                        if (miLector["Fecha"] != System.DBNull.Value)
                        {
                            oFecha = (DateTime)miLector["Fecha"];
                        }
                        listadoFechas.Add(oFecha.Date);
                    }
                }
                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            return listadoFechas;
        }
    }
}

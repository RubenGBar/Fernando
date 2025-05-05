using Microsoft.Data.SqlClient;
using ENT;

namespace DAL
{
    public class ManejadoraDAL
    {
        /// <summary>
        /// Función que se conecta con la BD en Azure y devuelve las temperaturas de un invernadero
        /// Pre: nada
        /// Post: nada
        /// </summary>
        /// <param name="id"> id del invernadero a buscar </param>
        /// <param name="Fecha"> Fecha de la que se quiere obtener las temperaturas </param>
        /// <returns> Las temperaturas del invernadero obtenidos de la base de datos </returns>
        public static Temperaturas obtenerTemperaturasInvernaderoDAL(int idInvernadero, DateTime Fecha)
        {
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            Temperaturas oTemperaturas = null;
            try
            {
                miConexion = ConexionBD.getConexion();
                miComando.CommandText = "SELECT * FROM Temperaturas WHERE IdInvernadero = @Id AND Fecha = @Fecha";
                miComando.Parameters.AddWithValue("@Id", idInvernadero);
                miComando.Parameters.AddWithValue("@Fecha", Fecha);
                miComando.Connection = miConexion;
                SqlDataReader miLector = miComando.ExecuteReader();
                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oTemperaturas = new Temperaturas();
                        oTemperaturas.IdInvernadero = (int)miLector["IdInvernadero"];
                        oTemperaturas.Fecha = (DateTime)miLector["Fecha"];
                        oTemperaturas.Temp1 = (double)miLector["Temp1"];
                        oTemperaturas.Temp2 = (double)miLector["Temp2"];
                        oTemperaturas.Temp3 = (double)miLector["Temp3"];
                        oTemperaturas.Humedad1 = (double)miLector["Humedad1"];
                        oTemperaturas.Humedad2 = (double)miLector["Humedad2"];
                        oTemperaturas.Humedad3 = (double)miLector["Humedad3"];
                    }
                }
                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            return oTemperaturas;
        }

        /// <summary>
        /// Función que se conecta con la BD en Azure y devuelve el Id de un departamento
        /// Pre: nada
        /// Post: nada
        /// </summary>
        /// <param name="NombreInvernadero"> Nombre del invernadero a buscar </param>
        /// <returns> Las temperaturas del invernadero obtenidos de la base de datos </returns>
        public static int obtenerIdInvernaderoPorNombreDAL(string NombreInvernadero)
        {
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            int idInvernadero = 0;
            try
            {
                miConexion = ConexionBD.getConexion();
                miComando.CommandText = "SELECT * FROM Invernadero WHERE Nombre = @NombreInvernadero";
                miComando.Parameters.AddWithValue("@NombreInvernadero", NombreInvernadero);
                miComando.Connection = miConexion;
                SqlDataReader miLector = miComando.ExecuteReader();
                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        idInvernadero = (int)miLector["Id"];
                    }
                }
                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            return idInvernadero;
        }
    }
}

using Microsoft.Data.SqlClient;
using ENT;

namespace DAL
{
    public class ManejadoraDAL
    {
        /// <summary>
        /// Función que se conecta con la BD en Azure y devuelve un listado de puntuaciones
        /// Pre: nada
        /// Post: puede devolver una lista vacía
        /// </summary>
        /// <returns> El listado de puntuaciones de la base de datos </returns>
        public static List<Puntuacion> obtenerListadoPuntuacionDAL()
        {
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            Puntuacion oPuntuacion;
            List<Puntuacion> listadoPersonas = new List<Puntuacion>();

            try
            {
                miConexion = ConexionBD.getConexion();
                miComando.CommandText = "SELECT * FROM Puntuacion";
                miComando.Connection = miConexion;
                SqlDataReader miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPuntuacion = new Puntuacion();
                        if (miLector["Id"] != System.DBNull.Value)
                        {
                            oPuntuacion.Id = (int)miLector["Id"];
                        }
                        if (miLector["Nickname"] != System.DBNull.Value)
                        {
                            oPuntuacion.Nickname = (string)miLector["Nickname"];
                        }
                        if (miLector["Puntos"] != System.DBNull.Value)
                        {
                            oPuntuacion.Puntos = (int)miLector["Puntos"];
                        }
                        listadoPersonas.Add(oPuntuacion);
                    }
                }

                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return listadoPersonas;
        }

        /// <summary>
        /// Función que se conecta con la BD en Azure y añade una nueva puntuacion
        /// </summary>
        /// <param name="puntuacionNueva"> Puntuacion a añadir </param>
        /// <returns> Devuelve el número de filas afectadas </returns>
        public static int crearPuntuacionDAL(Puntuacion puntuacionNueva)
        {
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            int filasAfectadas = 0;

            try
            {
                miConexion = ConexionBD.getConexion();
                miComando.CommandText = "INSERT INTO Puntuacion (Nickname, Puntos) VALUES (@Nickname, @Puntos)";
                miComando.Parameters.AddWithValue("@Nickname", puntuacionNueva.Nickname);
                miComando.Parameters.AddWithValue("@Puntos", puntuacionNueva.Puntos);
                miComando.Connection = miConexion;

                filasAfectadas = miComando.ExecuteNonQuery();

            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return filasAfectadas;
        }
    }
}

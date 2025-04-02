using ENT;
using Microsoft.Data.SqlClient;


namespace DAL
{
    public class ClsListadoPersonasDAL
    {
        #region Funciones
        /// <summary>
        /// Función que se conecta con la BD en Azure y devuelve un listado de personas
        /// Pre: nada
        /// Post: puede devolver una lista vacía
        /// </summary>
        /// <returns> El listado de personas de la base de datos </returns>
        public static List<ClsPersona> obtenerListadoBD()
        {
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            ClsPersona oPersona;
            List<ClsPersona> listadoPersonas = new List<ClsPersona>();

            try
            {
                miConexion = ConexionBD.getConexion();
                miComando.CommandText = "SELECT * FROM personasASP";
                miComando.Connection = miConexion;
                SqlDataReader miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersona = new ClsPersona();
                        oPersona.Id = (int)miLector["Id"];
                        oPersona.Nombre = (string)miLector["Nombre"];
                        oPersona.Apellido = (string)miLector["Apellido"];
                        oPersona.Email = miLector["Email"] != DBNull.Value ? (string)miLector["Email"] : string.Empty;
                        oPersona.Telefono = (string)miLector["Telefono"];
                        oPersona.IdDepartamento = (int)miLector["IdDepartamento"];
                        oPersona.Dni = (int)miLector["Dni"];
                        oPersona.Sexo = (string)miLector["Sexo"];
                        listadoPersonas.Add(oPersona);
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
        #endregion
    }
}

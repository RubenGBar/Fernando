using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ClsListadoDepartamentosDAL
    {
        /// <summary>
        /// Función que se conecta con la BD en Azure y devuelve un listado de departamentos
        /// Pre: nada
        /// Post: puede devolver una lista vacía
        /// </summary>
        /// <returns> El listado de departamentos de la base de datos </returns>
        public static List<ClsDepartamento> obtenerListadoBD()
        {
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            ClsDepartamento oDepartamento;
            List<ClsDepartamento> listadoDepartamentos = new List<ClsDepartamento>();
            try
            {
                miConexion = ConexionBD.getConexion();
                miComando.CommandText = "SELECT * FROM departamentosASP";
                miComando.Connection = miConexion;
                SqlDataReader miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oDepartamento = new ClsDepartamento();
                        oDepartamento.Id = (int)miLector["Id"];
                        oDepartamento.Nombre = (string)miLector["Nombre"];
                        listadoDepartamentos.Add(oDepartamento);
                    }
                }
                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            return listadoDepartamentos;
        }
    }
}

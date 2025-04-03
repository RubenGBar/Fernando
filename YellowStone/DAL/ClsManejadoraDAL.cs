using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ClsManejadoraDAL
    {
        #region Funciones
        /// <summary>
        /// Función que actualiza la raza de un caballo del listado de caballos
        /// Pre: el id del caballo y de la raza deben estar en los listados
        /// Pos: el resultado será cero o uno
        /// </summary>
        /// <param name="idCaballo"> Debe de ser mayor que cero </param>
        /// <param name="idRaza"> Debe de ser mayor que cero </param>
        /// <returns> Devuelve un entero </returns>
        public static int actualizarRazaCaballoDAL(int idCaballo, int idRaza)
        {
            int numeroFilasAfectadas = 0;
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            try
            {
                conexion = ConexionBD.getConexion();
                comando.Parameters.Add("@idCaballo", System.Data.SqlDbType.Int).Value = idCaballo;
                comando.Parameters.Add("@idRaza", System.Data.SqlDbType.Int).Value = idRaza;
                var caballo = ClsListadosDAL.obtenerListadoCaballoDAL().FirstOrDefault(c => c.IdCaballo == idCaballo);
                
                if (caballo != null && caballo.IdRaza != idRaza)
                {
                    comando.CommandText = "UPDATE Caballo SET IdRaza = @idRaza WHERE IdCaballo = @idCaballo";
                    comando.Connection = conexion;
                    numeroFilasAfectadas = comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //TODO: Poner mensaje, no funciona display alert
            }

            return numeroFilasAfectadas;
        }
        #endregion
    }
}

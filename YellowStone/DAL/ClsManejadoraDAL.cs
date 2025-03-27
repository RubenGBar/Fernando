using ENT;

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

            // Cambiar por una expresión Lambda
            var caballo = ListadosDAL.obtenerListadoCaballoDAL().FirstOrDefault(c => c.IdCaballo == idCaballo);
            if (caballo != null && caballo.IdRaza != idRaza)
            {
                caballo.IdRaza = idRaza;
                numeroFilasAfectadas++;
            }

            return numeroFilasAfectadas;
        }
        #endregion
    }
}

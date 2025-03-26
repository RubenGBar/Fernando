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

            // Cambiar por un While
            foreach (var caballo in ListadosDAL.obtenerListadoCaballoDAL())
            {
                if (caballo.IdCaballo == idCaballo)
                {
                    if (idRaza != caballo.IdRaza)
                    {
                        caballo.IdRaza = idRaza;
                        numeroFilasAfectadas++;
                        break;
                    }
                }
            }

            return numeroFilasAfectadas;
        }
        #endregion
    }
}

using DAL;
using ENT;

namespace BL
{
    public class ClsManejadoraBL
    {
        #region Funciones
        /// <summary>
        /// Esta función llama a la DAL para actualizar un caballo siguiendo las reglas de negocio
        /// Pre: el id del caballo y de la raza deben estar en los listados
        /// Pos: el resultado será cero o uno
        /// </summary>
        /// <param name="idCaballo"> Debe de ser mayor que cero </param>
        /// <param name="idRaza"> Debe de ser mayor que cero </param>
        /// <returns> Devuelve un entero </returns>
        public static int actualizarRazaCaballoBL(int idCaballo, int idRaza)
        {
            return ClsManejadoraDAL.actualizarRazaCaballoDAL(idCaballo, idRaza);
        }
        #endregion
    }
}

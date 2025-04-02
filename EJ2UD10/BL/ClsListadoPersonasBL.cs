using DAL;
using ENT;

namespace BL
{
    public class ClsListadoPersonasBL
    {
        #region Funciones
        /// <summary>
        /// Función que se conecta con la BD en Azure y devuelve un listado de personas
        /// Pre: nada
        /// Post: puede haber un error al conectarse con la BD
        /// </summary>
        /// <returns> El listado de personas de la base de datos </returns>
        public static List<ClsPersona> obtenerListadoBD()
        {
            return ClsListadoPersonasDAL.obtenerListadoBD();
        }

        #endregion
    }
}

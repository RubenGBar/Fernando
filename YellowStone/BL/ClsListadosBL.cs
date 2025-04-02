using ENT;
using DAL;

namespace BL
{
    public class ClsListadosBL
    {

        #region Funciones
        /// <summary>
        /// Esta función llamará a la DAL y devolverá un listado de Caballos con las reglas de negocio aplicadas
        /// Pre: nada
        /// Pos: nada
        /// </summary>
        /// <returns>List<ClsCaballo> con las reglas de negocios aplicadas </returns>
        public static List<ClsCaballo> obtenerListadoCaballoBL()
        {
            return ClsListadosDAL.obtenerListadoCaballoDAL();
        }
        /// <summary>
        /// Esta función llamará a la DAL y devolverá un listado de Razas con las reglas de negocio aplicadas
        /// Pre: nada
        /// Pos: nada
        /// </summary>
        /// <returns>List<ClsRaza> con las reglas de negocios aplicadas </returns>
        public static List<ClsRaza> obtenerListadoRazaBL()
        {
            return ClsListadosDAL.obtenerListadoRazaDAL();
        }
        #endregion

    }
}

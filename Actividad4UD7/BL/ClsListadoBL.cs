using DAL;
using ENT;

namespace BL
{
    public class ClsListadoBL
    {

        #region Funciones
        /// <summary>
        /// Esta función llamará a la DAL y devolverá un listado de Personas con las reglas de negocio aplicadas
        /// Pre: nada
        /// Pos: nada
        /// </summary>
        /// <returns>List<ClsPersona> con las reglas de negocios aplicadas </returns>
        public List<ClsPersona> obtenerListadoPersonas()
        {
            return ClsListadosDAL.obtenerListadoPersonas();
        }
        /// <summary>
        /// Esta función llamará a la DAL y devolverá un listado de Departamentos con las reglas de negocio aplicadas
        /// Pre: nada
        /// Pos: nada
        /// </summary>
        /// <returns>List<ClsDepartamento> con las reglas de negocios aplicadas </returns>
        public List<ClsDepartamento> obtenerListadoDepartamentos()
        {
            return ClsListadosDAL.obtenerListadoDepartamentos();
        }
        #endregion

    }
}

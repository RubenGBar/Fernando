using DAL;
using ENT;

namespace BL
{
    public class ClsListadoDepartamentosBL
    {
        /// <summary>
        /// Esta función llamará a la DAL y devolverá un listado de Departamentos con las reglas de negocio aplicadas
        /// Pre: nada
        /// Pos: nada
        /// </summary>
        /// <returns>List<ClsDepartamento> con las reglas de negocios aplicadas </returns>
        public static List<ClsDepartamento> obtenerListadoDepartamentosBL()
        {
            return ClsListadosDAL.obtenerListadoDepartamentosDAL();
        }
    }
}

using DAL;
using ENT;

namespace BL
{
    public class ClsListadoDepartamentosBL
    {
        /// <summary>
        /// Función que se conecta con la BD en Azure y devuelve un listado de departamentos
        /// Pre: nada
        /// Post: puede devolver una lista vacía
        /// </summary>
        /// <returns> El listado de departamentos de la base de datos </returns>
        public static List<ClsDepartamento> obtenerListadoBD()
        {
            return ClsListadoDepartamentosDAL.obtenerListadoBD();
        }
    }
}

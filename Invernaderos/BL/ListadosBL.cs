using ENT;
using DAL;

namespace BL
{
    public class ListadosBL
    {
        /// <summary>
        /// Función que llama a la capa DAL y devuelve un listado de nombre de invernaderos relleno
        /// Pre: nada
        /// Post: nada
        /// </summary>
        /// <returns>List<Invernadero></returns>
        public static List<string> obtenerListadoNombreInvernaderosBL()
        {
            return ListadosDAL.obtenerListadoNombreInvernaderosDAL();
        }
        /// <summary>
        /// Función que llama a la capa DAL y devuelve un listado de fechas
        /// Pre: nada
        /// Post: nada
        /// </summary>
        /// <returns>List<Invernadero></returns>
        public static List<DateTime> obtenerListadoFechasPorIdBL(int IdInvernadero)
        {
            return ListadosDAL.obtenerListadoFechasPorIdDAL(IdInvernadero);
        }
    }
}

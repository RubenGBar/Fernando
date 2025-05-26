using ENT;
using DAL;

namespace BL
{
    public class ManejadoraBL
    {
        /// <summary>
        /// Función que llama a la capa DAL y devuelve un listado de puntuaciones
        /// Pre: nada
        /// Post: puede devolver una lista vacía
        /// </summary>
        /// <returns> El listado de puntuaciones de la base de datos </returns>
        public static List<Puntuacion> obtenerListadoPuntuacionBL()
        {
            return ManejadoraDAL.obtenerListadoPuntuacionDAL();
        }

        /// <summary>
        /// Función que llama a la capa DAL y añade una nueva puntuacion
        /// </summary>
        /// <param name="puntuacionNueva"> Puntuacion a añadir </param>
        /// <returns> Devuelve el número de filas afectadas </returns>
        public static int crearPuntuacionBL(Puntuacion puntuacionNueva)
        {
            return ManejadoraDAL.crearPuntuacionDAL(puntuacionNueva);
        }
    }
}

using ENT;
using DAL;

namespace BL
{
    public class ListadosBL
    {
        /// <summary>
        /// Función que llama a la capa DAL para obtener el listado de personajes
        /// </summary>
        /// <returns> Un listado de personajes </returns>
        public static List<Personaje> obtenerListadoPersonajesBL()
        {
            return ListadosDAL.obtenerListadoPersonajesDAL();
        }

        /// <summary>
        /// Función que llama a la capa DAL para obtener el listado de combates
        /// </summary>
        /// <returns> Un listado de Combates </returns>
        public static List<Combate> obtenerListadoCombatesBL()
        {
            return ListadosDAL.obtenerListadoCombatesDAL();
        }

    }
}

using DAL;
using ENT;

namespace BL
{
    public class ListadosBL
    {
        /// <summary>
        /// Función que llama a la capa DAL para obtener el listado de puntuaciones
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Puntuacion>> obtenerListadoPuntuacionesBL()
        {
            return await ListadosDAL.obtenerListadoPuntuacionesDAL();
        }
    }
}

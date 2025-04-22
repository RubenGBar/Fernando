using ENT;
using DAL;
using DTO;

namespace BL
{
    public class ManejadoraBL
    {
        /// <summary>
        /// Función que llama a la capa DAL para obtener el listado de personajes con su puntuación total
        /// </summary>
        /// <returns> Un listado de personajes con su puntuación total </returns>
        public static List<PersonajeConPuntuacionTotal> obtenerListadoPersonajesConPuntuacionTotalBL()
        {
            return ManejadoraDAL.obtenerListaPersonajeConPuntuaciónTotalDAL();
        }

        /// <summary>
        /// Función que llama a la capa DAL para guardar un combate
        /// </summary>
        /// <param name="combate"> Combate a guardar </param>
        /// <returns> Devuelve un booleano </returns>
        public static bool guardarCombateBL(Combate combate)
        {
            return ManejadoraDAL.guardarCombateDAL(combate);
        }

    }
}

using DAL;
using DTO;

namespace BL
{
    public class ManejadoraBL
    {
        /// <summary>
        /// Funcion que llama a la capa DAL para obtener un pokemon por su ID.
        /// </summary>
        /// <param name="idPokemon"> ID del pokemon </param>
        /// <returns></returns>
        public static async Task<Pokemon> obtenerUnPokemonPorIDBL(int idPokemon)
        {
            return await ManejadoraDAL.obtenerUnPokemonPorIDDAL(idPokemon);
        }
    }
}

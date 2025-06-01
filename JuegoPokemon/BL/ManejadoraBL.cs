using DAL;
using DTO;

namespace BL
{
    public class ManejadoraBL
    {
        public static async Task<Pokemon> obtenerUnPokemonAleatorio()
        {
            return await ManejadoraDAL.obtenerUnPokemonAleatorio();
        }
    }
}

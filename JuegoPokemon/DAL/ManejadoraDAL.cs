using DAL;
using DTO;
using ENT;
using Newtonsoft.Json;
using System.Net;

namespace DAL
{
    public class ManejadoraDAL
    {
        /// <summary>
        /// Funcion que llama a la pokeAPI para obtener un pokemon por su ID.
        /// </summary>
        /// <param name="idPokemon"> ID del pokemon </param>
        /// <returns></returns>
        public static async Task<Pokemon> obtenerUnPokemonPorIDDAL(int idPokemon)
        {
            //Pido la cadena de la Uri al método estático
            string miCadenaUrl = Conexion.obtenerURIPokemon();
            Uri miUri = new Uri($"{miCadenaUrl}{idPokemon}");
            Pokemon pokemonDevolver = new Pokemon();
            HttpClient mihttpClient;
            HttpResponseMessage miCodigoRespuesta;
            string textoJsonRespuesta;

            //Instanciamos el cliente Http
            mihttpClient = new HttpClient();
            try
            {

                miCodigoRespuesta = await mihttpClient.GetAsync(miUri);
                if (miCodigoRespuesta.IsSuccessStatusCode)
                {
                    textoJsonRespuesta = await mihttpClient.GetStringAsync(miUri);
                    mihttpClient.Dispose();
                    pokemonDevolver = JsonConvert.DeserializeObject<Pokemon>(textoJsonRespuesta);
                    pokemonDevolver.Foto = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/"+ idPokemon +".png";

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return pokemonDevolver;
        }

        /// <summary>
        /// Funcion que llama a mi API de puntuaciones para guardar una partida
        /// </summary>
        /// <param name="idPokemon"> ID del pokemon </param>
        /// <returns></returns>
        public async Task<HttpStatusCode> insertaPersonaDAL(Puntuacion puntuacionGuardar)
        {

            HttpClient mihttpClient = new HttpClient();
            string datos;
            HttpContent contenido;
            string miCadenaUrl = Conexion.obtenerURIPuntuacion();
            Uri miUri = new Uri($"{miCadenaUrl}Puntuacion");

            //Usaremos el Status de la respuesta para comprobar si ha insertado
            HttpResponseMessage miRespuesta = new HttpResponseMessage();

            try
            {
                datos = JsonConvert.SerializeObject(puntuacionGuardar);
                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");
                miRespuesta = await mihttpClient.PostAsync(miUri, contenido);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return miRespuesta.StatusCode;
        }

    }
}

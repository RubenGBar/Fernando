using ENT;
using Newtonsoft.Json;

namespace DAL
{
    public class ListadosDAL
    {
        /// <summary>
        /// Función que llama a la API para obtener el listado de puntuaciones
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Puntuacion>> getPersonasDAL()
        {

            //Pido la cadena de la Uri al método estático
            string miCadenaUrl = Conexion.obtenerURIPuntuacion();
            Uri miUri = new Uri($"{miCadenaUrl}Puntuacion");
            List<Puntuacion> listadoPersonas = new List<Puntuacion>();
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
                    listadoPersonas = JsonConvert.DeserializeObject<List<Puntuacion>>(textoJsonRespuesta);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listadoPersonas;
        }
    }
}

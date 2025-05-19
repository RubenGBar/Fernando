using ENT;
using Newtonsoft.Json;

namespace DAL
{
    public class ManejadoraDAL
    {
        /// <summary>
        /// Función que llama a la API para obtener el listado de personas
        /// </summary>
        /// <returns></returns>
        public async Task<List<ClsPersona>> getPersonasDAL()
        {

            //Pido la cadena de la Uri al método estático
            string miCadenaUrl = ConexionDAL.obtenerURI();
            Uri miUri = new Uri($"{miCadenaUrl}Personas");
            List<ClsPersona> listadoPersonas = new List<ClsPersona>();
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
                    listadoPersonas =
                    JsonConvert.DeserializeObject<List<ClsPersona>>(textoJsonRespuesta);

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

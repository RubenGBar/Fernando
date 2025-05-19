using ENT;
using DAL;

namespace BL
{
    public class ManejadoraBL
    {
        /// <summary>
        /// Función que llama a la capa DAL para obtener el listado de personas
        /// </summary>
        /// <returns></returns>
        public async Task<List<ClsPersona>> getPersonasBL()
        {
            return await new ManejadoraDAL().getPersonasDAL();
        }
    }
}

using ENT;
using DAL;

namespace BL
{
    public class ManejadoraBL
    {
        /// <summary>
        /// Función que llama a la capa DAL y se conecta con la BD en Azure y devuelve las temperaturas de un invernadero
        /// Pre: nada
        /// Post: nada
        /// </summary>
        /// <param name="id"> id del invernadero a buscar </param>
        /// <param name="Fecha"> Fecha de la que se quiere obtener las temperaturas </param>
        /// <returns> Las temperaturas del invernadero obtenidos de la base de datos </returns>
        public static Temperaturas obtenerTemperaturasInvernaderoBL(int idInvernadero, DateTime Fecha)
        { 
            return ManejadoraDAL.obtenerTemperaturasInvernaderoDAL(idInvernadero, Fecha);
        }

        /// <summary>
        /// Función que se conecta con la BD en Azure y devuelve el Id de un departamento
        /// Pre: nada
        /// Post: nada
        /// </summary>
        /// <param name="NombreInvernadero"> Nombre del invernadero a buscar </param>
        /// <returns> Las temperaturas del invernadero obtenidos de la base de datos </returns>
        public static int obtenerIdInvernaderoPorNombreBL(string NombreInvernadero)
        {
            return ManejadoraDAL.obtenerIdInvernaderoPorNombreDAL(NombreInvernadero);
        }
    }
}

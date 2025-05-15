using DAL;
using ENT;

namespace BL
{
    public class ClsManejadoraBL
    {
        /// <summary>
        /// Función que llama a la capa DAL y devuelve una persona por su ID
        /// Pre: id > 0
        /// Post: puede devolver null
        /// </summary>
        /// <param name="id"> ID de la persona a buscar </param>
        /// <returns> La persona de la base de datos </returns>
        public static ClsPersona obtenerPersonaPorID(int id)
        {
            ClsPersona oPersona = ClsManejadoraDAL.obtenerPersonaPorID(id);
            return oPersona;
        }
        /// <summary>
        /// Función que llama a la capa DAL y actualiza una persona por su ID
        /// </summary>
        /// <param name="persona">Persona con los datos editados.</param>
        /// <param name="idAntiguo">Id de la persona a actualizar.</param>
        /// <returns>True si se actualizó</returns>
        public static bool actualizarPersonaBL(ClsPersona persona, int idAntiguo)
        {
            bool exito = ClsManejadoraDAL.actualizarPersonaDAL(persona, idAntiguo);
            return exito;
        }

        /// <summary>
        /// Función que llama a la capa DAL y elimina una persona por su ID
        /// </summary>
        /// <param name="Id"> El id de la persona a borrar </param>
        /// <returns> El número de filas afectadas </returns>
        public static int eliminarPersonaBL(int id)
        {
            int resultado = ClsManejadoraDAL.deletePersonaDAL(id);
            return resultado;
        }

        /// <summary>
        /// Función que se conecta con la BD en Azure y añade una nueva persona
        /// </summary>
        /// <param name="personaNueva"> Persona a Añadir </param>
        /// <returns> Devuelve true si se ha añadido a la persona </returns>
        public static bool crearPersonaBL(ClsPersona persona)
        {
            bool exito = ClsManejadoraDAL.crearPersonaDAL(persona);
            return exito;
        }

    }
}

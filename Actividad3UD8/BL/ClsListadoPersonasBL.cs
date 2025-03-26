using DAL;
using ENT;

namespace BL
{
    public class ClsListadoPersonasBL
    {
        #region Funciones
        /// <summary>
        /// Esta función llamará a la DAL y devolverá un listado de Personas con las reglas de negocio aplicadas
        /// Pre: nada
        /// Pos: nada
        /// </summary>
        /// <returns>List<ClsPersona> con las reglas de negocios aplicadas </returns>
        public static List<ClsPersona> obtenerListadoPersonasBL()
        {
            return ClsListadosDAL.obtenerListadoPersonasDAL();
        }
        /// <summary>
        /// Función que devuelve una persona aleatoria de la DAL
        /// Pre: el id debe existir en la lista
        /// Post: nunca devolverá null
        /// </summary>
        /// <returns> Devuelve la persona encontrada </returns>
        public static ClsPersona obtenerPersonaAleatoria()
        {
            int idPersona = 0;
            int numeroRandom = 0;
            Random rnd = new Random();
            numeroRandom = rnd.Next(0, ClsListadosDAL.obtenerListadoPersonasCount());
            idPersona = ClsListadosDAL.obtenerIDPersonaPorPosicion(numeroRandom);
            return ClsListadosDAL.obtenerPersonaPorID(idPersona);
        }
        #endregion
    }
}

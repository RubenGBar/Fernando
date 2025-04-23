using BL;
using DTO;

namespace ASPRivals.Models.VM
{
    public class ListadoPersonajeConPuntuacion
    {
        #region Propiedades
        public List<PersonajeConPuntuacionTotal> listadoPersonajesConPuntuacion { get; set; }
        #endregion

        #region Constructores
        public ListadoPersonajeConPuntuacion()
        {
            listadoPersonajesConPuntuacion = ManejadoraBL.obtenerListadoPersonajesConPuntuacionTotalBL();
        }
        #endregion
    }
}

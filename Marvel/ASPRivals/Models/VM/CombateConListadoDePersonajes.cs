using BL;
using ENT;
using DTO;

namespace ASPRivals.Models.VM
{
    public class CombateConListadoDePersonajes : Combate
    {

        #region Propiedades
        public List<Personaje> listadoPersonajesConPuntuacion { get; }
        #endregion

        #region Constructores
        public CombateConListadoDePersonajes()
        : base()
        {
            listadoPersonajesConPuntuacion = ListadosBL.obtenerListadoPersonajesBL();
        }

        public CombateConListadoDePersonajes(Combate combate)
        : base(combate.IdCombatiente1, combate.IdCombatiente2, combate.PuntosCombatiente1, combate.PuntosCombatiente2)
        {
            listadoPersonajesConPuntuacion = ListadosBL.obtenerListadoPersonajesBL();
        }
        #endregion
    }
}

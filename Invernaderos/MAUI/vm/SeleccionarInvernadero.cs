using ENT;
using BL;

namespace MAUI.VM
{
    public class SeleccionarInvernadero
    {
        #region Propiedades
        public List<string> ListadoNombreInvernaderos { get; }
        // TODO: Avisar de que no puede seleccionar una fecha porque no existen esos registros
        public string InvernaderoSeleccionado { get; set; }
        public DateTime FechaSeleccionada { get; set; }
        #endregion

        #region Constructores
        public SeleccionarInvernadero()
        {
            ListadoNombreInvernaderos = ListadosBL.obtenerListadoNombreInvernaderosBL();
        }
        #endregion
    }
}

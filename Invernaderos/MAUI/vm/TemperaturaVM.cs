using ENT;
using BL;

namespace MAUI.VM
{
    public class TemperaturaVM
    {
        #region Propiedades
        public List<string> ListadoNombreInvernaderos { get; }
        public string InvernaderoSeleccionado { get; set; }
        public DateTime FechaSeleccionada { get; set; }
        #endregion

        #region Constructores
        public TemperaturaVM()
        {
            ListadoNombreInvernaderos = ListadosBL.obtenerListadoNombreInvernaderosBL();
        }
        #endregion
    }
}

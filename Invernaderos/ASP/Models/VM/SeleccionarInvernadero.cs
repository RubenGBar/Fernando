using BL;

namespace ASP.Models.VM
{
    public class SeleccionarInvernadero
    {
        #region Propiedades
        public List<string> ListadoNombreInvernaderos { get; }
        public string NombreInvernaderoSeleccionado { get; set; }
        public DateTime FechaSeleccionada { get; set; }
        #endregion

        #region Constructores
        public SeleccionarInvernadero()
        {
            ListadoNombreInvernaderos = ListadosBL.obtenerListadoNombreInvernaderosBL();
            FechaSeleccionada = DateTime.Now;
        }
        #endregion
    }
}

using BL;
using ENT;

namespace MAUI.Models.Model
{
    public class ClsCaballoConListadoRazas : ClsCaballo
    {
        #region Propiedades
        public List<ClsRaza> razasCaballo { get; }
        public ClsRaza razaSeleccionada { get; set; }
        #endregion

        #region Constructores
        public ClsCaballoConListadoRazas(ClsCaballo caballo, List<ClsRaza> razasCaballoParam)
        {
            this.Nombre = caballo.Nombre;
            this.IdRaza = caballo.IdRaza;
            // No se puede poner el IdCaballo porque no se puede acceder a él
            this.razasCaballo = razasCaballoParam;
        }
        #endregion

    }
}

using BL;
using ENT;

namespace MAUI.Models
{
    public class ClsCaballoConListadoRazas : ClsCaballo
    {
        #region Propiedades
        public List<ClsRaza> RazasCaballo { get; }
        public ClsRaza RazaSeleccionada { get; set; }
        #endregion

        #region Constructores
        public ClsCaballoConListadoRazas(ClsCaballo caballo, List<ClsRaza> razasCaballoParam) : base(caballo.IdCaballo, caballo.Nombre, caballo.IdRaza)
        {
            this.RazasCaballo = razasCaballoParam;
        }
        #endregion

    }
}

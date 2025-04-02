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
        public ClsCaballoConListadoRazas(ClsCaballo caballo, List<ClsRaza> razasCaballoParam) 
        : base(caballo.IdCaballo, caballo.Nombre, caballo.IdRaza)
        {
            this.RazasCaballo = razasCaballoParam;
            if (caballo.IdRaza == 0)
            {
                this.RazaSeleccionada = razasCaballoParam[0];
            }
            else
            {
                this.RazaSeleccionada = razasCaballoParam.Find(c => c.IdRaza == caballo.IdRaza);
            }
            
        }
        #endregion

    }
}

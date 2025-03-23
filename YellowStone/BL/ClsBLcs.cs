using ENT;
using DAL;

namespace BL
{
    public class ClsBLcs
    {

        #region Funciones
        public static List<ClsCaballo> obtenerListadoCaballoBL()
        {
            return ClsDAL.obtenerListadoCaballoDAL();
        }
        public static List<ClsRaza> obtenerListadoRazaBL()
        {
            return ClsDAL.obtenerListadoRazaDAL();
        }

        public static int actualizarRazaCaballoBL(int idCaballo, int idRaza)
        {
            return ClsDAL.actualizarRazaCaballoDAL(idCaballo, idRaza);
        }
        #endregion

    }
}

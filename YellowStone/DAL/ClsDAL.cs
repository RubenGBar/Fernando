using ENT;

namespace DAL
{
    public class ClsDAL
    {

        #region Propiedades
        private List<ClsCaballo> listadoCaballosDAL;
        private List<ClsRaza> listadoRazasDAL;
        #endregion

        #region Funciones
        private static List<ClsCaballo> obtenerListadoCompletoCaballoDAL()
        {
            return new List<ClsCaballo>
            {
                new ClsCaballo(1, "Blue Note", 0),
                new ClsCaballo(2, "Star", 0),
                new ClsCaballo(3, "Brandy", 0),
                new ClsCaballo(4, "Lucky", 0),
                new ClsCaballo(5, "Apollo", 0),
                new ClsCaballo(6, "Scout", 0),
                new ClsCaballo(7, "Dakota", 0),
                new ClsCaballo(8, "Cash", 0)
            };
        }

        private static List<ClsRaza> obtenerListadoCompletoRazaDAL()
        {
            return new List<ClsRaza>
            {
                new ClsRaza(1, "Mustang"),
                new ClsRaza(2, "Paint Horse"),
                new ClsRaza(3, "Rocky Mountain"),
                new ClsRaza(4, "Appaloosa"),
                new ClsRaza(5, "Pinto"),
                new ClsRaza(6, "Cortador")
            };
        }

        public static List<ClsCaballo> obtenerListadoCaballoDAL()
        {
            return obtenerListadoCompletoCaballoDAL();
        }
        public static List<ClsRaza> obtenerListadoRazaDAL()
        {
            return obtenerListadoCompletoRazaDAL();
        }

        public static int actualizarRazaCaballoDAL(int idCaballo, int idRaza)
        {
            int numeroFilasAfectadas = 0;
            List<ClsCaballo> listadoCaballosDAL = obtenerListadoCompletoCaballoDAL();

            foreach (var caballo in listadoCaballosDAL)
            {
                if (caballo.IdCaballo > 0 && caballo.IdCaballo == idCaballo)
                {
                    caballo.IdRaza = idRaza;
                    numeroFilasAfectadas++;
                }
            }

            return numeroFilasAfectadas;
        }
        #endregion

    }
}

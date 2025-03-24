using ENT;

namespace DAL
{
    public class ListadosDAL
    {

        #region Propiedades
        public static List<ClsCaballo> listadoCaballosDAL = new List<ClsCaballo>
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
        public static List<ClsRaza> listadoRazasDAL = new List<ClsRaza>
        {
                new ClsRaza(1, "Mustang"),
                new ClsRaza(2, "Paint Horse"),
                new ClsRaza(3, "Rocky Mountain"),
                new ClsRaza(4, "Appaloosa"),
                new ClsRaza(5, "Pinto"),
                new ClsRaza(6, "Cortador")
        };
        #endregion

        #region Funciones
        /// <summary>
        /// Función que devuelve un listado de caballos relleno
        /// Pre: nada
        /// Post: nada
        /// </summary>
        /// <returns>List<ClsCaballo></returns>
        public static List<ClsCaballo> obtenerListadoCaballoDAL()
        {
            return listadoCaballosDAL;
        }
        /// <summary>
        /// Función que devuelve un listado de razas rellenos
        /// Pre: nada
        /// Post: nada
        /// </summary>
        /// <returns>List<ClsRaza></returns>
        public static List<ClsRaza> obtenerListadoRazaDAL()
        {
            return listadoRazasDAL;
        }
        #endregion

    }

}

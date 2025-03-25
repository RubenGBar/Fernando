using ENT;

namespace DAL
{
    public class ClsListadosDAL
    {
        #region Propiedades
        public static List<ClsPersona> ListadoPersonasDAL = new List<ClsPersona>
        {
            new ClsPersona(1, "Juan", "Perez", 1980, "666666666", "1"),
            new ClsPersona(2, "Ana", "Lopez", 1990, "666666666", "2"),
            new ClsPersona(3, "Luis", "Garcia", 2000, "666666666", "3"),
            new ClsPersona(4, "Maria", "Gonzalez", 2010, "666666666", "4"),
            new ClsPersona(5, "Pedro", "Martinez", 2020, "666666666", "5")
        };
        public static List<ClsDepartamento> ListadoDepartamentosDAL = new List<ClsDepartamento>
        {
            new ClsDepartamento(1, "Informatica"),
            new ClsDepartamento(2, "Ventas"),
            new ClsDepartamento(3, "Marketing"),
            new ClsDepartamento(4, "Recursos Humanos"),
            new ClsDepartamento(5, "Contabilidad")
        };
        #endregion

        #region Funciones
        /// <summary>
        /// Función que devuelve un listado de Personas relleno
        /// Pre: nada
        /// Post: nada
        /// </summary>
        /// <returns>List<ClsPersona></returns>
        public static List<ClsPersona> obtenerListadoPersonas()
        {
            return ListadoPersonasDAL;
        }
        /// <summary>
        /// Función que devuelve un listado de Departamentos relleno
        /// Pre: nada
        /// Post: nada
        /// </summary>
        /// <returns>List<ClsDepartamento></returns>
        public static List<ClsDepartamento> obtenerListadoDepartamentos()
        {
            return ListadoDepartamentosDAL;
        }
        #endregion
    }
}

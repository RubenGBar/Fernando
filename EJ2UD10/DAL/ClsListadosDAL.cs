using ENT;
using Microsoft.Data.SqlClient;


namespace DAL
{
    public class ClsListadosDAL
    {
        #region Propiedades
        private static List<ClsDepartamento> ListadoDepartamentosDAL = new List<ClsDepartamento>
            {
                new ClsDepartamento(1, "Informatica"),
                new ClsDepartamento(2, "Ventas"),
                new ClsDepartamento(3, "Marketing"),
                new ClsDepartamento(4, "Recursos Humanos"),
                new ClsDepartamento(5, "Contabilidad")
            };

        private static List<ClsPersona> ListadoPersonasDAL = new List<ClsPersona>
            {
                new ClsPersona(1, "Juan", "Pérez", "juan.perez@example.com", "123456789", 1, 12345678, "M"),
                new ClsPersona(2, "María", "García", "maria.garcia@example.com", "987654321", 2, 87654321, "F"),
                new ClsPersona(3, "Carlos", "López", "carlos.lopez@example.com", "456123789", 3, 45612378, "M"),
                new ClsPersona(4, "Ana", "Martínez", "ana.martinez@example.com", "321654987", 4, 32165498, "F"),
                new ClsPersona(5, "Luis", "González", "luis.gonzalez@example.com", "789456123", 5, 78945612, "M"),
                new ClsPersona(6, "Laura", "Rodríguez", "laura.rodriguez@example.com", "654789321", 1, 65478932, "F")
            };
        #endregion

        #region Funciones
        /// <summary>
        /// Función que devuelve un listado de Personas relleno
        /// Pre: nada
        /// Post: nada
        /// </summary>
        /// <returns>List<ClsPersona></returns>
        public static List<ClsPersona> obtenerListadoPersonasDAL()
        {
            return ListadoPersonasDAL;
        }

        public static List<ClsPersona> obtenerListadoBD()
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            ClsPersona oPersona;
            List<ClsPersona> listadoPersonas = new List<ClsPersona>();

            try
            {
                miConexion.ConnectionString
                = "server=localhost;database=RubenBD;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;";
                miConexion.Open();

                miComando.CommandText = "SELECT * FROM personas";

                miComando.Connection = miConexion;

                SqlDataReader miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector

                if (miLector.HasRows)

                {

                    while (miLector.Read())

                    {

                        oPersona = new ClsPersona();

                        oPersona.Id = (int)miLector["Id"];

                        oPersona.Nombre = (string)miLector["Nombre"];

                        oPersona.Apellido = (string)miLector["Apellidos"];

                        oPersona.Telefono = (string)miLector["Telefono"];

                        oPersona.Email = (string)miLector["Email"];

                        oPersona.IdDepartamento = (int)miLector["IdDepartamento"];

                        oPersona.Dni = (int)miLector["Dni"];

                        oPersona.Sexo = (string)miLector["Sexo"];

                        listadoPersonas.Add(oPersona);

                    }

                }

                miLector.Close();

                miConexion.Close();

            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return listadoPersonas;
        }

        /// <summary>
        /// Función que devuelve un listado de Departamentos relleno
        /// Pre: nada
        /// Post: nada
        /// </summary>
        /// <returns>List<ClsDepartamento></returns>
        public static List<ClsDepartamento> obtenerListadoDepartamentosDAL()
        {
            return ListadoDepartamentosDAL;
        }
        /// <summary>
        /// Función que devuelve una persona por su ID
        /// Pre: el id debe existir en la lista
        /// Post: nunca devolverá null
        /// </summary>
        /// <param name="idPersona"> Id de la persona a buscar </param>
        /// <returns> Devuelve la persona encontrada </returns>
        public static ClsPersona obtenerPersonaPorID(int idPersona)
        {
            // Con Experssion Lambda
            // return ListadoPersonasDAL.Find(p => p.Id == idPersona);
            bool encontrado = false;
            ClsPersona persona = null;
            int i = 0;
            while (i < ListadoPersonasDAL.Count && !encontrado)
            {
                if (ListadoPersonasDAL[i].Id == idPersona)
                {
                    persona = ListadoPersonasDAL[i];
                    encontrado = true;
                }
                i++;
            }
            return persona;
        }
        /// <summary>
        /// Función que devuelve el tamaño del listado de personas
        /// </summary>
        /// <returns> Devuelve un entero </returns>
        public static int obtenerListadoPersonasCount()
        {
            return ListadoPersonasDAL.Count;
        }
        /// <summary>
        /// Función que devuelve el id de una persona por su posición
        /// </summary>
        /// <param name="posicion"> Posición de la que quiero el ID </param>
        /// <returns> Devuelve un entero </returns>
        public static int obtenerIDPersonaPorPosicion(int posicion)
        {
            return ListadoPersonasDAL[posicion].Id;
        }
        #endregion
    }
}

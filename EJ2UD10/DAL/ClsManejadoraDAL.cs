using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ClsManejadoraDAL
    {
        /// <summary>
        /// Función que se conecta con la BD en Azure y devuelve una persona
        /// Pre: id > 0
        /// Post: puede devolver null
        /// </summary>
        /// <param name="id"> ID de la persona a buscar </param>
        /// <returns> La persona de la base de datos </returns>
        public static ClsPersona obtenerPersonaPorID(int id)
        {
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            ClsPersona oPersona = null;
            try
            {
                miConexion = ConexionBD.getConexion();
                miComando.CommandText = "SELECT * FROM personasASP WHERE Id = @Id";
                miComando.Parameters.AddWithValue("@Id", id);
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
                        oPersona.Apellido = (string)miLector["Apellido"];
                        oPersona.Email = (string)miLector["Email"];
                        oPersona.Telefono = (string)miLector["Telefono"];
                        oPersona.IdDepartamento = (int)miLector["IdDepartamento"];
                        oPersona.Dni = (int)miLector["Dni"];
                        oPersona.Sexo = (string)miLector["Sexo"];
                    }
                }
                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            return oPersona;
        }

        /// <summary>
        /// Actualiza una persona en la base de datos por su ID.
        /// </summary>
        /// <param name="persona">Persona con los datos editados.</param>
        /// <returns>True si se actualizó</returns>
        public static bool actualizarPersonaDAL(ClsPersona persona)
        {
            bool exito = false;
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                miConexion = ConexionBD.getConexion();
                miComando.Connection = miConexion;
                miComando.CommandText = @"UPDATE personasASP SET 
                                      Nombre = @Nombre, 
                                      Apellido = @Apellido, 
                                      Email = @Email, 
                                      Telefono = @Telefono, 
                                      IdDepartamento = @IdDepartamento, 
                                      Dni = @Dni, 
                                      Sexo = @Sexo 
                                      WHERE Id = @Id";

                miComando.Parameters.AddWithValue("@Nombre", persona.Nombre);
                miComando.Parameters.AddWithValue("@Apellido", persona.Apellido);
                miComando.Parameters.AddWithValue("@Email", persona.Email);
                miComando.Parameters.AddWithValue("@Telefono", persona.Telefono);
                miComando.Parameters.AddWithValue("@IdDepartamento", persona.IdDepartamento);
                miComando.Parameters.AddWithValue("@Dni", persona.Dni);
                miComando.Parameters.AddWithValue("@Sexo", persona.Sexo);
                miComando.Parameters.AddWithValue("@Id", persona.Id);

                int filasAfectadas = miComando.ExecuteNonQuery();
                exito = filasAfectadas > 0;

                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return exito;
        }

        /// <summary>
        /// Función que se conecta con la BD en Azure y elimina una persona por su ID
        /// </summary>
        /// <param name="Id"> El id de la persona a borrar </param>
        /// <returns> El número de filas afectadas </returns>
        public static int deletePersonaDAL(int Id)
        {
            int numeroFilasAfectadas = 0;
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                miConexion = ConexionBD.getConexion();
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = Id;

                miComando.CommandText = "DELETE FROM personasASP WHERE Id=@id";
                miComando.Connection = miConexion;
                numeroFilasAfectadas = miComando.ExecuteNonQuery();

                miConexion.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return numeroFilasAfectadas;
        }

        /// <summary>
        /// Función que se conecta con la BD en Azure y añade una nueva persona
        /// </summary>
        /// <param name="personaNueva"> Persona a Añadir </param>
        /// <returns> Devuelve true si se ha añadido a la persona </returns>
        public static bool crearPersonaDAL(ClsPersona personaNueva)
        {
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            int filasAfectadas = 0;
            bool exito = false;

            try
            {
                miConexion = ConexionBD.getConexion();
                miComando.CommandText = "INSERT INTO personasASP (Id, Nombre, Apellido, Email, Telefono, IdDepartamento, Dni, Sexo) VALUES (@Id, @Nombre, @Apellido, @Email, @Telefono, @IdDepartamento, @Dni, @Sexo)";
                miComando.Parameters.AddWithValue("@Id", personaNueva.Id);
                miComando.Parameters.AddWithValue("@Nombre", personaNueva.Nombre);
                miComando.Parameters.AddWithValue("@Apellido", personaNueva.Apellido);
                miComando.Parameters.AddWithValue("@Email", personaNueva.Email);
                miComando.Parameters.AddWithValue("@Telefono", personaNueva.Telefono);
                miComando.Parameters.AddWithValue("@IdDepartamento", personaNueva.IdDepartamento);
                miComando.Parameters.AddWithValue("@Dni", personaNueva.Dni);
                miComando.Parameters.AddWithValue("@Sexo", personaNueva.Sexo);
                miComando.Connection = miConexion;
                
                filasAfectadas = miComando.ExecuteNonQuery();
                exito = filasAfectadas > 0;

            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return exito;
        }
    }
}

using ENT;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ManejadoraDAL
    {
        #region Funciones

        /// <summary>
        /// Función que se conecta con la BD y devuelve una lista de personajes con su puntuación total
        /// </summary>
        /// <returns> Devuelve una lista que puede no estar rellena </returns>
        /// <exception cref="Exception"> Puede haber un error al conectarse con la BD </exception>
        public static List<PersonajeConPuntuacionTotal> obtenerListaPersonajeConPuntuaciónTotalDAL()
        {
            List<PersonajeConPuntuacionTotal> lista = new List<PersonajeConPuntuacionTotal>();

            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            Personaje personajeSinPuntos;
            int puntos = 0;

            try
            {

                miConexion = ConexionBD.getConexion();
                miComando.CommandText = "SELECT " +
                                            "personaje.Id, " +
                                            "personaje.Nombre, " +
                                            "personaje.Imagen, " +
                                            "COALESCE(SUM( " + 
                                                "CASE " + 
                                                    "WHEN c.IdCombatiente1 = personaje.Id THEN c.PuntosCombatiente1 " +
                                                    "WHEN c.IdCombatiente2 = personaje.ID THEN c.PuntosCombatiente1 " +
                                                    "ELSE 0 " +
                                                "END " +
                                                "), 0) AS Puntos " +
                                        "FROM " +
                                            "Personaje AS personaje " +
                                        "LEFT JOIN " + 
                                            "Combate c ON personaje.Id = c.IdCombatiente1 OR personaje.Id = c.IdCombatiente2 " +
                                        "GROUP BY " +
                                            "personaje.Id, personaje.Nombre, personaje.Imagen " +
                                        "ORDER BY " +
                                            "Puntos DESC ";

                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {

                        personajeSinPuntos = new Personaje((int)miLector["Id"]);

                        if (miLector["Nombre"] != DBNull.Value)
                        {
                            personajeSinPuntos.Nombre = (String)miLector["Nombre"];
                        }
                        if (miLector["Imagen"] != DBNull.Value)
                        {
                            personajeSinPuntos.Imagen = (String)miLector["Imagen"];
                        }
                        if (miLector["Puntos"] != DBNull.Value)
                        {
                            puntos = (int)miLector["Puntos"];
                        }

                        PersonajeConPuntuacionTotal personajeConPuntos = new PersonajeConPuntuacionTotal(personajeSinPuntos, puntos);
                        lista.Add(personajeConPuntos);

                    }


                }
                miConexion.Close();
                miLector.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Ha habido un error al crear la lista de personajes con puntos, intentelo más tarde", ex);
            }

            return lista;
        }

        public static bool guardarCombateDAL(Combate combate)
        {
            bool guardado = false;
            try
            {
                if (comprobarExistenciaCombateDAL(combate))
                {
                    guardado = actualizarCombateDAL(combate);
                }
                else
                {
                    guardado = crearCombateDAL(combate);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ha habido un error al guardar el combate, intentelo más tarde", ex);
            }
            return guardado;
        }

        /// <summary>
        /// Función que añade un combate a la base de datos
        /// </summary>
        /// <param name="combate"> Combate a añadir</param>
        /// <returns> Un Combate </returns>
        /// <exception cref="Exception"> Puede haber un error al conectarse con la BD </exception>
        private static bool crearCombateDAL(Combate combate)
        {
            bool creado = false;
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            try
            {
                miConexion = ConexionBD.getConexion();
                miComando.CommandText = "INSERT INTO Combate (IdCombatiente1, IdCombatiente2, Fecha, PuntosCombatiente1, PuntosCombatiente2) " +
                                        "VALUES (@idCombatiente1, @idCombatiente2, @fecha, @puntosCombatiente1, @puntosCombatiente2)";
                miComando.Parameters.AddWithValue("@idCombatiente1", combate.IdCombatiente1);
                miComando.Parameters.AddWithValue("@idCombatiente2", combate.IdCombatiente2);
                miComando.Parameters.AddWithValue("@fecha", combate.Fecha.Date);
                miComando.Parameters.AddWithValue("@puntosCombatiente1", combate.PuntosCombatiente1);
                miComando.Parameters.AddWithValue("@puntosCombatiente2", combate.PuntosCombatiente2);
                miComando.Connection = miConexion;
                creado = miComando.ExecuteNonQuery() > 0;
                miConexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Ha habido un error al crear el combate, intentelo más tarde", ex);
            }
            return creado;
        }

        /// <summary>
        /// Función que actualiza un combate en la base de datos
        /// </summary>
        /// <param name="combate"> Combate a actualizar </param>
        /// <returns> Devuelve un booleano </returns>
        /// <exception cref="Exception"> Puede haber un error al conectarse con la BD </exception>
        private static bool actualizarCombateDAL(Combate combate)
        {
            bool actualizado = false;
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            try
            {
                miConexion = ConexionBD.getConexion();
                miComando.CommandText = @"UPDATE Combate 
                SET 
                    PuntosCombatiente1 = PuntosCombatiente1 + 
                        CASE
                            WHEN IdCombatiente1 = @idCombatiente1 THEN @puntosCombatiente1
                            ELSE @puntosCombatiente2
                        END,
                    PuntosCombatiente2 = PuntosCombatiente2 + 
                        CASE
                            WHEN IdCombatiente2 = @idCombatiente2 THEN @puntosCombatiente2
                            ELSE @puntosCombatiente1
                        END
                WHERE 
                    (IdCombatiente1 = @idCombatiente1 AND IdCombatiente2 = @idCombatiente2 AND Fecha = @fecha)
                    OR
                    (IdCombatiente1 = @idCombatiente2 AND IdCombatiente2 = @idCombatiente1 AND Fecha = @fecha);";

                miComando.Parameters.AddWithValue("@idCombatiente1", combate.IdCombatiente1);
                miComando.Parameters.AddWithValue("@idCombatiente2", combate.IdCombatiente2);
                miComando.Parameters.AddWithValue("@puntosCombatiente1", combate.PuntosCombatiente1);
                miComando.Parameters.AddWithValue("@puntosCombatiente2", combate.PuntosCombatiente2);
                miComando.Parameters.AddWithValue("@fecha", combate.Fecha.Date);
                miComando.Connection = miConexion;
                actualizado = miComando.ExecuteNonQuery() > 0;
                miConexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Ha habido un error al actualizar el combate, intentelo más tarde", ex);
            }
            return actualizado;
        }

        private static bool comprobarExistenciaCombateDAL(Combate combate)
        {
            bool existe = false;
            List<Combate> listaCombatesComprobar = new List<Combate>();
            Combate? combateBuscado = new Combate();
            try
            {
                listaCombatesComprobar = ListadosDAL.obtenerListadoCombatesDAL();
                combateBuscado = listaCombatesComprobar.Find(pelea =>( (
                pelea.IdCombatiente1 == combate.IdCombatiente1) && 
                (pelea.IdCombatiente2 == combate.IdCombatiente2) && 
                pelea.Fecha.Date == combate.Fecha.Date) ||
                ((pelea.IdCombatiente1 == combate.IdCombatiente2) &&
                (pelea.IdCombatiente2 == combate.IdCombatiente1) &&
                pelea.Fecha.Date == combate.Fecha.Date)
                );
            }
            catch (Exception ex)
            {
                throw new Exception("Ha habido un error al comprobar el combate, intentelo más tarde", ex);
            }
            if (combateBuscado != null)
            {
                existe = true;
            }
            return existe;
        }

        #endregion
    }
}

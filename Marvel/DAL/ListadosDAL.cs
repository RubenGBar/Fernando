using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ListadosDAL
    {
        public static List<Personaje> obtenerListadoPersonajesDAL()
        {
            List<Personaje> listado;
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            Personaje personaje;
            SqlDataReader miLector;
            try
            {
                listado = new List<Personaje>();
                miConexion = ConexionBD.getConexion();
                miComando.CommandText = "SELECT * FROM Personaje";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();
                while (miLector.Read())
                {
                    personaje = new Personaje();
                    personaje.ID = (int)miLector["ID"];
                    personaje.Nombre = (string)miLector["Nombre"];
                    personaje.Imagen = (string)miLector["Imagen"];
                    listado.Add(personaje);
                }
                miLector.Close();
                miConexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listado;
        }

        public static List<Combate> obtenerListadoCombatesDAL()
        {
            List<Combate> listado;
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            Combate combate;
            SqlDataReader miLector;
            try
            {
                listado = new List<Combate>();
                miConexion = ConexionBD.getConexion();
                miComando.CommandText = "SELECT * FROM Combate";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();
                while (miLector.Read())
                {
                    combate = new Combate();
                    combate.IdCombatiente1 = (int)miLector["IdCombatiente1"];
                    combate.IdCombatiente2 = (int)miLector["IdCombatiente2"];
                    combate.Fecha = (DateTime)miLector["Fecha"];
                    combate.PuntosCombatiente1 = (int)miLector["PuntosCombatiente1"];
                    combate.PuntosCombatiente2 = (int)miLector["PuntosCombatiente2"];
                    listado.Add(combate);
                }
                miLector.Close();
                miConexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listado;
        }
    }
}

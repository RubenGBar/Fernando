﻿using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ClsListadosDAL
    {
        /*
         * Obtener Listados Estáticos
         * #region Propiedades
        private static List<ClsCaballo> listadoCaballosDAL = new List<ClsCaballo>
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
        private static List<ClsRaza> listadoRazasDAL = new List<ClsRaza>
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
        #endregion*/

        /// <summary>
        /// Función que devuelve un listado de caballos relleno
        /// Pre: nada
        /// Post: nada
        /// </summary>
        /// <returns>List<ClsCaballo></returns>
        public static List<ClsCaballo> obtenerListadoCaballoDAL()
        {
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            ClsCaballo oCaballo;
            List<ClsCaballo> listadoCaballos = new List<ClsCaballo>();
            try
            {
                miConexion = ConexionBD.getConexion();
                miComando.CommandText = "SELECT * FROM Caballo";
                miComando.Connection = miConexion;
                SqlDataReader miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oCaballo = new ClsCaballo((int)miLector["IdCaballo"]);
                        oCaballo.Nombre = (string)miLector["Nombre"];
                        if (miLector["IdRaza"] != System.DBNull.Value)
                        {
                            oCaballo.IdRaza = (int)miLector["IdRaza"];
                        }
                        listadoCaballos.Add(oCaballo);
                    }
                }
                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            return listadoCaballos;
        }
        /// <summary>
        /// Función que devuelve un listado de razas rellenos
        /// Pre: nada
        /// Post: nada
        /// </summary>
        /// <returns>List<ClsRaza></returns>
        public static List<ClsRaza> obtenerListadoRazaDAL()
        {
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            ClsRaza oRaza;
            List<ClsRaza> listadoRazas = new List<ClsRaza>();
            try
            {
                miConexion = ConexionBD.getConexion();
                miComando.CommandText = "SELECT * FROM Raza";
                miComando.Connection = miConexion;
                SqlDataReader miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oRaza = new ClsRaza((int)miLector["IdRaza"]);
                        oRaza.NombreRaza = (string)miLector["NombreRaza"];
                        listadoRazas.Add(oRaza);
                    }
                }
                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            return listadoRazas;
        }

    }

}

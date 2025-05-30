﻿namespace ENT
{
    public class Temperaturas
    {
        #region Propiedades
        public int IdInvernadero { get; set; }
        public DateTime Fecha { get; set; }
        public double Temp1 { get; set; }
        public double Temp2 { get; set; }
        public double Temp3 { get; set; }
        public double Humedad1 { get; set; }
        public double Humedad2 { get; set; }
        public double Humedad3 { get; set; }
        #endregion

        #region Constructores
        public Temperaturas()
        {

        }
        public Temperaturas(int idInvernadero, DateTime fecha, double temp1, double temp2, double temp3, double humedad1, double humedad2, double humedad3)
        {
            IdInvernadero = idInvernadero;
            Fecha = fecha;
            Temp1 = temp1;
            Temp2 = temp2;
            Temp3 = temp3;
            Humedad1 = humedad1;
            Humedad2 = humedad2;
            Humedad3 = humedad3;
        }
        public Temperaturas(int idInvernadero, DateTime fecha)
        {
            IdInvernadero = idInvernadero;
            Fecha = fecha;
        }
        #endregion
    }
}

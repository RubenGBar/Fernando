using BL;
using ENT;

namespace MAUI.VM
{
    public class TemperaturaConNombreInvernadero: Temperaturas
    {
        #region Propiedades
        public string NombreInvernadero { get; set; }
        public bool EsVisibleTemp1 { get; }
        public bool EsVisibleTemp2 { get; }
        public bool EsVisibleTemp3 { get; }
        public bool EsVisibleHumedad1 { get; }
        public bool EsVisibleHumedad2 { get; }
        public bool EsVisibleHumedad3 { get; }
        public bool FechaCorrecta { get; }
        #endregion

        #region Constructores
        public TemperaturaConNombreInvernadero() : base()
        {
        }
        public TemperaturaConNombreInvernadero(Temperaturas temperatura, string nombreInvernadero) 
        : base(temperatura.IdInvernadero, temperatura.Fecha.Date)
        {
            NombreInvernadero = nombreInvernadero;
            EsVisibleTemp1 = temperatura.Temp1 < -90|| temperatura.Temp1 > 60;
            EsVisibleTemp2 = temperatura.Temp2 < -90 || temperatura.Temp2 > 60;
            EsVisibleTemp3 = temperatura.Temp3 < -90 || temperatura.Temp3 > 60;
            EsVisibleHumedad1 = temperatura.Humedad1 < 0 || temperatura.Humedad1 > 100;
            EsVisibleHumedad2 = temperatura.Humedad2 < 0 || temperatura.Humedad2 > 100;
            EsVisibleHumedad3 = temperatura.Humedad3 < 0 || temperatura.Humedad3 > 100;
            
            List<DateTime> fechas = new List<DateTime>();
            fechas = ListadosBL.obtenerListadoFechasBL(temperatura.IdInvernadero);
            FechaCorrecta = !fechas.Contains(temperatura.Fecha.Date);

            if (EsVisibleTemp1)
            {
                this.Temp1 = 0;
            }
            else
            {
                this.Temp1 = temperatura.Temp1;
            }

            if (EsVisibleTemp2)
            {
                this.Temp2 = 0;
            }
            else
            {
                this.Temp2 = temperatura.Temp2;
            }

            if (EsVisibleTemp3)
            {
                this.Temp3 = 0;
            }
            else
            {
                this.Temp3 = temperatura.Temp3;
            }

            if (EsVisibleHumedad1)
            {
                this.Humedad1 = 0;
            }
            else
            {
                this.Humedad1 = temperatura.Humedad1;
            }

            if (EsVisibleHumedad2)
            {
                this.Humedad2 = 0;
            }
            else
            {
                this.Humedad2 = temperatura.Humedad2;
            }

            if (EsVisibleHumedad3)
            {
                this.Humedad3 = 0;
            }
            else
            {
                this.Humedad3 = temperatura.Humedad3;
            }
        }
        #endregion
    }
}

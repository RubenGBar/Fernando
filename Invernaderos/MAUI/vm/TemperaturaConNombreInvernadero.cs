using BL;
using ENT;

namespace MAUI.VM
{
    public class TemperaturaConNombreInvernadero: Temperaturas
    {
        // Los booleanos los uso para calcular el rango de temperaturas y humedad en el que quiero que se muestre o no la interrogación, no sé cómo de mal estará
        // Lo mismo para el FechaCorrecta y el mensaje de error de la fecha
        #region Propiedades
        public string NombreInvernadero { get; set; }
        public bool EsVisibleTemp1 { get; }
        public double ResultadoTemp1 { get; }
        public bool EsVisibleTemp2 { get; }
        public double ResultadoTemp2 { get; }
        public bool EsVisibleTemp3 { get; }
        public double ResultadoTemp3 { get; }
        public bool EsVisibleHumedad1 { get; }
        public double ResultadoHumedad1 { get; }
        public bool EsVisibleHumedad2 { get; }
        public double ResultadoHumedad2 { get; }
        public bool EsVisibleHumedad3 { get; }
        public double ResultadoHumedad3 { get; }
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
            // Compruebo que las temperaturas estén entre los máximos rangos registrados en la Tierra para mostar o no la interrogación
            EsVisibleTemp1 = temperatura.Temp1 < -90|| temperatura.Temp1 > 60;
            EsVisibleTemp2 = temperatura.Temp2 < -90 || temperatura.Temp2 > 60;
            EsVisibleTemp3 = temperatura.Temp3 < -90 || temperatura.Temp3 > 60;
            // Ccompruebo que la humedad esté entre 0 o 100 para mostar o no la interrogación
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
                ResultadoTemp1 = temperatura.Temp1 / 100;
            }

            if (EsVisibleTemp2)
            {
                this.Temp2 = 0;
            }
            else
            {
                this.Temp2 = temperatura.Temp2;
                ResultadoTemp2 = temperatura.Temp2 / 100;
            }

            if (EsVisibleTemp3)
            {
                this.Temp3 = 0;
            }
            else
            {
                this.Temp3 = temperatura.Temp3;
                ResultadoTemp3 = temperatura.Temp3 / 100;
            }

            if (EsVisibleHumedad1)
            {
                this.Humedad1 = 0;
            }
            else
            {
                this.Humedad1 = temperatura.Humedad1;
                ResultadoHumedad1 = temperatura.Humedad1 / 100;
            }

            if (EsVisibleHumedad2)
            {
                this.Humedad2 = 0;
            }
            else
            {
                this.Humedad2 = temperatura.Humedad2;
                ResultadoHumedad2 = temperatura.Humedad2 / 100;
            }

            if (EsVisibleHumedad3)
            {
                this.Humedad3 = 0;
            }
            else
            {
                this.Humedad3 = temperatura.Humedad3;
                ResultadoHumedad3 = temperatura.Humedad3 / 100;
            }
        }
        #endregion
    }
}

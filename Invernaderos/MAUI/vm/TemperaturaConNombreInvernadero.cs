using BL;
using ENT;

namespace MAUI.VM
{
    public class TemperaturaConNombreInvernadero: Temperaturas
    {
        // Los booleanos son para saber si tengo que mostrar la interrogación o no (Sé que los nombres pueden que sean confusos)
        #region Propiedades
        public string NombreInvernadero { get; set; }
        public bool EsVisibleIntTemp1 { get; }
        public bool EsVisibleIntTemp2 { get; }
        public bool EsVisibleIntTemp3 { get; }
        public bool EsVisibleIntHumedad1 { get; }
        public bool EsVisibleIntHumedad2 { get; }
        public bool EsVisibleIntHumedad3 { get; }
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
            EsVisibleIntTemp1 = temperatura.Temp1 < -90 || temperatura.Temp1 > 60;
            EsVisibleIntTemp2 = temperatura.Temp2 < -90 || temperatura.Temp2 > 60;
            EsVisibleIntTemp3 = temperatura.Temp3 < -90 || temperatura.Temp3 > 60;
            // Ccompruebo que la humedad esté entre 0 o 100 para mostar o no la interrogación
            EsVisibleIntHumedad1 = temperatura.Humedad1 < 0 || temperatura.Humedad1 > 100;
            EsVisibleIntHumedad2 = temperatura.Humedad2 < 0 || temperatura.Humedad2 > 100;
            EsVisibleIntHumedad3 = temperatura.Humedad3 < 0 || temperatura.Humedad3 > 100;
            
            List<DateTime> fechas = new List<DateTime>();
            fechas = ListadosBL.obtenerListadoFechasPorIdBL(temperatura.IdInvernadero);
            FechaCorrecta = !fechas.Contains(temperatura.Fecha.Date);

            if (!EsVisibleIntTemp1)
            {
                this.Temp1 = temperatura.Temp1;
            }
            else
            {
                this.Temp1 = 0;
            }

            if (!EsVisibleIntTemp2)
            {
                this.Temp2 = temperatura.Temp2;
            }
            else
            {
                this.Temp2 = 0;
            }

            if (!EsVisibleIntTemp3)
            {
                this.Temp3 = temperatura.Temp3;
            }
            else
            {
                this.Temp3 = 0;
            }

            if (!EsVisibleIntHumedad1)
            {
                this.Humedad1 = temperatura.Humedad1;
            }
            else
            {
                this.Humedad1 = 0;
            }

            if (!EsVisibleIntHumedad2)
            {
                this.Humedad2 = temperatura.Humedad2;
            }
            else
            {
                this.Humedad2 = 0;
            }

            if (!EsVisibleIntHumedad3)
            {
                this.Humedad3 = temperatura.Humedad3;
            }
            else
            {
                this.Humedad3 = 0;
            }
        }
        #endregion
    }
}

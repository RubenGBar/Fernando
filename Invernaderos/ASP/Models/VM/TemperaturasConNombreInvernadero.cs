using BL;
using ENT;

namespace ASP.Models.VM
{
    public class TemperaturasConNombreInvernadero : Temperaturas
    {
        #region Propiedades
        public string NombreInvernadero { get; }
        public string URLInterrogacion { get; }
        public bool FechaCorrecta { get; }
        #endregion

        #region Constructores
        public TemperaturasConNombreInvernadero() : base()
        {

        }
        public TemperaturasConNombreInvernadero(Temperaturas temperatura, string nombreInvernadero)
        : base(temperatura.IdInvernadero, temperatura.Fecha.Date, temperatura.Temp1, temperatura.Temp2, temperatura.Temp3, temperatura.Humedad1, temperatura.Humedad2, temperatura.Humedad3)
        {
            NombreInvernadero = nombreInvernadero;
            URLInterrogacion = "https://i.pinimg.com/736x/f7/c4/b5/f7c4b5fbf5ec5b2e77d263bf9e108736.jpg";
            // Compruebo que la fecha sea correcta
            List<DateTime> fechas = new List<DateTime>();
            fechas = ListadosBL.obtenerListadoFechasPorIdBL(temperatura.IdInvernadero);
            FechaCorrecta = fechas.Contains(temperatura.Fecha.Date);
        }
        public TemperaturasConNombreInvernadero(bool fechaCorrecta, DateTime fecha)
        {
            URLInterrogacion = "https://i.pinimg.com/736x/f7/c4/b5/f7c4b5fbf5ec5b2e77d263bf9e108736.jpg";
            Fecha = fecha;
            FechaCorrecta = fechaCorrecta;
        }
        #endregion
    }
}

using System.Globalization;

namespace MAUI.Utils.Converters
{
    public class ConverterProgresBarHumedad : IValueConverter
    {
        /// <summary>
        /// Función que recibe y convierte un valor entre 0 y 99 y devuelve un float entre 0 y 1
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            double hum = 0;

            if (value != null)
            {
                hum = (double)value / 100.0;
            }

            return hum;
        }

        /// <summary>
        /// Devolvemos el mismo valor porque no necesitamos convertirlo de vuelta
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value;
        }
    }
}

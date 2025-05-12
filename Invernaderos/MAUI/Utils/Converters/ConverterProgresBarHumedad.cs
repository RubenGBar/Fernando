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
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            double resultado = 0;
            double min = 0;
            double max = 100;

            if (value is double hum)
            {
                resultado = (hum - min) / (max - min);
            }

            return resultado;
        }

        /// <summary>
        /// Devolvemos el mismo valor porque no necesitamos convertirlo de vuelta
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value;
        }
    }
}

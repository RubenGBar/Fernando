using System.Globalization;

namespace MAUI.Utils.Converters
{
    public class ConverterProgresBarTemperatura : IValueConverter
    {
        /// <summary>
        /// Función que recibe y convierte un valor entre -90 y 60 y devuelve un float entre 0 y 1
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            double resultado = 0;
            double min = 15.0;
            double max = 35.0;

            if (value is double temp)
            {
                resultado = (temp - min) / (max - min);
            }

            return Math.Clamp(resultado, 0.0, 1.0);
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

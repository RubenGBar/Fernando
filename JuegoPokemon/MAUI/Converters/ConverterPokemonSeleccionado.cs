using System.Globalization;

namespace MAUI.Converters
{
    public class ConverterPokemonSeleccionado : IValueConverter
    {
        /// <summary>
        /// Converter que valora el valor recibido y devuelve verde o rojo, o trasparante si es nullo
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            Color color = new Color();

            if (value != null)
            {
                if (value is Boolean correcto)
                {
                    if (correcto)
                    {
                        color = Color.FromArgb("27ae60");
                    }
                    else
                    {
                        color = Color.FromArgb("e74c3c");
                    }
                }
            }
            else 
            {
                color = Colors.Transparent;
            }

            return color;

        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value;
        }
    }
}

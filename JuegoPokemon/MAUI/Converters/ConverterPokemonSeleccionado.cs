

using System.Globalization;

namespace MAUI.Converters
{
    public class ConverterPokemonSeleccionado : IValueConverter
    {
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

            return color;

        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value;
        }
    }
}

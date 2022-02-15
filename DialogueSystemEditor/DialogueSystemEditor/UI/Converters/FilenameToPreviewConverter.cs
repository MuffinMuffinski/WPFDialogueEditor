using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace DialogueSystemEditor.UI.Converters
{
    public class FilenameToPreviewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = value.ToString();
            return "...\\" + val.Split('\\').Last();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("This is a oneway conversion!");
        }
    }
}

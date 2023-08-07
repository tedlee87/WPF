using FolderModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace FolderUI.Coverter
{
    [ValueConversion(typeof(FolderType), typeof(BitmapImage))]
    public class FolderTypeToImageConverter : IValueConverter
    {
        public static FolderTypeToImageConverter Instance = new FolderTypeToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var image = "images/file.png";
            switch ((FolderType)value)
            {
                case FolderType.Drive:
                    image = "images/drive.png";
                    break;
                case FolderType.Folder:
                    image = "images/fclosed.png";
                    break;
                default:
                    break;
            }

            return new BitmapImage(new Uri($"{Directory.GetCurrentDirectory()}/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

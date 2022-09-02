using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace TestWpf
{ 
    public static class Images
    {
        public readonly static ImageSource I0 = LoadImage("0.png");
        public readonly static ImageSource I1 = LoadImage("1.png");
        public readonly static ImageSource I2 = LoadImage("2.png");
        public readonly static ImageSource I3 = LoadImage("3.png");
        public readonly static ImageSource I4 = LoadImage("4.png");
        public readonly static ImageSource I5 = LoadImage("5.png");
        public readonly static ImageSource I6 = LoadImage("6.png");
        public readonly static ImageSource I7 = LoadImage("7.png");
        public readonly static ImageSource I8 = LoadImage("8.png");
        public readonly static ImageSource I9 = LoadImage("9.png");
        public readonly static ImageSource I10 = LoadImage("10.png");
        public readonly static ImageSource wall = LoadImage("wall.png");

        private static ImageSource LoadImage(string fileName)
        {
            return new BitmapImage(new Uri($"assets/{fileName}", UriKind.Relative));
        }
    }
}

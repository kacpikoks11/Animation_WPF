using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Animation x;

        public Image[,] Bitmap;
        public MainWindow()
        {
            x = new();
            Bitmap = new Image[x.row, x.column];
            InitializeComponent();
            SetupGrid();
        }

        private async void StartAnimation(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                await Task.Delay(100);
                x.AnimationStep1();
                x.AnimationStep2();
                if (!UpdateGrid())
                    break;
            }
        }

        private ImageSource ReturnImage(int field)
        {
            switch (field)
            {
                case 1:
                    return Images.I1;
                case 2:
                    return Images.I2;
                case 3:
                    return Images.I3;
                case 4:
                    return Images.I4;
                case 5:
                    return Images.I5;
                case 6:
                    return Images.I6;
                case 7:
                    return Images.I7;
                case 8:
                    return Images.I8;
                case 9:
                    return Images.I9;
                case 10:
                    return Images.I10;
                case Animation.wall_val:
                    return Images.wall;
            }
            return Images.I0;
        }

        private void SetupGrid()
        {
            AnimationGrid.Rows = x.row;
            AnimationGrid.Columns = x.column;
            for (int i = 0; i < x.row; ++i)
                for (int j = 0; j < x.column; ++j)
                {
                    Image image = new()
                    {
                        Source = ReturnImage(x[i, j])
                    };
                    AnimationGrid.Children.Add(image);
                    Bitmap[i, j] = image;
                }
        }
        private bool UpdateGrid()
        {
            bool returning_value = false;
            for (int i = 0; i < x.row; ++i)
                for (int j = 0; j < x.column; ++j)
                {
                    ImageSource z = ReturnImage(x[i, j]);
                    if (Bitmap[i, j].Source != z)
                    {
                        returning_value = true;
                        Bitmap[i, j].Source = z;
                    }

                }
            return returning_value;
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            AnimationGrid.Children.Clear();
            x = new(25, 25);
            Bitmap = new Image[x.row, x.column];
            SetupGrid();
            StartAnimation(sender, e);
        }
    }
}
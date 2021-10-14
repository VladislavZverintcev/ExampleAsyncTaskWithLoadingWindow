using System.Windows;
using System;
using System.Windows.Media;
using UniversalLoadingWindowLib;
using System.Threading;

namespace ExampleAsyncTaskWithLoadingWindow
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Color a = new Color { A = 255, R = 45, G = 70, B = 100 };
            Color b = new Color { A = 255, R = 70, G = 110, B = 160 };
            LinearGradientBrush mainbrush = new LinearGradientBrush(a, b, 90);
            Color title_foreground = new Color { A = 255, R = 180, G = 170, B = 50 };
            Color annotation_foreground = new Color { A = 255, R = 170, G = 200, B = 225 };
            string title = "Loading";
            string annotation = "Pleace, wait few seconds...";

            UniversalLoadingWindow ulw = new UniversalLoadingWindow(title, annotation, mainbrush,
                title_foreground, title_foreground, annotation_foreground);
            
            ulw.Loading(this, () => WorkMethod(ulw));
        }
        void WorkMethod(UniversalLoadingWindow ulw)
        {
            for (int i = 0; i < 15000000; i++)
            {
                ulw.SetPercentProgress(Convert.ToByte((((double)i / (double)15000000)) * 100));
            }
            Thread.Sleep(1000); //For show 100%
        }
    }
}

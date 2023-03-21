using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
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

namespace ModernDesign
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)

        {



        }





        private void rectangle2_MouseDown(object sender, MouseButtonEventArgs e)

        {

            this.DragMove();

        }

        private void rectangle1_MouseDown(object sender, MouseButtonEventArgs e)

        {

            this.DragMove();

        }



        private void button1_Click(object sender, RoutedEventArgs e)

        {

            //this.Close();
            //This is the correct Shutdown method.
            App.Current.Shutdown(); 

        }



        private void button3_Click(object sender, RoutedEventArgs e)

        {

            this.WindowState = WindowState.Minimized;



        }



        private void button2_Click(object sender, RoutedEventArgs e)

        {

            this.WindowState = WindowState.Maximized;

        }

        private void StartDictation(object sender, RoutedEventArgs ev)
        {
            Console.WriteLine("Start Works");
        }

        private void StopDictation(object sender, RoutedEventArgs ev)
        {
            Console.WriteLine("Stop Works");
        }
    }

}


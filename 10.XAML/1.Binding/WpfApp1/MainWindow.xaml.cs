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

namespace WpfApp1
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi! " + textbox1.Text);
        }

        private void preferColorPanel_Click(object sender, RoutedEventArgs e)
        {
            var b = (StackPanel)sender;
            RadioButton rb = e.Source as RadioButton;
            string colorname = rb.Content.ToString();
            switch (colorname)
            {
                case "紅":
                    this.Background = new SolidColorBrush(Colors.Red);
                    break;
                case "黃":
                    this.Background = new SolidColorBrush(Colors.Yellow);
                    break;
                case "白":
                default:
                    this.Background = new SolidColorBrush(Colors.White);
                    break;
            }
        }
    }
}

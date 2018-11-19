using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
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
            Employee emp = new Employee();
            emp.Name = "Jack";
            emp.Level = 1;
            emp.Salary = 300000;

            DataContractJsonSerializer formatter = new DataContractJsonSerializer(emp.GetType());
            FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Employee.json", FileMode.Create);
            formatter.WriteObject(fs, emp);

            fs.Close();
            MessageBox.Show("OK");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Employee));
            FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Employee.json", FileMode.Open);
            Employee emp = (Employee)formatter.ReadObject(fs);
            fs.Close();

            label1.Content = emp.Level;
            label2.Content = emp.Name;
            label3.Content = emp.Salary;
        }
    }
}

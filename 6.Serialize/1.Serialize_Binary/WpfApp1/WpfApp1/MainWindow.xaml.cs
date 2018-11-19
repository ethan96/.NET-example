using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

            //Employee[] emps = new Employee[] 
            //{
            //    new Employee{ Name = "Jack", Level = 1, Salary = 30000 },
            //    new Employee{ Name = "David", Level = 4, Salary = 40000 },
            //    new Employee{ Name = "Brian", Level = 9, Salary = 60000 }
            //};

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Employee.bin", FileMode.Create);
            formatter.Serialize(fs, emp);
            //formatter.Serialize(fs, emps);

            fs.Close();
            MessageBox.Show("OK");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Employee.bin", FileMode.Open);
            Employee emp = (Employee)formatter.Deserialize(fs);
            
            //object obj = formatter.Deserialize(fs);
            //var objests = obj as List<object>;
            //List<Employee> emps = new List<Employee>();
            //foreach (var objest in objests)
            //{
            //    Employee emp = (Employee)objest;
            //    emps.Add(emp);
            //}
            fs.Close();

            label1.Content = emp.Level;
            label2.Content = emp.Name;
            label3.Content = emp.Salary;

            //label1.Content = string.Join(", ", emps.Select(p => p.Name).ToList());
            //label2.Content = string.Join(", ", emps.Select(p => p.Level.ToString()).ToList());
            //label3.Content = string.Join(", ", emps.Select(p => p.Salary.ToString()).ToList());
        }
    }
}

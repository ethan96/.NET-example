using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
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

        private void listBox1_Click(object sender, RoutedEventArgs e)
        {
            var cn = new EntityConnection();
            cn.ConnectionString = "Name=pubsEntities";
            var cmd = cn.CreateCommand();
            cmd.CommandText = "select Value r from pubsEntities.Stores as r";
            cn.Open();
            var dr = cmd.ExecuteReader(System.Data.CommandBehavior.SequentialAccess);
            while (dr.Read())
            {
                listBox2.Items.Add(dr[0].ToString() + "\t" + dr[1].ToString() + "\t" + dr[5].ToString());
            }
            cn.Close();
            cn.Dispose();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var ctx = new pubsEntities();
            var stores = from s in ctx.stores
                         select new { s.stor_id, s.stor_name };

            //var stores = ctx.stores.Select(s => new { s.stor_id, s.stor_name});

            foreach (var store in stores)
            {
                listBox2.Items.Add(store.stor_id + "\t" + store.stor_name);
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            var ctx = new pubsEntities();
            var store = new store();
            store.stor_id = "9898";
            store.stor_name = "UUU";
            ctx.stores.Add(store);
            ctx.SaveChanges();
        }

        private void btton4_Click(object sender, RoutedEventArgs e)
        {
            var ctx = new pubsEntities();
            var s = ctx.stores.Where(p => p.stor_id == "9898").FirstOrDefault();
            if (s != null)
            {
                s.stor_name = "JJJ";
                ctx.SaveChanges();
            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            var ctx = new pubsEntities();
            var s = (from c in ctx.stores
                     where c.stor_id == "9898"
                     select c).FirstOrDefault();
            if (s != null)
            {
                ctx.stores.Remove(s);
                ctx.SaveChanges();
            }
        }
    }
}

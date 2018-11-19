using System;
using System.Collections.Generic;
using System.IO;
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

namespace WPF02
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
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @"C:\temp";
            watcher.IncludeSubdirectories = true;
            watcher.Filter = "*.*";
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.DirectoryName;
            watcher.Created += Watcher_Changed;
            watcher.Changed += Watcher_Changed;
            watcher.Renamed += Watcher_Renamed;
            watcher.EnableRaisingEvents = true;
        }

        public void UpdateUI(string s)
        {
            listBox1.Items.Add(s);
        }

        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            string s = string.Format("{0}: {1}-{2}", e.ChangeType, e.OldFullPath, e.FullPath);
            this.Dispatcher.Invoke(() => { UpdateUI(s); });
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            string s = string.Format("{0}:{1}", e.ChangeType, e.FullPath);
            this.Dispatcher.Invoke(() => { UpdateUI(s); });
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filename = textBox1.Text;
            if (!File.Exists(filename))
            {
                MessageBox.Show("檔案不存在");
                return;
            }

            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                //StreamReader sr = new StreamReader(fs);
                //textBox2.Text = sr.ReadToEnd();
                //sr.Close();
                using (StreamReader sr = new StreamReader(fs))
                {
                    textBox2.Text = sr.ReadToEnd();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filename = textBox1.Text;
            using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(textBox2.Text);
                sw.Close();
                //using (StreamWriter sw = new StreamWriter(fs))
                //{
                //    sw.Write(textBox2.Text);
                //}
            }
            MessageBox.Show("OK");
        }
    }
}

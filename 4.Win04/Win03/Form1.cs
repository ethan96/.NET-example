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
            using (FileStream fs = File.Open(string.Format("{0}/student.bin", Environment.CurrentDirectory), FileMode.Open))
            {
                BinaryReader reader = new BinaryReader(fs);
                while (reader.PeekChar() != -1)
                {
                    Student student = new Student
                    {
                        ID = reader.ReadInt32(),
                        Name = reader.ReadString(),
                        AvgScore = reader.ReadSingle()
                    };
                    listBox1.Items.Add(student.ID + ", " + student.Name + ", " + student.AvgScore);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student[] students = new Student[]
            {
                new Student{ ID = 1, Name = "Lisa", AvgScore = 88 },
                new Student{ ID = 2, Name = "Mickey", AvgScore = 90}
            };
            using (FileStream fs = File.Create(string.Format("{0}/student.bin", Environment.CurrentDirectory)))
            {
                BinaryWriter writer = new BinaryWriter(fs);
                foreach (var student in students)
                {
                    writer.Write(student.ID);
                    writer.Write(student.Name);
                    writer.Write(student.AvgScore);
                }
                writer.Dispose();

                //using (BinaryWriter writer = new BinaryWriter(fs))
                //{
                //    foreach (var student in students)
                //    {
                //        writer.Write(student.ID);
                //        writer.Write(student.Name);
                //        writer.Write(student.AvgScore);
                //    }
                //}
            }

            MessageBox.Show("OK");
        }
    }
}

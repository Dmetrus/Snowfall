using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNOWFALLCHERN
{
    public partial class Form1 : Form
    {
        IList<Class1> list = new List<Class1>();
        Timer Vremya;
        Image photo = Resource1.SMALLWHITESNOW;
        Image photo2 = Resource1.BigBlackRosahutor;
        Graphics g;
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            g = Graphics.FromImage(pictureBox1.BackgroundImage);
            for (int i = 0; i < 69; i++)
                list.Add(new Class1() { size = random.Next(20, 50) });
            Vremya = new Timer();
            Vremya.Interval = 7;
            Vremya.Tick += Vremya_Tick;

        }

        private void Vremya_Tick(object sender, EventArgs e)
        {
            Refresh();
            g.DrawImage(photo2, 0, 0);
            foreach (Class1 item in list)
            {
                g.DrawImage(photo, item.x, item.y, item.size, item.size);
                item.y += item.size / 4;
                if (item.y > Height)
                {
                    item.x = random.Next(0, Width);
                    item.y = -50;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Class1 item in list)
            {
                item.y = random.Next(-Height, -50);
                item.x = random.Next(0, Width);
            }
            g.DrawImage(photo2, 0, 0);
            Refresh();
            if (Vremya.Enabled)
            {
                Vremya.Stop();
                button1.Text = "Start";
                
            }
            else
            {
                Vremya.Start();
                button1.Text = "Stop";
            }

        }
    }
}

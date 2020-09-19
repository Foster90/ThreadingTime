using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadingTime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = (DateTime.Now).ToString(@"hh\:mm\:ss");
            var timer = new System.Windows.Forms.Timer { Interval = 1000 };
            timer.Tick += (o, args) =>
            {
                label1.Text = (DateTime.Now).ToString(@"hh\:mm\:ss");
            };
            timer.Start();

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(t =>
            {
                               
                int i, number, fact;
                number = Decimal.ToInt32(numericUpDown1.Value);
                fact = number;
                for (i = number - 1; i >= 1; i--)
                {
                    fact = fact * i;
                }
                             

                Invoke((MethodInvoker)delegate {
                    label2.Text = fact.ToString(); // runs on UI thread
                });


            })
            { IsBackground = true };
            th.Start();

        }

    }
    
}


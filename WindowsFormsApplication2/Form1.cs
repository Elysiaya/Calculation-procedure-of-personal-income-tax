using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {

        struct TaxRecord
        {
            public double upperLimit;
            public double taxRate;
            public double deduction;
        }

        private TaxRecord[] taxrecord = new TaxRecord[7];
        private const double m_dThreshold = 3500;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double input = Convert.ToDouble(this.textBox1.Text);
                double taxes = 0;
                if (input > m_dThreshold)
                {
                    foreach (var t in taxrecord)
                    {
                        if (input <= m_dThreshold + t.upperLimit)
                        {
                            taxes = (input - m_dThreshold) * t.taxRate - t.deduction;
                            break;
                        }
                    }
                }

                //税后所得
                double shuihousuode = input - taxes;
                //显示



                this.textBox2.Text = shuihousuode.ToString("0.00");
                this.textBox3.Text = taxes.ToString("0.00");
            }
            catch 
            {

                MessageBox.Show("输入错误，好好看");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            double[] a = new double[7] { 1500, 4500, 9000, 35000, 55000, 80000, double.PositiveInfinity };
            double[] b = new double[7] { 0.03,0.1,0.2,0.25,0.3,0.35,0.45 };
            double[] c = new double[7] { 0,105,555,1005,2775,5505,13505};
            for (int i = 0; i < 7; i++) 
            {
                taxrecord[i].upperLimit = a[i];
                taxrecord[i].taxRate = b[i];
                taxrecord[i].deduction = c[i];
            }


        }
    }
}

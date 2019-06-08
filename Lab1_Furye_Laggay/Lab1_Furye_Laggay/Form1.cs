using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_Furye_Laggay
{
    public partial class Form1 : Form
    {
        double E;
        double Ti;
        double T;
        public Form1()
        {
            InitializeComponent();
            E = double.Parse(textBoxE.Text);
            Ti = double.Parse(textTi.Text);
            T = double.Parse(textBoxT.Text);
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            E = double.Parse(textBoxE.Text);
            Ti = double.Parse(textTi.Text);
            T = double.Parse(textBoxT.Text);

            List<double> numbersX = new List<double>(1);
            List<double> numbersY = new List<double>(1);
            double[] y1 = new double[105];
            double[] x1 = new double[105];     
            double[] y2= new double[105];
            double[] x2 = new double[105];
            double[] y3 = new double[105];
            double[] x3 = new double[105];
            for (int i = 0; i < 105; i++)

            {

                // Вычисляем значение X


                x2[i] = -53 + 1 * i;

                

                //if ((x[i] <= -104 && x[i] >= -156) || (x[i] <= 52 && x[i] >= 0) || (x[i] >= 156 && x[i] <= 208))


                if (x2[i] <= 52 && x2[i] >= 0)
                {
                        // Вычисляем значение функций в точке X

                        y2[i] = (-2 * E * x2[i] + E * Ti) / Ti;
                    //x1[i] = x2[i] - T;
                   // y1[i] = y2[i];
                    x3[i] = x2[i] + T;
                    y3[i] = y2[i];



                }

                //else if((x[i] >= -208 && x[i] <-156) || (x[i] >= -52 && x[i] < 0) || (x[i] >= 104 && x[i] < 156))
                if(x2[i] >= -52 && x2[i] < 0)
                {

                    y2[i] = (2 * E * x2[i] + E * Ti) / Ti;
                    //x1[i] = x2[i] - T;
                    //y1[i] = y2[i];
                    x3[i] = x2[i] + T;
                    y3[i] = y2[i];
                }


            }

           // for(int i = 0; i < x1.Length; i++)
           // {
           //     numbersX.Add(x1[i]);
            //}
            for (int i = 0; i < x2.Length; i++)
            {
                numbersX.Add(x2[i]);
            }
            for (int i = 0; i < x3.Length; i++)
            {
                numbersX.Add(x3[i]);
            }
           /* for (int i = 0; i < y1.Length; i++)
            {
                numbersY.Add(y1[i]);
            }*/
            for (int i = 0; i < y2.Length; i++)
            {
                numbersY.Add(y2[i]);
            }
            for (int i = 0; i < y3.Length; i++)
            {
                numbersY.Add(y3[i]);
            }
            double[] x = numbersX.ToArray<double>();
            double[] y = numbersY.ToArray<double>();
            //x = x.Where(a => a != 0).ToArray();
           // y = y.Where(a => a != 0).ToArray();
            chart1.ChartAreas[0].AxisX.Minimum = -300;

            chart1.ChartAreas[0].AxisX.Maximum = 300;

            chart1.ChartAreas[0].AxisY.Minimum = 0;

            chart1.ChartAreas[0].AxisY.Maximum = 30;

            // Определяем шаг сетки

            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 52;



            // Добавляем вычисленные значения в графики

            chart1.Series[0].Points.DataBindXY(x, y);

            Pk();

           
        }

         public double Anull()
        {
            double Anull = 0;
            Anull = (4 * E) / T;
            return Anull;
        }
        
        public double Pc()
        {
            double Pc = 0;
            Pc = (E*E)/6;
            return Pc;
        }
        public double Pk()
        {
            double P = Pc();
            label5.Text ="Pc: "+ P.ToString();
            //double Pk = 0;
            double An = 0;
            int n = 1;
            double Pk= (E*E)/16;
            do
            {
                An = (8* E * Math.Pow(Math.Sin((3.14 *n)/4), 2)) / (3.14 * 3.14 * n * n );
                listBox1.Items.Add(n + ") " + An);
           double A = 0.5*An*An;
                Pk += A;
                chart2.Series[0].Points.AddXY(n, An);
                
                chart3.Series[0].Points.AddXY(n, Math.Atan2(0, An));
                listBox2.Items.Add(n + ") " + Math.Atan2(0, An));
                n++;
            } while ((Pk / P) < 0.95);
            label6.Text ="Pk: "+ Pk.ToString();
            this.label4.Text = "Кол-во гармоник: "+(n-1); 
                return Pk;
        }
    
    }

      
    
}

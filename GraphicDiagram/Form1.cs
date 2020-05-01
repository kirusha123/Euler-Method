using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicDiagram
{
    public partial class Form1 : Form
    {
        //dif eq type => y'=a*x^s
        double a;
        int x;
        double s;
        double x0;
        double y0;
        int points_quantity;
        //double h; // h -> x*h изменяет шаг по оси абсцисс
        //int num_graphic;

        public Form1()
        {
            InitializeComponent();
            a = 0.0;
            x = 0;
            s = 0.0;
            points_quantity = 10;
            //num_graphic = 0;
        }

        public string set_answer()
        {
            string output;
            if (a == 0)
            {
                output = "C1";
            }
            else
            {
                if (s == -1)
                {
                    output = Convert.ToString(a) + "*Log(x) + C1";
                }
                else
                {
                    output = Convert.ToString(a) + " * x^" + Convert.ToString(s+1) + " + C1";
                }
            }

            return output;
        }

        public void Init_Eq_param()
        {
            if (textBox1.Text.Length != 0)
            {
                a = Convert.ToDouble(textBox1.Text);
            }
            else
            {
                MessageBox.Show("введите константу 'a' ");
                return;
            }

            if (textBox3.Text.Length != 0)
            {
                s = Convert.ToDouble(textBox3.Text);
            }
            else
            {
                MessageBox.Show("введите константу 's' ");
                return;
            }

            if (textBox2.Text.Length != 0)
            {
                points_quantity = Convert.ToInt32(textBox2.Text);
                if ((points_quantity <= 1) && (points_quantity > 1000))
                {
                    points_quantity = 100;
                }
                textBox2.Text = Convert.ToString(points_quantity);
            }

            if (textBox5.Text.Length != 0)
            {
                x0 = Convert.ToDouble(textBox5.Text);
                if ((x0 <= 0)&&(x0 >= 1))
                {
                    x0 = 0;
                }
            }
            else
            {                
                    MessageBox.Show("ВВедите x0");
            }

            if (textBox6.Text.Length != 0)
            {
                y0 = Convert.ToDouble(textBox6.Text);
            }
            else
            {
                MessageBox.Show("ВВедите y0");
            }
        }

       /* private void Calc_points_quantity()
        {
            points_quantity =Convert.ToInt32(1/h);
            points_quantity++;
        }*/

        private void set_graph_points()
        {
            
            double H = 1;// отрезок от 0 до 1
            
            double delta = H/points_quantity;

            double prevFxy = a * Math.Pow(x0, s);
            double prevY = y0;
            double prevX = x0;
            chart1.Series[0].Points.AddXY(prevX, prevY);
            double x;
            double y;

            for (int i  = 1; i <= points_quantity ; i ++)
            {
                x = prevX + delta;
                
                y = prevY + prevFxy * delta;

                chart1.Series[0].Points.AddXY(x, y);

                prevX = x;
                prevY = y;
                prevFxy = a * Math.Pow(x, s);
            }

           /*double x;
            double y;
            for (int i = 0; i < points_quantity; i++)
            {
                x = Convert.ToDouble(i) * h;
                x = Math.Round(x, 2);
                if (s != -1)
                {   
                    if((x == 0)&&(s < 0))
                    {
                        x += 0.01;
                    }
                    y = (a / (s+1)) * Math.Pow(x, s + 1);
                }
                else
                {
                  
                        y = a*Math.Log(x);
                        y = Math.Round(y, 2);

                    
                }

                if (s == -1)
                {
                    if (x > 0)
                    {
                        chart1.Series[0].Points.AddXY(x,y);
                    }
                } 
                else
                {
                    chart1.Series[0].Points.AddXY(x, y);
                }
            }*/
        }
        
        private void graph_setup()
        {
            /*chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0,0.1);
            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;*/
            chart1.Series[0].Points.Clear();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Init_Eq_param();
            graph_setup();
            textBox4.Text = set_answer();
            //Calc_points_quantity();
            set_graph_points();
        }

     
    }
}

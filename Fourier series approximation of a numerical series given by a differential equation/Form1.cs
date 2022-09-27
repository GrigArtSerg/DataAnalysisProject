using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace TIPIS_Lab_4_5
{
	public partial class Form1 : Form
	{
        /// <summary>
        /// Аппроксимация числового ряда
        /// заданного дифференциальным уравнением
        /// с помощью разложения в ряд Фурье
        /// </summary>
        public const int X_Min = 0;
        public const int duration = 20;
        public const double disc = 0.1;
        public const double k1 = -4;
        public const double k2 = 7;

        public double[,] Source;
        public double[,] Furiered;

        GraphPane pane;

        public Form1 ()
		{
			InitializeComponent ();

            pane = zedGraph.GraphPane;
            
            pane.CurveList.Clear();
        }

        

        #region Buttons
        private void Button_Click(object sender, EventArgs e)
        {
            Source = GetPointsList(); // Исходные значения

            double T = Period(Source);

            DrawGraph(Source, "Исходные значения", Color.Red);

            double[] A_i = Ai(Source, T, Lab5.Checked);
            double[] B_i = Bi(Source, T, Lab5.Checked);

            Furiered = Furier(Source, T, A_i, B_i);

            DrawGraph(Furiered, "Рассчитаные Значения", Color.Blue);

            double[] Otklon = MidSqrtOtkl(Source); // Стандартное отклонение

            double[] Dis = Disp(Source, Furiered); // Дисперсия

            double Det = Determine(Otklon, Dis); // Коэффициент детерминации

            CoefEnter.Text = Det.ToString();

            PerTVal.Text = T.ToString();

        }

        #region Лабораторная работа 5
        private void DetOtCulc_Click(object sender, EventArgs e)
        {
            double[,] Correlation = new double[2, Source.Length / 2 - 1];

            double[] Otklon;

            double[] Dis = Disp(Source, Furiered);

            for (int i = 0; i < Source.Length / 2 - 1; i++)
            {
                Otklon = MidSqrtOtkl(Source, i);

                Correlation[0, i] = Source[0, i]*(1/disc);
                Correlation[1,i] = Determine(Otklon, Dis, i);
            }

            DrawGraph(Correlation, "Корреляция", Color.Green);
        }
        #endregion
        

        #endregion

        #region Рассчет периода
        private double Period(double[,] Points)
        {
            double T = 0;

            int lenMas = Points.Length / 2 - 1;

            double[] Covariation = new double[lenMas];
            double[] KKor = new double[lenMas];
            double[] MSOtklLag = new double[lenMas];
            double[] MSOtklSource = new double[lenMas];

            double Original_Mid = 0;
            double Lag_Mid = 0;
            int len = 0;
            int point = 0;

            for (int i = 0; i < Points.Length/2-1; i++)
            {
                len = Points.Length / 2 - (i + 1);
                Original_Mid = 0;
                Lag_Mid = 0;

                
                // Рассчет ковариации
                for (int j = i + 1; j < Points.Length/2; j++)
                {
                    point = j - (i + 1);

                    Covariation[i] += Points[1, j] * Points[1, point];

                    Original_Mid += Points[1, j];

                    Lag_Mid += Points[1, point];
                }

                Original_Mid /= len;
                Lag_Mid /= len;

                Covariation[i] = Covariation[i] / len - Original_Mid * Lag_Mid;

                
                // Рассчет среднеквадратичного отклонения
                for (int j = i + 1; j < Points.Length/2; j++)
                {
                    point = j - (i + 1);

                    MSOtklSource[i] += Math.Pow((Points[1, j] - Original_Mid), 2);
                    MSOtklLag[i] += Math.Pow((Points[1, point] - Lag_Mid), 2);
                }

                MSOtklSource[i] /= (len - 1);
                MSOtklLag[i] /= (len - 1);

                KKor[i] = Covariation[i] / Math.Sqrt(MSOtklLag[i] * MSOtklSource[i]);
            }

            for(int i = 0; i < KKor.Length-1; i++)
            {
                if ((KKor[i + 1] < 0 && KKor[i] > 0) || (KKor[i + 1] > 0 && KKor[i] < 0))
                {
                    T = i;
                    break;
                }
            } 

            return T*disc;
        }

        #endregion

        #region Рассчет значений
        //Возвращает лист исходных точек. ТАБУЛИРОВАНИЕ 
        private double[,] GetPointsList()
        {
            double[,] Points = new double[2, duration];
            double x = X_Min;

            for (int i = X_Min; i < X_Min + duration; x += disc, i++)
            {
                Points[0, i] = x; // 1й ряд - значения x
                Points[1, i] = func(x); // 2й ряд - значения y
            }

            return Points;
        }

        /// <summary>
        /// Функция рассчета значения Y
        /// </summary>
        /// <param name="x">принимаемое значение - координата X</param>
        /// <returns></returns>
        private double func(double x)
        {

            double a = (double)A_holder.Value;
            double b = (double)B_holder.Value;
            double c = (double)C_holder.Value;
            double d = (double)D_Holder.Value;

            double a2 = Math.Pow(a, 2);
            double b2 = Math.Pow(b, 2);
            double c2 = Math.Pow(c, 2);
            double d2 = Math.Pow(d, 2);

            double b4 = Math.Pow(b, 4);
            double d4 = Math.Pow(d, 4);

            double znamenatel = 4 * a2 * d2 + b4 - 2 * b2 * d2 + d4;

            double Ans = k1 * Math.Pow(Math.E, x * (-Math.Sqrt(a2 - b2) - a))
                       + k2 * Math.Pow(Math.E, x * (-Math.Sqrt(a2 - b2) - a))

                       - (2 * a * c * d * Math.Sin(d * x)) / znamenatel
                       - (b2 * c * Math.Cos(d * x)) / znamenatel
                       + (c * d2 * Math.Cos(d * x)) / znamenatel;


            //double Ans = Math.Sin(x) * 4;

            return Ans;
        }
        #endregion

        #region Рассчет разложения в ряд Фурье
        // Разложение в ряд Фурье
        private double[,] Furier(double[,] Points, double T, double[] A_i, double[] B_i)
        {
            int len = (int)Points.Length / 2;
            double[,] Furiered = new double[2, len];

            
            for(int i = 0; i < Points.Length/2; i++)
            {
                Furiered[0, i] = Points[0, i];

                Furiered[1, i] = A_i[0]
                   
                    + A_i[1] * Math.Cos(2 * Math.PI * 1 * Points[0, i] / T)
                    + A_i[2] * Math.Cos(2 * Math.PI * 2 * Points[0, i] / T)

                    + B_i[0] * Math.Sin(2 * Math.PI * 1 * Points[0, i] / T)
                    + B_i[1] * Math.Sin(2 * Math.PI * 2 * Points[0, i] / T);
            }
            
            /*
            for (int i = 0; i < Points.Length / 2; i++)
            {
                Furiered[0, i] = Points[0, i];
                Furiered[1, i] = A_i[0];

                for (int j = 1; j < A_i.Length; j++)
                {
                    Furiered[1, i] = Furiered[1, i]
                        + A_i[j] * Math.Cos(2 * Math.PI * j * Points[0, i] / T);
                }

                for (int j = 0; j < B_i.Length; j++)
                {
                    Furiered[1, i] = Furiered[1, i]
                        + B_i[j] * Math.Sin(2 * Math.PI * j + 1 * Points[0, i] / T);
                }
            }
            */
            return Furiered;
        }
        #endregion

        #region Рассчет коэффициеннтов для Фурье
        // Рассчет коэффициента A
        private double[] Ai(double[,] Points, double T, bool many)
        {
            int size = 3;
            int len = Points.Length / 2;
            if (many) size = len / 8 + 1;
            double[] A_koef = new double[size];
            double dx = T / (Points.Length / 2);

            // A0 A1 A2
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    A_koef[i] += Points[1, j] * dx
                        * Math.Cos(2 * Math.PI * Points[0, j] * i / T);

                    //A_koef[i] += (Points[1, j-1] + Points[1, j])/2 * dx * Math.Cos(2 * Math.PI * Points[0, j-1] * i / T);
                }
                A_koef[i] /= T;
            }
            return A_koef;
        }

        // Рассчет коэффициента B
        private double[] Bi(double[,] Points, double T, bool many)
        {
            int size = 2;
            int len = Points.Length / 2;
            if (many) size = len / 8;
            double[] B_koef = new double[2];
            double dx = T / (Points.Length / 2);

            // B1 B2
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    B_koef[i] += Points[1, j] * dx
                        * Math.Sin(2 * Math.PI * Points[0, j] * i + 1 / T);

                    //B_koef[i] += (Points[1, j - 1] + Points[1, j]) / 2 * dx * Math.Sin(2 * Math.PI * Points[0, j-1] * i / T);
                }
                B_koef[i] /= T;
            }
            return B_koef;
        }

        #endregion

        #region Рассчет коэффициента детерминации
        // Рассчет дисперсии
        private double[] Disp(double[,] Source, double[,] Calculated)
        {
            double[] Disper = new double[Calculated.Length/2];

            for(int i = 0; i < Calculated.Length/2-2; i++)
            {
                Disper[i] = Math.Pow(Source[1, i + 2]
                    - Calculated[1, i], 2);
            }

            return Disper;
        }

        // Рассчет стандартного отклонения
        private double[] MidSqrtOtkl(double[,] Source, int num = -1)
        {
            if (num == -1)
            {
                num = Source.Length / 2;
            }

            double[] StOt = new double[num];

            for (int i = 1; i < num; i++)
            {
                StOt[i] = Math.Pow(Source[1, i] - Middle(Source, num),2);
            }

            return StOt;
        }

        // Рассчет среднего значения
        private double Middle(double[,] Source, int num = -1)
        {
            double Mid = 0;

            if (num == -1) num = Source.Length / 2;

            int Len = num;

            for (int i = 0; i < num; i++)
            {
                Mid += Source[1, i];
            }
            Mid /= (Len);

            return Mid;
        }

        // Рассчет детерминации
        private double Determine(double[] StOtkl, double[] Disp, int j = -1)
        {
            double Det = -1;

            double StOtSum = 0;
            double DispSum = 0;
            
            int length = Disp.Length;

            if (j != -1) length = j;

            for (int i = 0; i < StOtkl.Length; i++)
            {
                StOtSum += StOtkl[i];
            }

            for (int i = 0; i < length; i++)
            {
                DispSum += Disp[i];
            }

            Det = 1 - DispSum / StOtSum;

            return Det;
        }

        // Рассчет факториала
        private int Factorial(int numb)
        {
            int res = 1;
            for (int i = 1; i <= numb; i++)
            {
                res *= i;
            }

            return res;
        }

        #endregion

        #region Рисование графика
        //Рисует график
        private void DrawGraph(double[,] Source, string nameAxe, Color color)
        {
            PointPairList list = new PointPairList();

            for (int i = 0; i < Source.Length / 2; i++)
            {
                list.Add(Source[0, i], Source[1, i]);
            }

            LineItem myCurve = pane.AddCurve(nameAxe, list, color, SymbolType.None);

            zedGraph.AxisChange();

            zedGraph.Invalidate();
        }

        // Очистка графика
        private void Button1_Click(object sender, EventArgs e)
        {
            pane = zedGraph.GraphPane;

            pane.CurveList.Clear();
        }

        private void ZedGraph_Load(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
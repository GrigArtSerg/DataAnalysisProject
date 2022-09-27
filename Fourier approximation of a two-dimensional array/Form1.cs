using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace TIPIS_Lab_8_9
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Аппроксимация двумерного массива данных
        /// с помощью разложения в ряд Фурье первого порядка
        /// </summary>
        double startX;
        double startY;
        double Lx = Math.PI;
        double Ly = Math.PI;
        const double disc = 0.1;

        public Form1()
        {
            InitializeComponent();
        }

        #region Кнопки
        private void Start_Click(object sender, EventArgs e)
        {
            
            startX = 0;
            startY = 0;
            
            int lenX = (int)lenForX.Value;
            int lenY = (int)lenForY.Value;
            
            Random r = new Random();

            /// Моделирование начальных данных 
            ///  массив double[] Xs - значения X
            ///  массив double[] Ys - значения Y
            ///  массив double[,] Zs - значения Z
            #region DataCreation | Синтез исходных данных
            // Create Data for X
            double[] Xs = new double[lenX];
            for (int i = 0; i < lenX; i++)
            {
                Xs[i] = startX;
                startX += disc;
            }
            
            // Create Data for Y
            double[] Ys = new double[lenY];
            for (int i = 0; i < lenY; i++)
            {
                Ys[i] = startY;
                startY += disc;
            }
            
            // Create Data for Zs
            double[,] Zs = new double[lenX, lenY];
            for (int i = 0; i < lenX; i++)
            {
                for (int j = 0; j < lenY; j++)
                {
                    Zs[i, j] = Math.Sin(Xs[i]) + Math.Cos(Ys[j]);
                }
            }
            #endregion

            // Рассчет коэффициентов
            double[,] A_ij = Aij(Xs, Ys, Zs, lab9.Checked);    
            double[,] B_ij = Bij(Xs, Ys, Zs, lab9.Checked);
            double[,] C_ij = Cij(Xs, Ys, Zs, lab9.Checked);
            double[,] D_ij = Dij(Xs, Ys, Zs, lab9.Checked);

            /// Рассчет значений
            double[,] ZSR = Calculating(Xs, Ys, Zs, A_ij, B_ij, C_ij, D_ij);

            Output(Xs, Ys, Zs);

            Output(Xs, Ys, ZSR, true);
        }
        #endregion

        #region Вывод значений
        private void Output(double[] Xs, double[] Ys, double[,] Mas, bool Ans = false)
        {
            int len = (int)Math.Sqrt(Mas.Length);
            string data = "X Y Z";
            string path;
            if (Ans) path = @"F:\TIPIS_Lab\Ans\graph.csv";
            else path = @"F:\TIPIS_Lab\graph.csv";
            

            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(data);
                for (int i = 0; i < len; i++)
                    for (int j = 0; j < len; j++)
                    {
                        data = Xs[i].ToString() + ' ' + Ys[j].ToString() + ' ' + Mas[i, j].ToString();
                        sw.WriteLine(data);
                    }
                        
            }

            #region Запуск R'а
            string rPath = @"C:\Program Files\R\R-3.6.1\bin\Rscript.exe";
            string ScriptPath;
            if (Ans) ScriptPath = @"G:\Artem\TIPIS_Lab\Ans\TIPIS_8_Output.R";
            else ScriptPath = @"G:\Artem\TIPIS_Lab\TIPIS_8_Output.R";

            var info = new ProcessStartInfo
            {
                FileName = rPath,
                WorkingDirectory = Path.GetDirectoryName(ScriptPath),
                Arguments = ScriptPath,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                UseShellExecute = false
            };

            using (Process proc = new Process { StartInfo = info })
            {
                proc.Start();
            }
            #endregion
        }
        #endregion

        #region Рассчет значений Фурье
        /// <summary>
        /// Рассчет значений разложением в ряд Фурье
        /// </summary>
        /// <param name="Xs">Массив со значениями X</param>
        /// <param name="Ys">Массив со значениями Y</param>
        /// <param name="Zs">Двумерный массив с исходными значениями Z</param>
        /// <param name="c">Константа</param>
        /// <param name="A_ij">Коэффициенты A00-A11</param>
        /// <param name="B_ij">Коэффициенты B00-B11</param>
        /// <param name="C_ij">Коэффициенты C00-C11</param>
        /// <param name="D_ij">Коэффициенты D00-D11</param>
        /// <returns>Двумерный массив рассчетных значений</returns>
        private double[,] Calculating(double[] Xs, double[] Ys, double[,] Zs,
            double[,] A_ij, double[,] B_ij, double[,] C_ij, double[,] D_ij)
        {
            int len = (int)Math.Sqrt(Zs.Length);
            int count = (int)Math.Sqrt(A_ij.Length);
            double[,] R = new double[len, len];

            for (int i = 0; i < len; i++)
                for (int j = 0; j < len; j++)
                    for (int k = 0; k < count; k++)
                        for (int l = 0; l < count; l++)
                            R[i, j] +=
                                A_ij[k, l]
                                * Math.Cos(2 * Math.PI * k * Xs[i] / Lx)
                                * Math.Cos(2 * Math.PI * l * Ys[j] / Ly)
                                + B_ij[k, l]
                                * Math.Cos(2 * Math.PI * k * Xs[i] / Lx)
                                * Math.Sin(2 * Math.PI * l * Ys[j] / Ly)
                                + C_ij[k, l]
                                * Math.Sin(2 * Math.PI * k * Xs[i] / Lx)
                                * Math.Cos(2 * Math.PI * l * Ys[j] / Ly)
                                + D_ij[k, l]
                                * Math.Sin(2 * Math.PI * k * Xs[i] / Lx)
                                * Math.Sin(2 * Math.PI * l * Ys[j] / Ly);

            return R;
        }
        #endregion

        #region Рассчет коэффициентов для разложения
        // Рассчет коэффициентов Aij
        private double[,] Aij (double[] Xs, double[] Ys, double[,]Zs, bool many)
        {
            int size = 2;
            double len = Math.Sqrt(Zs.Length);
            if (many) size = (int)len / 8;
            double[,] A_ij = new double[size, size];
            int c = 0;

            // Метод объемов
            for (int i = 0; i < size; i++) 
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < len; k++)
                        for (int l = 0; l < len; l++)
                        {
                            if (i == 0 && j == 0) c = 1;
                            else if (i == 0 || j == 0) c = 2;
                            else c = 4;

                            A_ij[i, j] += Zs[k, l] * disc * disc
                                        * Math.Cos(2 * Math.PI * Xs[k] * i / Lx)
                                        * Math.Cos(2 * Math.PI * Ys[l] * j / Ly);
                        }

                    A_ij[i, j] = c * A_ij[i, j] / (Lx * Ly);
                }
            }

            return A_ij;
        }

        // Рассчет коэффициентов Bij
        private double[,] Bij(double[] Xs, double[] Ys, double[,] Zs, bool many)
        {
            int size = 2;
            double len = Math.Sqrt(Zs.Length);
            if (many) size = (int)len / 8;
            double[,] B_ij = new double[size, size];
            int c = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < len; k++)
                        for (int l = 0; l < len; l++)
                        {
                            if (i == 0 && j == 0) c = 1;
                            else if (i == 0 || j == 0) c = 2;
                            else c = 4;

                            B_ij[i, j] += Zs[k, l] * Math.Pow(disc, 2)
                                         * Math.Cos(2 * Math.PI * Xs[k] * i / Lx)
                                         * Math.Sin(2 * Math.PI * Ys[l] * j / Ly);
                        }

                    B_ij[i, j] = c * B_ij[i, j] / (Lx * Ly);
                }
            }
            
            return B_ij;
        }

        // Рассчет коэффициентов Cij
        private double[,] Cij(double[] Xs, double[] Ys, double[,] Zs, bool many)
        {
            int size = 2;
            double len = Math.Sqrt(Zs.Length);
            if (many) size = (int)len / 8;
            double[,] C_ij = new double[size, size];
            int c = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < len; k++)
                        for (int l = 0; l < len; l++)
                        {
                            if (i == 0 && j == 0) c = 1;
                            else if (i == 0 || j == 0) c = 2;
                            else c = 4;

                            C_ij[i, j] += Zs[k, l] * Math.Pow(disc, 2)
                                         * Math.Sin(2 * Math.PI * Xs[k] * i / Lx)
                                         * Math.Cos(2 * Math.PI * Ys[l] * j / Ly);
                        }

                    C_ij[i, j] = c * C_ij[i, j] / (Lx * Ly);
                }
            }

            return C_ij;
        }

        // Рассчет коэффициентов Dij
        private double[,] Dij(double[] Xs, double[] Ys, double[,] Zs, bool many)
        {
            int size = 2;
            double len = Math.Sqrt(Zs.Length);
            if (many) size = (int)len / 8;
            double[,] D_ij = new double[size, size];
            int c = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < len; k++)
                        for (int l = 0; l < len; l++)
                        {
                            if (i == 0 && j == 0) c = 1;
                            else if (i == 0 || j == 0) c = 2;
                            else c = 4;

                            D_ij[i, j] += Zs[k, l] * Math.Pow(disc, 2)
                                         * Math.Sin(2 * Math.PI * Xs[k] * i / Lx)
                                         * Math.Sin(2 * Math.PI * Ys[l] * j / Ly);
                        }

                    D_ij[i, j] = c * D_ij[i, j] / (Lx * Ly);
                }
            }
            
            return D_ij;
        }
        #endregion
    }
}

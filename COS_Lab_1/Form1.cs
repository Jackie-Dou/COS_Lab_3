using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COS_Lab_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            signalChart.Series.Add("1");
            cbbxN.Items.Add("64");
            cbbxN.Items.Add("128");
            cbbxN.Items.Add("256");
            cbbxN.Items.Add("512");
            cbbxN.Items.Add("1024");
            cbbxN.Items.Add("2048");
            signalChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            signalChart.Series[0].Color = Color.Red;
            signalChart.Series["1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            //signalChart.Series[0]["PixelPointWidth"] = "1";

        }

/*        private double[] GetHarmonic(int swing, int frequency, double phase, int N)
        {
            double[] results = new double[N];
            for (int n = 0; n < N; n++)
            {
                double value = swing * sinTeylor((2 * Math.PI * frequency * n) / N + phase);
                //double value = swing * Math.Sin((2 * Math.PI * frequency * n) / N + phase);
                results[n] = value;
            }
            return results;
        }*/

        private double[] GetPolyharmonic(string[] swings, string[] frequences, string[] phases, int N)
        {
            double[] results = new double[N];
            for (int n = 0; n < N; n++)
            {
                double value = Int32.Parse(swings[0]) * sinTeylor((2 * Math.PI * Int32.Parse(frequences[0]) * n) / N + Double.Parse(phases[0]));
                value += Int32.Parse(swings[1]) * sinTeylor((2 * Math.PI * Int32.Parse(frequences[1]) * n) / N + Double.Parse(phases[1]));
                value += Int32.Parse(swings[2]) * sinTeylor((2 * Math.PI * Int32.Parse(frequences[2]) * n) / N + Double.Parse(phases[2]));
                results[n] = value;
            }
            return results;
        }


        private void ShowChart(double[] ordinates, int N)
        {
            for (int n = 0; n < N; n++)
            {
                signalChart.Series[0].Points.AddXY(n, ordinates[n]);
                signalChart.Series["1"].Points.AddXY(n, ordinates[n]);
            }
            return;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            signalChart.Series[0].Points.Clear();
            signalChart.Series["1"].Points.Clear();

            int N = 0;
            string[] swings = { }, frequences = { }, phases = { };

            try
            {
                    string swingsText = txtSwing.Text;
                    swings = swingsText.Split(' ');
                    string frequencesText = txtFrequency.Text;
                    frequences = frequencesText.Split(' ');
                    string phasesText = txtPhase.Text;
                    phases = phasesText.Split(' ');
                    N = Int32.Parse(cbbxN.Text);

                    if (swings.Count() != 3 || frequences.Count() != 3 || phases.Count() != 3)
                    {
                        throw new Exception("Не весь ввод");
                    }

                    if (
                        Int32.Parse(frequences[0]) < 1 ||
                        Int32.Parse(frequences[1]) < 1 ||
                        Int32.Parse(frequences[2]) < 1 ||
                        N <= 2 * Int32.Parse(frequences[0]) ||
                        N <= 2 * Int32.Parse(frequences[1]) ||
                        N <= 2 * Int32.Parse(frequences[2]) 
                        )
                    {
                        throw new Exception("Логические ограничения");
                    }              
            } catch
            {
                MessageBox.Show(
                    "Некорректный ввод",
                    "Сообщение");
                return;
            }

            double[] ordinates = new double[N];


            ordinates = GetPolyharmonic(swings, frequences, phases, N);


            ShowChart(ordinates, N);

            int M = N / 2;
            double[] amplOrdinates = new double[M + 1];
            double[] phaseOrdinates = new double[M + 1];
            amplOrdinates = GetAmplitude(ordinates, N, M);
            phaseOrdinates = GetPhase(ordinates, N, M);
            return;
        }

        private double sinTeylor(double x, double eps = 0.0001)
        {
            double taylor = 0;
            int tempFact = 1;
            double piNum = Math.Floor(x / (2 * Math.PI));
            double newX = x - (2 * piNum * Math.PI);
            double tempX = newX;
            while (Math.Abs(tempX)>eps)
            {
                taylor += tempX;
                double del = (-1) * (tempFact + 1) * (tempFact + 2);
                tempX = tempX * Math.Pow(newX, 2)/del;
                tempFact += 2;
            }
            return taylor;
        }

        private bool IsModZero(int[] arr, int num)
        {
            bool f = true;
            int i = 0;
            while(f && i < arr.Count())
            {
                f = f && ((arr[i] % num) == 0);
                i++;
            }
            return f;
        }

        private double[] GetAmplitude(double[] sequence, int N, int M)
        {
            double[] results = new double[M+1];
            for (int R = 0; R <= M; R++)
            {
                results[R] = Math.Sqrt(Math.Pow(GetCoefA(sequence, N, R), 2) + Math.Pow(GetCoefB(sequence, N, R), 2));
            }
            return results;
        }

        private double[] GetPhase(double[] sequence, int N, int M)
        {
            double[] results = new double[M + 1];
            for (int R = 0; R <= M; R++)
            {
                results[R] = -1*Math.Atan(GetCoefB(sequence, N, R) / GetCoefA(sequence, N, R));
            }
            return results;
        }

        private double GetCoefA(double[] x, int N, int R)
        {
            double sum = 0;
            for(int n = 0; n < N; n++)
            {
                sum += x[n] * Math.Cos(2 * Math.PI * n * R / N);
            }
            return sum * 2 / N;
        }

        private double GetCoefB(double[] x, int N, int R)
        {
            double sum = 0;
            for (int n = 0; n < N; n++)
            {
                sum += x[n] * sinTeylor(2 * Math.PI * n * R / N);
            }
            return sum * 2 / N;
        }

        // настройки ограничений ввода
        private void txtSwing_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtFrequency_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtPhase_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != '-' && number != ',' && number != ' ')
            {
                e.Handled = true;
            }
        }
    }
}

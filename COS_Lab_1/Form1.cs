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
            cbbxN.Items.Add("64");
            cbbxN.Items.Add("128");
            cbbxN.Items.Add("256");
            cbbxN.Items.Add("512");
            cbbxN.Items.Add("1024");
            cbbxN.Items.Add("2048");

            cbbxSignal.Items.Add("Гармонический");
            cbbxSignal.Items.Add("Полигармонический");
            cbbxSignal.Items.Add("Прямоугольный");
            cbbxSignal.Items.Add("Треугольный");
            cbbxSignal.Items.Add("Пилообразный");

            signalChart.Series.Add("1");
            restoreSignalChart.Series.Add("1");

            signalChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            signalChart.Series[0].Color = Color.Red;
            signalChart.Series["1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

            restoreSignalChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            restoreSignalChart.Series[0].Color = Color.Green;
            restoreSignalChart.Series["1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            restoreSignalChart.Series["1"].Color = Color.Yellow;
            //signalChart.Series[0]["PixelPointWidth"] = "1";

        }

        private double[] GetHarmonic(int swing, int frequency, double phase, int N)
        {
            double[] results = new double[N];
            for (int n = 0; n < N; n++)
            {
                //double value = swing * sinTeylor((2 * Math.PI * frequency * n) / N + phase % (2 * Math.PI));
                double value = swing * Math.Cos((2 * Math.PI * frequency * n) / N + phase % (2 * Math.PI));
                results[n] = value;
            }
            return results;
        }

        private double[] GetPolyharmonic(string[] swings, string[] frequences, string[] phases, int N)
        {
            double[] results = new double[N];
            for (int n = 0; n < N; n++)
            {
                double value = 0;
                for (int i = 0; i < swings.Count(); i++)
                {
                    value += Int32.Parse(swings[i]) * Math.Cos((2 * Math.PI * Int32.Parse(frequences[i]) * n) / N + Double.Parse(phases[i]));
                }
/*                double value = Int32.Parse(swings[0]) * Math.Sin((2 * Math.PI * Int32.Parse(frequences[0]) * n) / N + Double.Parse(phases[0]));
                value += Int32.Parse(swings[1]) * Math.Sin((2 * Math.PI * Int32.Parse(frequences[1]) * n) / N + Double.Parse(phases[1]));
                value += Int32.Parse(swings[2]) * Math.Sin((2 * Math.PI * Int32.Parse(frequences[2]) * n) / N + Double.Parse(phases[2]));
                value += Int32.Parse(swings[3]) * Math.Sin((2 * Math.PI * Int32.Parse(frequences[3]) * n) / N + Double.Parse(phases[3]));
                value += Int32.Parse(swings[4]) * Math.Sin((2 * Math.PI * Int32.Parse(frequences[4]) * n) / N + Double.Parse(phases[4]));*/
                results[n] = value;
            }
            return results;
        }

        private double[] GetRectangular(int swing, int frequency, double phase, int N)
        {
            double[] results = new double[N];
            for (int n = 0; n < N; n++)
            {
                double value = swing * CountRectangular((2 * Math.PI * frequency * n) / N + phase);
                results[n] = value;
            }
            return results;
        }

        private double CountRectangular(double x)
        {
            //if (sinTeylor(x) < 0)
            if (Math.Cos(x) < 0)
                return -1;
            else
                return 1;
        }

        private double[] GetTriangular(int swing, int frequency, double phase, int N)
        {
            double[] results = new double[N];
            int count = N / frequency;
            double phaseCount = (phase + Math.PI / 2) * N / (4 * Math.PI);
            for (int n = 0; n < N; n++)
            {
                double value = 2 * swing * CountTriangular((n + phaseCount) % count, count) - swing;
                results[n] = value;
            }
            return results;
        }
        private double CountTriangular(double n, double maxN)
        {
            if (n < maxN / 2)
                return n * 2 / maxN;
            else
                return 2 - (2 * n / maxN);
        }

        private double[] GetSawtooth(int swing, int frequency, double phase, int N)
        {
            double[] results = new double[N];
            for (int n = 0; n < N; n++)
            {
                double value = 2 * swing * CountSawtoon(2 * Math.PI * frequency * ((n + ((phase + Math.PI) * N / (4 * Math.PI))) % (N / frequency)) / N) / (13.2873 / 2) - swing;
                results[n] = value;
            }
            return results;
        }

        private double CountSawtoon(double x, double eps = 0.001)
        {
            int i = 1;
            //double temp = sinTeylor(i) * x / i;
            double temp = Math.Cos(i) * x / i;
            double sum = 0;
            while (Math.Abs(temp) > eps)
            {
                sum += temp;
                i++;
                //temp = sinTeylor(i) * x / i;
                temp = Math.Cos(i) * x / i;
            }
            return sum;
        }

        private void ShowCharts(double[] ordinates, double[] restoreOrdinates, int N)
        {
            for (int n = 0; n < N; n++)
            {
                signalChart.Series[0].Points.AddXY(n, ordinates[n]);
                signalChart.Series["1"].Points.AddXY(n, ordinates[n]);

                restoreSignalChart.Series[0].Points.AddXY(n, restoreOrdinates[n]);
                restoreSignalChart.Series["1"].Points.AddXY(n, restoreOrdinates[n]);
            }
            return;
        }

        private void ShowSpectres(double[] amplOrdinates, double[]  phaseOrdinates, int M)
        {
            for (int n = 0; n < M; n++)
            {
                chartSwing.Series[0].Points.AddXY(n, amplOrdinates[n]);
                chartPhase.Series[0].Points.AddXY(n, phaseOrdinates[n]);
                
            }
            return;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            signalChart.Series[0].Points.Clear();
            signalChart.Series["1"].Points.Clear();
            restoreSignalChart.Series[0].Points.Clear();
            restoreSignalChart.Series["1"].Points.Clear();
            chartSwing.Series[0].Points.Clear();
            chartPhase.Series[0].Points.Clear();

            int N = 0;
            string[] swings = { }, frequences = { }, phases = { };
            string type;
            int swing = 0, frequency = 0;
            double phase = 0;

            string msg = "Ошибка ввода";
            try
            {
                type = cbbxSignal.Text;
                if (type != "Полигармонический")
                {
                    swing = Int32.Parse(txtSwing.Text);
                    frequency = Int32.Parse(txtFrequency.Text);
                    phase = Double.Parse(txtPhase.Text);
                    N = Int32.Parse(cbbxN.Text);

                    if (frequency < 1 || N <= 2 * frequency)
                    {
                        msg = "Логические ограничения!";
                        throw new Exception("Логические ограничения");
                    }
                }
                else
                {
                    string swingsText = txtSwing.Text;
                    swings = swingsText.Split(' ');
                    string frequencesText = txtFrequency.Text;
                    frequences = frequencesText.Split(' ');
                    string phasesText = txtPhase.Text;
                    phases = phasesText.Split(' ');
                    N = Int32.Parse(cbbxN.Text);

                    if (swings.Count()!=frequences.Count() || frequences.Count() != phases.Count() || phases.Count() != swings.Count())
                    {
                        msg = "Не весь ввод!";
                        throw new Exception("Не весь ввод");
                    }

                    if (!IsAccessibleFrequencesLogic(frequences, N))
                    {
                        msg = "Логические ограничения!";
                        throw new Exception("Логические ограничения");
                    }

                }
            } catch
            {
                MessageBox.Show(
                    msg,
                    "Сообщение");
                return;
            }

            double[] ordinates = new double[N];

            ordinates = GetHarmonic(swing, frequency, phase, N);
            switch (type)
            {
                case "Полигармонический":
                    ordinates = GetPolyharmonic(swings, frequences, phases, N);
                    break;
                case "Гармонический":
                    ordinates = GetHarmonic(swing, frequency, phase, N);
                    break;
                case "Прямоугольный":
                    ordinates = GetRectangular(swing, frequency, phase, N);
                    break;
                case "Треугольный":
                    ordinates = GetTriangular(swing, frequency, phase, N);
                    break;
                case "Пилообразный":
                    ordinates = GetSawtooth(swing, frequency, phase, N);
                    break;
            }

            int M = N / 2;
            double[] amplOrdinates = new double[M];
            double[] phaseOrdinates = new double[M];
            amplOrdinates = GetAmplitude(ordinates, N, M);
            phaseOrdinates = GetPhase(ordinates, N, M);

            double[] ordinatesRestore = new double[N];
            ordinatesRestore = RestoreSequence(amplOrdinates, phaseOrdinates, N, M);

            ShowSpectres(amplOrdinates, phaseOrdinates, M);
            ShowCharts(ordinates, ordinatesRestore, N);
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

        private double[] GetAmplitude(double[] sequence, int N, int M)
        {
            double[] results = new double[M];
            for (int R = 0; R < M; R++)
            {
                results[R] = Math.Sqrt(Math.Pow(GetCoefA(sequence, N, R), 2) + Math.Pow(GetCoefB(sequence, N, R), 2));
            }
            return results;
        }

        private double[] GetPhase(double[] sequence, int N, int M)
        {
            double[] results = new double[M];
            for (int R = 0; R < M; R++)
            {
                results[R] = Math.Atan(GetCoefB(sequence, N, R) / GetCoefA(sequence, N, R));
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
                sum += x[n] * Math.Sin(2 * Math.PI * n * R / N);
            }
            return sum * 2 / N;
        }
        private double[] RestoreSequence(double[] amplitude, double[] phase, int N, int M)
        {
            double[] results = new double[N];
            for (int n = 0; n < N; n++)
            {
                results[n] = GetRestoredOrdinate(amplitude, phase, n, N, M);
            }
            return results;
        }

        private double GetRestoredOrdinate(double[] amplitude, double[] phase, int n, int N, int M)
        {
            double sum = 0;
            for (int R = 0; R < M; R++)
            {
                //sum += amplitude[R] * Math.Sin(2 * Math.PI * R * n / N + phase[R]);
                sum += amplitude[R] * Math.Cos(2 * Math.PI * R * n / N - phase[R]);
                //sum += amplitude[R] * Math.Sin(2 * Math.PI * R * n / N - phase[R]);
            }
            return sum;
        }

        // настройки ограничений ввода
        private bool IsAccessibleFrequencesLogic(string[] freq, int N)
        {
            bool flag = true;
            int i = 0;
            while(flag && i < freq.Count())
            {
                flag &= (Int32.Parse(freq[i]) > 1);
                flag &= (N > 2 * Int32.Parse(freq[i]));
                i++;
            }
            return flag;
        }

        private void txtEnter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V) ||
                e.KeyData == (Keys.Control | Keys.C) ||
                e.KeyData == (Keys.Control | Keys.A) ||
                (char.IsDigit((char)e.KeyCode)) ||
                (e.KeyCode == Keys.Back) || 
                (e.KeyCode == Keys.Space))
            {
                e.SuppressKeyPress = false;
            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}

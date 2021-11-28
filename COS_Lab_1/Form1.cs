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

            cbbxFilter.Items.Add("Нижних частот");
            cbbxFilter.Items.Add("Верхних частот");
            cbbxFilter.Items.Add("Полосовой");

            signalChart.Series.Add("1");
            restoreSignalChart.Series.Add("1");

            signalChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            signalChart.Series[0].Color = Color.Red;
            signalChart.Series["1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            //signalChart.Series[0]["PixelPointWidth"] = "1";

            restoreSignalChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            restoreSignalChart.Series[0].Color = Color.Green;
            restoreSignalChart.Series["1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            restoreSignalChart.Series["1"].Color = Color.Yellow;
        }

        private double[] GetHarmonic(int swing, int frequency, double phase, int N)
        {
            double[] results = new double[N];
            for (int n = 0; n < N; n++)
            {
                double value = swing * Math.Sin((2 * Math.PI * frequency * n) / N + phase % (2 * Math.PI));
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
                    value += Int32.Parse(swings[i]) * Math.Sin((2 * Math.PI * Int32.Parse(frequences[i]) * n) / N + Double.Parse(phases[i]));
                }
                results[n] = value;
            }
            return results;
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

        private void ShowSpectres(double[] amplOrdinates, double[] phaseOrdinates, int M)
        {
            for (int n = 0; n < M; n++)
            {
                chartSwing.Series[0].Points.AddXY(n, amplOrdinates[n]);
                chartPhase.Series[0].Points.AddXY(n, phaseOrdinates[n]);

            }
            return;
        }

        private bool IsRecoverable(double n, string[] limit, string filter)
        {
            switch (filter)
            {
                case "Нижних частот":
                    if (n <= Int32.Parse(limit[0])) return true;
                    else return false;
                case "Верхних частот":
                    if (n >= Int32.Parse(limit[0])) return true;
                    else return false;
                case "Полосовой":
                    int a = Int32.Parse(limit[0]);
                    int b = Int32.Parse(limit[1]);
                    if (b<a)
                    {
                        a = a + b;
                        b = a - b;//a+b-b =a
                        a = a - b;//a+b-//a = b
                    }
                    if (n >= a && n<=b) return true;
                    else return false;
                default:
                    return false;
            }
        }
        private double[] LimitLowOrdinates(double[] ordinates, int limit)
        {
            double[] lOrdinates = new double[ordinates.Count()];
            for (int n = 0; n < ordinates.Count(); n++)
            {
                if (((ordinates[n] > 0) && (ordinates[n] <= limit)) || ((ordinates[n] < 0) && (ordinates[n] >= -limit)))
                {
                    lOrdinates[n] = 0;
                }
                else
                {
                    lOrdinates[n] = ordinates[n];
                }
            }

            return lOrdinates;
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
            string type, filter;
            int swing = 0, frequency = 0;
            string[] limit = { };
            double phase = 0;

            string msg = "Ошибка ввода";
            try
            {
                string limitText = txtbxLimit.Text;
                limit = limitText.Split(' ');

                type = cbbxSignal.Text;
                filter = cbbxFilter.Text;
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
            }
            int M = N/2;
            double[] amplOrdinates = new double[M];
            double[] newAmplOrdinates = new double[M];
            double[] phaseOrdinates = new double[M];
            amplOrdinates = GetAmplitude(ordinates, N, M);
            phaseOrdinates = GetPhase(ordinates, N, M);

            double[] ordinatesRestore = new double[N];
            ordinatesRestore = RestoreSequence(amplOrdinates, phaseOrdinates, N, M, limit, filter);
            newAmplOrdinates = GetAmplitude(ordinatesRestore, N, M);


            ShowSpectres(amplOrdinates, newAmplOrdinates, M);

           /* switch (filter)
            {
                case "Нижних частот":
                    //ordinates = LimitLowOrdinates(ordinates, limit);
                    break;
                case "Верхних частот":
                    //ordinates = LimitHighOrdinates(ordinates, limit);
                    break;
                case "Полосовой":
                    //ordinates = LimitZoneOrdinates(ordinates, limit);
                    break;
            }*/

            ShowCharts(ordinates, ordinatesRestore, N);
            return;
        }

        // для спектров
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
            for (int n = 0; n < N; n++)
            {
                sum += x[n] * Math.Cos(2.0 * Math.PI * n * R / N);
            }
            return sum * 2.0 / N;
        }

        private double GetCoefB(double[] x, int N, int R)
        {
            double sum = 0;
            for (int n = 0; n < N; n++)
            {
                sum += x[n] * Math.Sin(2.0 * Math.PI * n * R / N);
            }
            return sum * 2.0 / N;
        }
        private double[] RestoreSequence(double[] amplitude, double[] phase, int N, int M, string[] limit, string filter)
        {
            double[] results = new double[N];
            for (int n = 0; n < N; n++)
            {
                results[n] = GetRestoredOrdinate(amplitude, phase, n, N, M, limit, filter);
            }
            return results;
        }

        private double GetRestoredOrdinate(double[] amplitude, double[] phase, int n, int N, int M, string[] limit, string filter)
        {
            double sum = 0;
            for (int R = 0; R < M; R++)
            {
                if(IsRecoverable(R, limit, filter))
                {
                    //sum += amplitude[R] * Math.Sin(2 * Math.PI * R * n / N + phase[R]);
                    sum += amplitude[R] * Math.Cos(2.0 * Math.PI * R * n / N - phase[R]);
                    //sum += amplitude[R] * Math.Sin(2 * Math.PI * R * n / N - phase[R]);
                }
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

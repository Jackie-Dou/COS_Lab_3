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
            signalChart.Series[0]["PixelPointWidth"] = "1";

        }

        private double[] GetHarmonic(int swing, int frequency, double phase, int N)
        {
            double[] results = new double[N];
            for (int n = 0; n < N; n++)
            {
                double value = swing * sinTeylor((2 * Math.PI * frequency * n) / N + phase%(2*Math.PI));
                results[n] = value;
            }
            return results;
        }

        private double[] GetPolyharmonic(string[] swings, string[] frequences, string[] phases, int N)
        {
            double[] results = new double[N];
            for (int n = 0; n < N; n++)
            {
                double value = Int32.Parse(swings[0]) * Math.Sin((2 * Math.PI * Int32.Parse(frequences[0]) * n) / N + Double.Parse(phases[0]));
                value += Int32.Parse(swings[1]) * Math.Sin((2 * Math.PI * Int32.Parse(frequences[1]) * n) / N + Double.Parse(phases[1]));
                value += Int32.Parse(swings[2]) * Math.Sin((2 * Math.PI * Int32.Parse(frequences[2]) * n) / N + Double.Parse(phases[2]));
                value += Int32.Parse(swings[3]) * Math.Sin((2 * Math.PI * Int32.Parse(frequences[3]) * n) / N + Double.Parse(phases[3]));
                results[n] = value;
            }
            return results;
        }

        private double?[] GetPolyharmonicTable(string[] swings, string[] frequences, string[] phases, int N)
        {
            int limitN = N / NOD(ParceArrToInt(frequences));
            double?[] results = new double?[limitN];
            for (int n = 0; n < N; n++)
            {
                int newN = n % limitN;
                if (results[newN] == null)
                {
                    double value = Int32.Parse(swings[0]) * Math.Sin((2 * Math.PI * Int32.Parse(frequences[0]) * newN) / N + Double.Parse(phases[0]));
                    value += Int32.Parse(swings[1]) * Math.Sin((2 * Math.PI * Int32.Parse(frequences[1]) * newN) / N + Double.Parse(phases[1]));
                    value += Int32.Parse(swings[2]) * Math.Sin((2 * Math.PI * Int32.Parse(frequences[2]) * newN) / N + Double.Parse(phases[2]));
                    value += Int32.Parse(swings[3]) * Math.Sin((2 * Math.PI * Int32.Parse(frequences[3]) * newN) / N + Double.Parse(phases[3]));
                    results[newN] = value;
                }
            }
            return results;
        }

        private int[] ParceArrToInt(string[] arr)
        {
            int[] result = new int[arr.Count()];
            for(int i=0; i<arr.Count(); i++)
            {
                result[i] = Int32.Parse(arr[i]);
            }
            return result;
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
            if (sinTeylor(x)<0)
                return -1;
            else
                return 1;
        }

        private double[] GetTriangular(int swing, int frequency, double phase, int N)
        {
            double[] results = new double[N];   
            int count = N / frequency;
            double phaseCount = (phase + Math.PI/2) * N / (4 * Math.PI);
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
                return 2 - (2*n / maxN);
        }

        private double[] GetSawtooth(int swing, int frequency, double phase, int N)
        {
            double[] results = new double[N];
            for (int n = 0; n < N; n++)
            {
                double value = 2*swing * CountSawtoon(2 * Math.PI * frequency * ((n + ((phase + Math.PI) * N / (4 * Math.PI) )) % (N/frequency)) / N)/(13.2873/2) - swing;
                results[n] = value;
            }
            return results;
        }

        private double CountSawtoon(double x, double eps = 0.001)
        {
            int i = 1;
            double temp = sinTeylor(i)*x/i;
            double sum = 0;
            while (Math.Abs(temp) > eps)
            {
                sum += temp;
                i++;
                temp = sinTeylor(i)*x / i;
            }
            return sum;
        }


        private void ShowChart(double[] ordinates, int N)
        {
            for (int n = 0; n < N; n++)
            {
                signalChart.Series[0].Points.AddXY(n, ordinates[n]);
            }
            return;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            signalChart.Series[0].Points.Clear();

            int swing = 0, frequency = 0, N = 0;
            string[] swings = { }, frequences = { }, phases = { };
            double phase = 0;
            string type;

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

                    if (swings.Count() != 4 || frequences.Count() != 4 || phases.Count() != 4)
                    {
                        throw new Exception("Не весь ввод");
                    }

                    if (
                        Int32.Parse(frequences[0]) < 1 ||
                        Int32.Parse(frequences[1]) < 1 ||
                        Int32.Parse(frequences[2]) < 1 ||
                        Int32.Parse(frequences[3]) < 1 ||
                        N <= 2 * Int32.Parse(frequences[0]) ||
                        N <= 2 * Int32.Parse(frequences[1]) ||
                        N <= 2 * Int32.Parse(frequences[2]) ||
                        N <= 2 * Int32.Parse(frequences[3])
                        )
                    {
                        throw new Exception("Логические ограничения");
                    }
                }
            } catch
            {
                MessageBox.Show(
                    "Некорректный ввод",
                    "Сообщение");
                return;
            }

            double[] ordinates = new double[N];

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

            ShowChart(ordinates, N);
            return;
        }

        private double sinTeylor(double x)
        {
            double taylor = 0;
            int tempFact = 1;
            double piNum = Math.Floor(x / (2 * Math.PI));
            double newX = x - (2 * piNum * Math.PI);
            double tempX = newX;
            while ((tempFact+1)/2<=4)
            {
                taylor += tempX;
                tempX = tempX * Math.Pow(newX, 2) * (-1);
                tempFact += 2;
            }
            return taylor;
        }

        private int NOD(int[] arr)
        {
            int x = Math.Min(arr[0], arr[1]);
            for (int i=2; i<arr.Count(); i++)
            {
                x = Math.Min(arr[i], x);
            }
            int Nod = x;
            for (; Nod > 1; Nod--)
            {
                if (IsModZero(arr,Nod))
                    break;
            }
            return Nod;
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

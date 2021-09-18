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
                double value = swing * sinTeylor((2 * Math.PI * frequency * n) / N + phase);
                results[n] = value;
            }
            return results;
        }

        private double[] GetPolyharmonic(string[] swings, string[] frequences, string[] phases, int N)
        {
            double[] results = new double[N];
            for (int n = 0; n < N; n++)
            {
                double value = Int32.Parse(swings[0]) * sinTeylor((2 * Math.PI * Int32.Parse(frequences[0]) * n) / N + Double.Parse(phases[0]));
                value += Int32.Parse(swings[1]) * sinTeylor((2 * Math.PI * Int32.Parse(frequences[1]) * n) / N + Double.Parse(phases[1]));
                value += Int32.Parse(swings[2]) * sinTeylor((2 * Math.PI * Int32.Parse(frequences[2]) * n) / N + Double.Parse(phases[2]));
                value += Int32.Parse(swings[3]) * sinTeylor((2 * Math.PI * Int32.Parse(frequences[3]) * n) / N + Double.Parse(phases[3]));
                results[n] = value;
            }
            return results;
        }

        private double[] GetRectangular(int swing, int frequency, double phase, int N)
        {
            double[] results = new double[N];
            //
            return results;
        }

        private double[] GetTriangular(int swing, int frequency, double phase, int N)
        {
            double[] results = new double[N];
            //
            return results;
        }

        private double[] GetSawtooth(int swing, int frequency, double phase, int N)
        {
            double[] results = new double[N];
            //
            return results;
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
                } else
                {
                    string swingsText = txtSwing.Text;
                    swings = swingsText.Split(' ');
                    string frequencesText = txtFrequency.Text;
                    frequences = frequencesText.Split(' ');
                    string phasesText = txtPhase.Text;
                    phases = phasesText.Split(' ');
                }

                N = Int32.Parse(cbbxN.Text);

                // TODO добавить ограничения ввода, связанные с внутренней логикой - типа теоремы Котельникова

            } catch
            {
                labelError.Text = "Проверьте ввод";
                return;
            }
            labelError.Text = "";

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

        private double sinTeylor(double x, double eps = 0.001)
        {
            double taylor = 0;
            int tempFact = 1;
            double tempX = x;
            while (Math.Abs(tempX) > eps)
            {
                taylor += tempX;
                tempX = tempX * Math.Pow(x, 2) * (-1);
                tempFact += 2;
                tempX = tempX / (tempFact * (tempFact - 1));
            }
            return taylor;
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

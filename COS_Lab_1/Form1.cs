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
            signalChart.Series[0]["PixelPointWidth"] = "1";

        }

        private double[] GetChartResults(int swing, int frequency, int phase, int N)
        {
            double[] results = new double[N];
            for (int n = 0; n < N; n++)
            {
                // TODO переписать с синуса на ряды Тейлора - или что там Дементору надо
                double value = swing * Math.Sin((2 * Math.PI * frequency * n) / N + phase);
                results[n] = value;
            }
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
            // TODO где-то на форме будет менюшка выбора типа сигнала, выбирать путь исполнения
            signalChart.Series[0].Points.Clear();

            int swing, frequency, phase, N;
            try
            {
                swing = Int32.Parse(txtSwing.Text);
                frequency = Int32.Parse(txtFrequency.Text);
                phase = Int32.Parse(txtPhase.Text);
                N = Int32.Parse(cbbxN.Text);

                // TODO добавить ограничения ввода, связанные с внутренней логикой - типа теоремы Котельникова

            } catch
            {
                labelError.Text = "Введи нормально, угашенный ты об дерево";
                return;
            }
            labelError.Text = "Молодец, можешь, когда хочешь";

            double[] ordinates = new double[N];
            ordinates = GetChartResults(swing, frequency, phase, N);

            ShowChart(ordinates, N);
            return;
        }


        // настройки ограничений ввода
        private void txtSwing_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void txtFrequency_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void txtPhase_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != '-')
            {
                e.Handled = true;
            }
        }
    }
}

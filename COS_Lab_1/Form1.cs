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

        private void btnStart_Click(object sender, EventArgs e)
        {
            int swing = Int32.Parse(txtSwing.Text);
            int frequency = Int32.Parse(txtFrequency.Text);
            int phase = Int32.Parse(txtPhase.Text);
            int N = Int32.Parse(cbbxN.Text);

            // TO DO собрать в формулу
            // вывести на график
            // наслаждаться


        }
    }
}

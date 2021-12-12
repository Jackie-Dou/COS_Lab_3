using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COS_Lab_3_2
{
    public partial class Form1 : Form
    {
        Bitmap image;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Файлы изображений|*.bmp;*.png;*.jpg";
            if (openDialog.ShowDialog() != DialogResult.OK)
                return;

            image = new Bitmap(openDialog.FileName, true);

            btNoFilter.Checked = true;
            btBlurFilter.Checked = false;
            btEmbossingFilter.Checked = false;
            btSharpnessFilter.Checked = false;
            btEdgeDetectionFilter.Checked = false;

            try
            {
                picbxImage.Image = image; //вот это вывод битмапа
            }
            catch (OutOfMemoryException ex)
            {
                MessageBox.Show("Ошибка чтения картинки");
                return;
            } 
        }

        private void btApplyFilter_Click(object sender, EventArgs e)
        {
            Filter currentFilter = null;
            if (btNoFilter.Checked)
                currentFilter = null;
            else if (btBlurFilter.Checked)
                currentFilter = new BlurFilter();
            else if (btEmbossingFilter.Checked)
                currentFilter = new EmbossingFilter();
            else if (btSharpnessFilter.Checked)
                currentFilter = new SharpnessFilter();
            else if (btEdgeDetectionFilter.Checked)
                currentFilter = new EdgeDetectionFilter();

            if (currentFilter == null)
            {
                picbxImageRestore.Image = image;
            }
            else
            {
                picbxImageRestore.Image = Convolution.ApplyFilter(image, currentFilter);
            }
        }

        private void btNoFilter_CheckedChanged(object sender, EventArgs e)
        {
            btNoFilter.Checked = true;
            btBlurFilter.Checked = false;
            btEmbossingFilter.Checked = false;
            btSharpnessFilter.Checked = false;
            btEdgeDetectionFilter.Checked = false;
        }

        private void btBlurFilter_CheckedChanged(object sender, EventArgs e)
        {
            btNoFilter.Checked = false;
            btBlurFilter.Checked = true;
            btEmbossingFilter.Checked = false;
            btSharpnessFilter.Checked = false;
            btEdgeDetectionFilter.Checked = false;
        }

        private void btSharpnessFilter_CheckedChanged(object sender, EventArgs e)
        {
            btNoFilter.Checked = false;
            btBlurFilter.Checked = false;
            btEmbossingFilter.Checked = false;
            btSharpnessFilter.Checked = true;
            btEdgeDetectionFilter.Checked = false;
        }

        private void btEmbossingFilter_CheckedChanged(object sender, EventArgs e)
        {
            btNoFilter.Checked = false;
            btBlurFilter.Checked = false;
            btEmbossingFilter.Checked = true;
            btSharpnessFilter.Checked = false;
            btEdgeDetectionFilter.Checked = false;
        }

        private void btEdgeDetectionFilter_CheckedChanged(object sender, EventArgs e)
        {
            btNoFilter.Checked = false;
            btBlurFilter.Checked = false;
            btEmbossingFilter.Checked = false;
            btSharpnessFilter.Checked = false;
            btEdgeDetectionFilter.Checked = true;
        }
    }
}

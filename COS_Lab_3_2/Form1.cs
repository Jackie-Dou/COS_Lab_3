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

            cbbxFilters.Items.Add("Без фильтра");
            cbbxFilters.Items.Add("Размытие");
            cbbxFilters.Items.Add("Резкость");
            cbbxFilters.Items.Add("Трафарет");
            cbbxFilters.Items.Add("Границы");
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Файлы изображений|*.bmp;*.png;*.jpg";
            if (openDialog.ShowDialog() != DialogResult.OK)
                return;

            image = new Bitmap(openDialog.FileName, true);

            try
            {
                picbxImage.Image = image; //вот это вывод битмапа
            }
            catch (OutOfMemoryException ex)
            {
                MessageBox.Show("Ошибка чтения картинки");
                return;
            }

            cbbxFilters.Text = "Без фильтра";
        }

        private void btApplyFilter_Click(object sender, EventArgs e)
        {
            string filterText = cbbxFilters.Text;
            Filter currentFilter = null;

            switch (filterText)
            {
                case "Без фильтра":
                    currentFilter = null;
                    break;
                case "Размытие":
                    currentFilter = new BlurFilter();
                    break;
                case "Резкость":
                    currentFilter = new EmbossingFilter();
                    break;
                case "Трафарет":
                    currentFilter = new SharpnessFilter();
                    break;
                case "Границы":
                    currentFilter = new EdgeDetectionFilter();
                    break;
            }

            if (currentFilter == null)
            {
                picbxImageRestore.Image = image;
            }
            else
            {
                picbxImageRestore.Image = Convolution.ApplyFilter(image, currentFilter);
            }
        }
    }
}

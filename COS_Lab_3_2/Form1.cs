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
        Image image;
        Image imageRestored;

        public Form1()
        {
            InitializeComponent();
            btNoFilter.Checked = true;
            btBlurFilter.Checked = false;
            btEmbossingFilter.Checked = false;
            btSharpnessFilter.Checked = false;
            btEdgeDetectionFilter.Checked = false;
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            byte[] imgdata;
            List<byte> imgdataRestoreList = new List<byte>();
            List<Point> points = new List<Point>();

            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Файлы изображений|*.bmp;*.png;*.jpg";
            if (openDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                picbxImage.Image = Image.FromFile(openDialog.FileName);
                //считали байты
                imgdata = System.IO.File.ReadAllBytes(openDialog.FileName);
            }
            catch (OutOfMemoryException ex)
            {
                MessageBox.Show("Ошибка чтения картинки");
                return;
            }
            //превратили в список точек с цветами
            foreach (byte pointByte in imgdata)
            {
                Point newPoint = new Point();
                newPoint.bytesToColors(pointByte);
                points.Add(newPoint);
            }

            //собрали обратно в массив байт
            points.ForEach(delegate (Point point)
            {
                imgdataRestoreList.Add(point.colorsToByte());
            });
            byte[] imgdataRestore = imgdataRestoreList.ToArray();

            //и вывели на вторую панель
            using (var ms = new MemoryStream(imgdataRestore))
            {
                picbxImageRestore.Image = Image.FromStream(ms);
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

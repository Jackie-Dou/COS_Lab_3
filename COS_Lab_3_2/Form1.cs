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
    }
}

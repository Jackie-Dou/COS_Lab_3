using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COS_Lab_3_2
{
    public static class Convolution
    {
        public static Bitmap ApplyFilter(Bitmap sourceImage, Filter filter)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;

            Bitmap result = new Bitmap(width, height);

            int kernelHeight = filter.kernel.GetLength(1);//предполагаем что у нас фильтр всегда квадратный
            double[,] kernel = filter.kernel;

            int centralKernel = (kernelHeight - 1) / 2; //типо индекс центрального элемента кернела

            int y = 0;
            while (y < height - (kernelHeight - 1))
            {
                int x = 0;
                while (x < width - (kernelHeight - 1))
                {
                    List<List<Color>> pixels = new List<List<Color>>();
                    for (int i = 0; i < kernelHeight; i++)
                    {
                        pixels.Add(new List<Color>());
                    }

                    for (int i = 0; i < kernelHeight; i++)
                    {
                        for (int j = 0; j< kernelHeight; j++)
                        {
                            pixels[i].Add(sourceImage.GetPixel(x + i, y + j));
                            //pixels[i][j] = sourceImage.GetPixel(x+i, y+j);
                        }
                    }

                    int sumR=0, sumB=0, sumG=0;

                    for (int i = 0; i < kernelHeight; i++)
                    {
                        for (int j = 0; j < kernelHeight; j++)
                        {
                            sumR += (int)(Convert.ToDouble(pixels[i][j].R) * kernel[i, j]);
                            sumG += (int)(Convert.ToDouble(pixels[i][j].G) * kernel[i, j]);
                            sumB += (int)(Convert.ToDouble(pixels[i][j].B) * kernel[i, j]);
                        }
                    }

                    sumR = sumR / filter.divider + filter.delta;
                    sumG = sumG / filter.divider + filter.delta;
                    sumB = sumB / filter.divider + filter.delta;
                    int a = (int)pixels[centralKernel][centralKernel].A;

                    Color newColor = Color.FromArgb(a, NormalizeIntToBitValue(sumR), NormalizeIntToBitValue(sumG), NormalizeIntToBitValue(sumB));

                    result.SetPixel(x + centralKernel, y + centralKernel, newColor);
                    x++;
                }
                y++;
            }


            for (int i=0; i< width; i++)
            {
                for (int j=0; j<centralKernel; j++)
                {
                    result.SetPixel(i, j, sourceImage.GetPixel(i, j));//копируем верхние пиксели
                    result.SetPixel(i, height - 1 - j, sourceImage.GetPixel(i, height - 1 - j));//нижние пиксели
                }
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < centralKernel; j++)
                {
                    result.SetPixel(j, i, sourceImage.GetPixel(i, j));
                    result.SetPixel(width - 1 - j, i, sourceImage.GetPixel(width - 1 - j, i));
                }
            }
            return result;
        }

        public static int NormalizeIntToBitValue(int color)
        {
            if (color > 255)
            {
                return 255;
            }
            else if (color < 0)
            {
                return 0;
            }
            else
            {
                return color;
            }
        }
    }
}

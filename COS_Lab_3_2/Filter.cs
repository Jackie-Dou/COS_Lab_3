using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COS_Lab_3_2
{
    public class Filter
    {
        public int divider;
        public double[,] kernel;
    }
    public class BlurFilter:Filter
    {
        public new double divider = 9;
        public new double[,] kernel = new double[3, 3] { { 1, 1, 1 },
                                                       { 1, 1, 1 },
                                                       { 1, 1, 1 }
        };
    }
}

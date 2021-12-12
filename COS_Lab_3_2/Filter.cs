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
        public int delta;
    }
    public class BlurFilter:Filter
    {
        public new double divider = 9;
        public new double[,] kernel = new double[3, 3] { { 1, 1, 1 },
                                                       { 1, 1, 1 },
                                                       { 1, 1, 1 }
        };
        public new int delta = 0;
    }

    public class SharpnessFilter : Filter
    {
        public new double divider = 1;
        public new double[,] kernel = new double[3, 3] { { -1, -1, -1 },
                                                       { -1, 9, -1 },
                                                       { -1, -1, -1 }
        };
        public new int delta = 0;
    }

    public class EmbossingFilter : Filter
    {
        public new double divider = 1;
        public new double[,] kernel = new double[3, 3] { { 0, 1, 0 },
                                                       { -1, 0, 1 },
                                                       { 0, -1, 0 }
        };
        public new int delta = 128;
    }

    public class EdgeDetectionFilter : Filter
    {
        public new double divider = 1;
        public new double[,] kernel = new double[3, 3] { { 0, -1, 0 },
                                                       { -1, 4, -1 },
                                                       { 0, -1, 0 }
        };
        public new int delta = 0;
    }
}

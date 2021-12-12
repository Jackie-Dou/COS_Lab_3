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
        private int _divider = 9;
        private double[,] _kernel = new double[3, 3] { { 1, 1, 1 },
                                                       { 1, 1, 1 },
                                                       { 1, 1, 1 }
        };
        private int _delta = 0;

        public BlurFilter()
        {
            divider = _divider;
            kernel = _kernel;
            delta = _delta;
        }
    }

    public class SharpnessFilter : Filter
    {
        private int _divider = 1;
        private double[,] _kernel = new double[3, 3] { { 0, -1, 0 },
                                                       { -1, 5, -1 },
                                                       { 0, -1, 0 }
        };
        private int _delta = 0;
        public SharpnessFilter()
        {
            divider = _divider;
            kernel = _kernel;
            delta = _delta;
        }
    }

    public class EmbossingFilter : Filter
    {
        private int _divider = 1;
        private double[,] _kernel = new double[3, 3] { { -2, -1, 0 },
                                                       { -1, 1, 1 },
                                                       { 0, 1, 2 }
        };
        private int _delta = 0;
        public EmbossingFilter()
        {
            divider = _divider;
            kernel = _kernel;
            delta = _delta;
        }
    }

    /*public class EdgeDetectionFilter : Filter
    {
        private int _divider = 1;
        private double[,] _kernel = new double[3, 3] { { 0, -1, 0 },
                                                       { -1, 4, -1 },
                                                       { 0, -1, 0 }
        };
        private int _delta = 2;
        public EdgeDetectionFilter()
        {
            divider = _divider;
            kernel = _kernel;
            delta = _delta;
        }
    }*/

    public class EdgeDetectionFilter : Filter
    {
        private int _divider = 1;
        private double[,] _kernel = new double[3, 3] { { -1, -1, -1},
                                                       { -1, 8, -1 },
                                                       { -1, -1, -1 }
        };
        private int _delta = 0;
        public EdgeDetectionFilter()
        {
            divider = _divider;
            kernel = _kernel;
            delta = _delta;
        }
    }
}

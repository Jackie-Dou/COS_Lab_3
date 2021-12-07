using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COS_Lab_3_2
{
    class Point
    {
        public int R;
        public int G;
        public int B;

        public void bytesToColors(byte byteValue)
        {
            this.R = (byte)((byteValue & 0xE0) >> 5);     // rgb8 & 1110 0000  >> 5
            this.G = (byte)((byteValue & 0x1C) >> 2);     // rgb8 & 0001 1100  >> 2
            this.B = (byte)(byteValue & 0x03);            // rgb8 & 0000 0011
        }

        public byte colorsToByte()
        {
            byte RGB = (byte)((this.R << 5) | (this.G << 2) | this.B);
            return RGB;
        }
    }
}

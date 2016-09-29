using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Cisco_Tool.Animations
{
    class Resizing
    {
        public static void changewidth(int orginalPixelCount, int goalPixelCount)
        {
            if (orginalPixelCount < goalPixelCount) // make bigger
            {

            }
            else
            {

            }
        }
        public static int getLongestStringInPixels(List<string> allStrings, PaintEventArgs e)
        {
            String longestString = allStrings.OrderByDescending(s => s.Length).First();
            Font stringFont = new Font("Microsoft Sans Serif", 10);
            SizeF stringSizeInFloat = new SizeF();
            stringSizeInFloat = e.Graphics.MeasureString(longestString, stringFont);
            //e.Graphics.DrawRectangle(new Pen(Color.Red, 1), 0.0F, 0.0F, stringSizeInFloat.Width, stringSizeInFloat.Height);
            int size =  Convert.ToInt32(stringSizeInFloat);
            return size;
        }
    }
}

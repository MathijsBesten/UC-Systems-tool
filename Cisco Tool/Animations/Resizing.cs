using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Cisco_Tool.Animations
{
    class Resizing
    {
        public static int GetLongestStringInPixels(List<string> allStrings)
        {
            double width;
            String longestString = allStrings.OrderByDescending(s => s.Length).First();
            Font stringFont = new Font("Microsoft Sans Serif", 10);
            using (Bitmap tempImage = new Bitmap(400,400))
            {
                SizeF stringsize = Graphics.FromImage(tempImage).MeasureString(longestString, stringFont);
                width = stringsize.Width;
            }
            int stringInPixels = Convert.ToInt32(width);
            return stringInPixels;
        }
        public static int GetListHeight(List<string> list)
        {
            float totalHeight;
            String longestString = list.OrderByDescending(s => s.Length).First();
            Font stringFont = new Font("Microsoft Sans Serif", 10);
            using (Bitmap tempImage = new Bitmap(400, 400))
            {
                float stringHeight = Graphics.FromImage(tempImage).MeasureString(longestString, stringFont).Height;
                totalHeight = stringHeight * list.Count;
            }
            int totalHeightInPixels = Convert.ToInt32(totalHeight);
            return totalHeightInPixels;
        }
    }
}

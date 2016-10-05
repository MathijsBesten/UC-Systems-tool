using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cisco_Tool.Widgets.Views
{
    public partial class WidgetCreator : Form
    {
        public WidgetCreator()
        {
            InitializeComponent();
        }

        private void outputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool stringContainsExplanationMark = false;
                bool stringContainsColon = false;
                bool stringContainscomma = false;

                string completeResponse = outputBox.Text; 
                string selectedString = outputBox.SelectedText;
                int startIndex = completeResponse.IndexOf(selectedString);
                int endIndex = startIndex + selectedString.Length;
                string[] substring = Regex.Split(completeResponse, selectedString);
                var enterCountInfront = Regex.Matches(substring[0], "\\r\\n").Count; // will be saved in xml file
                var enterCountInSelectedString = Regex.Matches(selectedString, "\\r\\n").Count; // will be saved in xml file

            }
        }
    }
}

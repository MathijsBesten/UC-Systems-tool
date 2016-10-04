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

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string completeResponse = textBox4.Text; 
                string selectedString = textBox4.SelectedText;
                int startIndex = completeResponse.IndexOf(selectedString);
                int endIndex = startIndex + selectedString.Length;
                string[] substring = Regex.Split(completeResponse, selectedString);
                var enterCountInfront = Regex.Matches(substring[0], "\\r\\n").Count; // will be saved in xml file
                var enterCountInSelectedString = Regex.Matches(selectedString, "\\r\\n").Count; // will be saved in xml file

                //selecting answer on enterindex
                //without knowing the selected text 
                string[] enters = Regex.Split(completeResponse, "\\r\\n");
                string fullstringWithoutWord = "";
                string fullStringWithWord = "";
                int count = 0;
                foreach (var item in enters)
                {
                    if (count < (enterCountInfront))
                    {
                        fullstringWithoutWord += item;
                        fullStringWithWord += item;
                        count++;
                    }
                    else if (count < (enterCountInfront + 1 + enterCountInSelectedString))
                    {
                        fullStringWithWord += item;
                        count++;
                    }
                    else
                    {
                        break;
                    }

                }
                int startIndexOfResponse = fullstringWithoutWord.Length;
                string word = fullStringWithWord.Remove(0, fullstringWithoutWord.Length);
                int getTotalBytes = Encoding.UTF8.GetByteCount(completeResponse); 
                MessageBox.Show(word);
            }
        }
    }
}

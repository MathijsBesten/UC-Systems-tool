using Cisco_Tool.Widgets.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cisco_Tool.EventHandlers
{
    class EventHandlers
    {
        public void minMaxButton_Click(object sender, EventArgs e)
        {
            PictureBox realSender = ((PictureBox)sender);
            var parentPanel = realSender.Parent.Parent; // get widget panel
            MessageBox.Show(parentPanel.Name.ToString());
        }
        public void closeButton_Click(object sender, EventArgs e)
        {
            PictureBox realSender = ((PictureBox)sender);
            var parentPanel = realSender.Parent.Parent; // get widget panel
            int indexToRemove;
            try
            {
                indexToRemove = Int32.Parse(parentPanel.Tag.ToString());
            }
            catch (Exception)
            {
                indexToRemove = -1;
                MessageBox.Show("There was a problem with converting the widget tag");
            }
            if (indexToRemove >= 0)
            {
                JSON.removeWidgetFromWidgetList(indexToRemove);
            }
        }
    }
}

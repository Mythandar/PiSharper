using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PiSharper.SharperLib;

namespace PiSharper_Testing_Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            SharperLib.Gpio.TestMode = false;
            SharperLib.Gpio.SetupChannel(SharperLib.BCMPin.Four, SharperLib.Direction.Output);
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SharperLib.Gpio.OutputValue(SharperLib.BCMPin.Four, false);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SharperLib.Gpio.OutputValue(SharperLib.BCMPin.Four, true);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SharperLib.Gpio.OutputValue(SharperLib.PhysicalPin.Seven, true);

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SharperLib.Gpio.OutputValue(SharperLib.BCMPin.Four, false);

        }
    }
}

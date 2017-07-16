using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Imaging.Filters;

namespace Face_Detector
{
    public partial class Form1 : Form
    {
        private Bitmap _inputImage; //make a global variable to be accessable to all the loops

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void insert_button_Click(object sender, EventArgs e)
        {
            var openfileDialog = new OpenFileDialog();
            if (openfileDialog.ShowDialog() == DialogResult.OK)
            {
                _inputImage = (Bitmap)System.Drawing.Image.FromFile(openfileDialog.FileName);
                pictureBoxInput.Image = _inputImage;

            }
        }

        private void process_button_Click(object sender, EventArgs e)
        {
            //changes are made here

            // Channel filtering is more towards saturated range, it is focusing on whole channel 
            var channelFilter = new ChannelFiltering();
            channelFilter.Red = new AForge.IntRange(120, 229);
            channelFilter.Green = new AForge.IntRange(80,221);
            channelFilter.Blue = new AForge.IntRange(120, 183);
            var channelFilterOutput = channelFilter.Apply(_inputImage);
            pictureBoxOutput.Image = channelFilterOutput;

        }
    }
}

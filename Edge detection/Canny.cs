﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edge_detection
{
    public partial class Canny : Form
    {
        string filePath;
        double sigma;
        short k;
        double bottomThreshold;
        double upperThreshold;

        public Canny(string filePath, double sigma,short k, double bottomThreshold, double upperThreshold)// получаем из основной формы путь к выбранному файлу
        {
            InitializeComponent();
            this.filePath = filePath;
            this.sigma = sigma;
            this.k = k;
            this.bottomThreshold = bottomThreshold;
            this.upperThreshold = upperThreshold;
        }
        

        private void Canny_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(filePath);
            Bitmap a = new Bitmap(pictureBox1.Image);

            Form1.GrayScale(a);
            Form1.Gaussian_Blur(a, sigma, k);
            Form1.Sobel(a);
            pictureBox2.Image = a;
            Bitmap b = new Bitmap(a);
            Form1.Non_Maximum_Suppression(b);
            pictureBox3.Image = Form1.Double_Threshold(b, bottomThreshold, upperThreshold);
            Bitmap c = new Bitmap(b);
            pictureBox4.Image = Form1.Hysteresis_Thresholding(c, "Canny");
        }

        
    }
}
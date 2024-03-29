﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFcircuito
{
    public partial class Form1 : Form
    {
        int r1, r2, r3, r4, rx, ry, Ve;
        double Vab, i1, i2, determinante;

        public Form1()
        {
            InitializeComponent();
            r1 = 1;
            r2 = 1;
            r3 = 2;
            r4 = 3;
            Ve = 5;
        }

        private void firmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("WFcruzlara_signature.exe");
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "El valor del voltaje es: " + calcularVoltaje() + " V";
        }

        private double calcularVoltaje()
        {
            // Calculo de resistencias equivalentes
            rx = r1 + r3;
            ry = r2 + r3 + r4;

            // Calculo del determinante
            determinante = (rx - ry) - Math.Pow(r3, 2);

            // Calculo de las corrientes
            i1 = (Ve * ry) / determinante;
            i2 = (r3 * Ve) / determinante;

            // Calculo del voltaje
            Vab = r4 * i2;

            return Vab;
        }
    }
}

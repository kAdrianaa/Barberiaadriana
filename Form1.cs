﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barberia
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Show();
            Hide();
        }

        private void trabajadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trabajador trabajador = new Trabajador();
            trabajador.Show();
            Hide();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.Show();
            Hide();
        }
    }
}

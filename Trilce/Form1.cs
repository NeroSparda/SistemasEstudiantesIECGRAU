﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace Trilce
{
    public partial class Form1 : Form
    {
        private LEstudiantes estudiante = new LEstudiantes();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

        private void PictureBoxImage(object sender, EventArgs e)
        {
            estudiante.uploadImage.CargarImagen(pictureBoxImage);
        }

       

        private void TextBoxNid(object sender, KeyPressEventArgs e)
        {
            if (textBoxId.Text.Equals(""))
            {
                labelNid.ForeColor = Color.LightSlateGray;

            }
            else
            {
                labelNid.ForeColor = Color.Green;
                labelNid.Text = "Nid";
            }
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNombre.Text.Equals(""))
            {
                labelNombre.ForeColor = Color.LightSlateGray;

            }
            else
            {
                labelNombre.ForeColor = Color.Green;
                labelNombre.Text = "Nombre";
            }
        }

        private void textBoxApellido_TextChanged(object sender, EventArgs e)
        {
            if (textBoxApellido.Text.Equals(""))
            {
                labelApellido.ForeColor = Color.LightSlateGray;

            }
            else
            {
                labelApellido.ForeColor = Color.Green;
                labelApellido.Text = "Apellido";
            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            if (textBoxEmail.Text.Equals(""))
            {
                labelEmail.ForeColor = Color.LightSlateGray;

            }
            else
            {
                labelEmail.ForeColor = Color.Green;
                labelEmail.Text = "Email";
            }
        }

        private void TextBoxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TextBoxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TextBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            estudiante.textBoxEvent.TextKeyPress(e);
        }
    }
}

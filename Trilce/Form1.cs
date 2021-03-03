using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using Data;
using Logica.Library;

namespace Trilce
{
    public partial class Form1 : Form
    {
        private LEstudiantes estudiante;
        private Librarys librarys;
        public Form1()
        {
            InitializeComponent();
            librarys = new Librarys();
            var listTextBox = new List<TextBox>();
            listTextBox.Add(textBoxId);
            listTextBox.Add(textBoxNombre);
            listTextBox.Add(textBoxApellido);
            listTextBox.Add(textBoxEmail);
            var listLabel = new List<Label>();
            listLabel.Add(labelNid);
            listLabel.Add(labelNombre);
            listLabel.Add(labelApellido);
            listLabel.Add(labelEmail);
            Object[] objectos = { pictureBoxImage };
            estudiante = new LEstudiantes(listTextBox,listLabel,objectos);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

        private void PictureBoxImage(object sender, EventArgs e)
        {
            librarys.uploadImage.CargarImagen(pictureBoxImage);
        }


        
        private void TextBoxNid_TextChanged(object sender, EventArgs e)
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
            librarys.textBoxEvent.TextKeyPress(e);
        }

        private void TextBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            librarys.textBoxEvent.TextKeyPress(e);
        }

        private void TextBoxNid_KeyPress(object sender, KeyPressEventArgs e)
        {
            librarys.textBoxEvent.numberKeyPress(e);
        }

        private void ButtonAgregar_Click(object sender, EventArgs e)
        {
            estudiante.Registrar();
        }

        
    }
}

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
        //private Librarys librarys;
        public Form1()
        {
            InitializeComponent();
            //librarys = new Librarys();
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
            listLabel.Add(labelPaginas);
            Object[] objectos = { 
                pictureBoxImagen,
                Properties.Resources.Logo_de_Git,
                dataGridView1,
                numericUpDown1
            };
            estudiante = new LEstudiantes(listTextBox,listLabel,objectos);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

        private void PictureBoxImage(object sender, EventArgs e)
        {
            estudiante.uploadImage.CargarImagen(pictureBoxImagen);
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
            estudiante.textBoxEvent.TextKeyPress(e);
        }

        private void TextBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            estudiante.textBoxEvent.TextKeyPress(e);
        }

        private void TextBoxNid_KeyPress(object sender, KeyPressEventArgs e)
        {
            estudiante.textBoxEvent.numberKeyPress(e);
        }

        private void ButtonAgregar_Click(object sender, EventArgs e)
        {
            estudiante.Registrar();
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            estudiante.SearchEstudiante(textBoxBuscar.Text);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            estudiante.Registro_Paginas();
        }

        private void buttonPrimero_Click(object sender, EventArgs e)
        {
            estudiante.Paginador("Primero");
        }

        private void buttonAnterior_Click(object sender, EventArgs e)
        {
            estudiante.Paginador("Anterior");
        }

        private void buttonSiguiente_Click(object sender, EventArgs e)
        {
            estudiante.Paginador("Siguiente");
        }

        private void buttonUltimo_Click(object sender, EventArgs e)
        {
            estudiante.Paginador("Ultimo");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
                estudiante.GetEstudiante();
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
                estudiante.GetEstudiante();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            estudiante.Eliminar();
        }

        private void pictureBoxImagen_Click(object sender, EventArgs e)
        {
            estudiante.uploadImage.CargarImagen(pictureBoxImagen);
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            estudiante.Restablecer();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

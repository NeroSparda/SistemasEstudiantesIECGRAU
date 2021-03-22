using Data;
using LinqToDB;
using Logica.Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica
{
    public class LEstudiantes: Librarys
    {
        private List<TextBox> listTextBox;
        private List<Label> listLabel;
        private PictureBox image;
        private Bitmap _imagBitmap;
        private DataGridView _dataGridView;
        private NumericUpDown _numericUpDown;
        private Paginador<estudiante> _paginador;
        private string _accion = "insert";
        //private Librarys librarys;
        public LEstudiantes(List<TextBox> listTextBox, List<Label> listLabel, object[] objectos)
        {
            this.listTextBox = listTextBox;
            this.listLabel = listLabel;
            //librarys = new Librarys();
            image = (PictureBox)objectos[0];
            _imagBitmap = (Bitmap)objectos[1];
            _dataGridView = (DataGridView)objectos[2];
            _numericUpDown = (NumericUpDown)objectos[3];

            Restablecer();//Vacia y muestra valores en la tabla al abrirla
        }

        public void Registrar()
        {
            if (listTextBox[0].Text.Equals(""))
            {
                listLabel[0].Text = "El campo nid es requerido";
                listLabel[0].ForeColor = Color.Red;
                listLabel[0].Focus();
            }
            else
            {
                if (listTextBox[1].Text.Equals(""))
                {
                    listLabel[1].Text = "El campo nombre es requerido";
                    listLabel[1].ForeColor = Color.Red;
                    listLabel[1].Focus();
                }
                else
                {
                    if (listTextBox[2].Text.Equals(""))
                    {
                        listLabel[2].Text = "El campo apellido es requerido";
                        listLabel[2].ForeColor = Color.Red;
                        listLabel[2].Focus();
                    }
                    else
                    {
                        if (listTextBox[3].Text.Equals(""))
                        {
                            listLabel[3].Text = "El campo email es requerido";
                            listLabel[3].ForeColor = Color.Red;
                            listLabel[3].Focus();
                        }
                        else
                        {
                            if(textBoxEvent.comprobarFormatoEmail(listTextBox[3].Text))
                            {
                                //using (var db = new Conexion())
                                //{
                                //    db.Insert(new estudiante()
                                //    {
                                //        nid = listTextBox[0].Text,
                                //        nombre = listTextBox[1].Text,
                                //        apellido = listTextBox[2].Text,
                                //        email = listTextBox[3].Text

                                //    });
                                //}
                                //------------Procedimiento 2daForma-------------
                                ///Verificar datos en un email//
                                var user = _Estudiante.Where(u => u.email.Equals(listTextBox[3].Text)).ToList();
                                ///---------------------------------------------
                                if (user.Count.Equals(0))
                                {
                                    Save();
                                }else
                                {
                                    listLabel[3].Text = "Email ya registrado";
                                    listLabel[3].ForeColor = Color.Red;
                                    listLabel[3].Focus();
                                }
                            }
                            else
                            {
                                listLabel[3].Text = "El campo email no es valido";
                                listLabel[3].ForeColor = Color.Red;
                                listLabel[3].Focus();
                            }
                        }
                    }
                }
            }
        }
        private void Save()
        {
            BeginTransactionAsync();
            try
            {
                var imagenArray = uploadImage.ImageToByte(image.Image);

                _Estudiante.Value(e => e.nid, listTextBox[0].Text)
                .Value(e => e.nombre, listTextBox[1].Text)
                .Value(e => e.apellido, listTextBox[2].Text)
                .Value(e => e.email, listTextBox[3].Text)
                .Value(e => e.image, imagenArray)
                .Insert();

                CommitTransaction();
                Restablecer();
            }
            catch (Exception)
            {
                RollbackTransaction();

            }
        }
        private int _reg_por_pagina = 3, _num_pagina = 1;
        public void SearchEstudiante(String campo)
        {
            List<estudiante> query = new List<estudiante>();
            int inicio = (_num_pagina - 1) * _reg_por_pagina;
            if(campo.Equals(""))
            {
                query = _Estudiante.ToList();
            }
            else
            {
                query = _Estudiante.Where(c => c.nid.StartsWith(campo) || c.nombre.StartsWith(campo)
                || c.apellido.StartsWith(campo)).ToList();
            }
            if(0 < query.Count)
            {
                _dataGridView.DataSource = query.Select(c => new
                {
                    c.id,
                    c.nid,
                    c.nombre,
                    c.apellido,
                    c.email
                }).Skip(inicio).Take(_reg_por_pagina).ToList();
                _dataGridView.Columns[0].Visible = false;

                _dataGridView.Columns[1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                _dataGridView.Columns[3].DefaultCellStyle.BackColor = Color.WhiteSmoke;

            }
            else
            {
                _dataGridView.DataSource = query.Select(c => new
                {
                    c.id,
                    c.nid,
                    c.nombre,
                    c.apellido,
                    c.email,
                    c.image
                }).Skip(inicio).Take(_reg_por_pagina).ToList();
                _dataGridView.Columns[0].Visible = false;
                _dataGridView.Columns[5].Visible = false;
                _dataGridView.Columns[1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                _dataGridView.Columns[3].DefaultCellStyle.BackColor = Color.WhiteSmoke;



            }
        }
        private int _idEstudiante = 0;
        public void GetEstudiante()
        {
            _accion = "update";
            _idEstudiante = Convert.ToInt16(_dataGridView.CurrentRow.Cells[0].Value);
            listTextBox[0].Text = Convert.ToString(_dataGridView.CurrentRow.Cells[1].Value);
            listTextBox[1].Text = Convert.ToString(_dataGridView.CurrentRow.Cells[2].Value);
            listTextBox[2].Text = Convert.ToString(_dataGridView.CurrentRow.Cells[3].Value);
            listTextBox[3].Text = Convert.ToString(_dataGridView.CurrentRow.Cells[4].Value);
            try
            {
                byte[] arrayImage = (byte[])_dataGridView.CurrentRow.Cells[5].Value;
                image.Image = uploadImage.byteArrayToImage(arrayImage);
            }
            catch(Exception)
            {
                image.Image = _imagBitmap;
            }
        }
        public void Paginador (string metodo)
        {
            switch(metodo)
            {
                case "Primero":
                    _num_pagina = _paginador.primero();
                    break;
                case "Anterior":
                    _num_pagina = _paginador.anterior();
                    break;
                case "Siguiente":
                    _num_pagina = _paginador.siguiente();
                    break;
                case "Ultimo":
                    _num_pagina = _paginador.ultimo();
                    break;
            }
            SearchEstudiante("");
        }
        public void Registro_Paginas()
        {
            _num_pagina = 1;
            _reg_por_pagina = (int)_numericUpDown.Value;
            var list =_Estudiante.ToList();
            if(0<list.Count)
            {
                _paginador = new Paginador<estudiante>(listEstudiante, listLabel[4], _reg_por_pagina);
                SearchEstudiante("");
            }
        }
        private List<estudiante> listEstudiante;
        private void Restablecer()
        {
            image.Image = _imagBitmap;
            listLabel[0].Text = "Nid";
            listLabel[1].Text = "Nombre";
            listLabel[2].Text = "Apellido";
            listLabel[3].Text = "Email";
            listLabel[0].ForeColor = Color.LightSlateGray;
            listLabel[1].ForeColor = Color.LightSlateGray;
            listLabel[2].ForeColor = Color.LightSlateGray;
            listLabel[3].ForeColor = Color.LightSlateGray;
            listTextBox[0].Text = "";
            listTextBox[1].Text = "";
            listTextBox[2].Text = "";
            listTextBox[3].Text = "";
            listEstudiante = _Estudiante.ToList();
            if(0<listEstudiante.Count)
            {
                _paginador = new Paginador<estudiante>(listEstudiante, listLabel[4], _reg_por_pagina);
            }
            SearchEstudiante("");

        }
    }      
}

using Logica.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica
{
    public class LEstudiantes: Librarys
    {
        private List<TextBox> listTextBox;
        public LEstudiantes(List<TextBox> listTextBox)
        {
            this.listTextBox = listTextBox;
        }
    }
}

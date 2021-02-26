using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica.Library
{
    public class TextBoxEvent
    {
        public void TextKeyPress(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar)) 
            { 
                //Condicion que solo nos permite ingresa datos de tipo texto
                e.Handled = false;
            } //Condicion que permite no dar salto de linea cuando se oprime enter
            else if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
            }
            else if(char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if(char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        public void numberKeyPress(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                //Condicion que solo nos permite ingresa datos de tipo texto
                e.Handled = false;
            } //Condicion que permite no dar salto de linea cuando se oprime enter
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
            }
            else if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}

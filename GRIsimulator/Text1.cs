using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GRIsimulator
{
    /// <summary>
    /// This is a XAML class that represents what is 
    /// essentially a selectable TextBlock. 
    /// It sets the background to transparent, removes the border, 
    /// disallows editting, and enables text wrapping.
    /// </summary>
    public class Text1 : TextBox {

        public Text1() {
            Background = Brushes.Transparent;
            BorderThickness = new Thickness(0,0,0,0);
            IsReadOnly = true;
            TextWrapping = TextWrapping.Wrap;
        }

    }
}

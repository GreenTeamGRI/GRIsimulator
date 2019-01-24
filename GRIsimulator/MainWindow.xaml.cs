using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GRIsimulator {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            //test
            text1.Clear();
            for (int i = 0; i < 1; i++) {
                text1.AppendText("TITLE: ");
            }
        }

        //class variables
        StreamWriter f = new StreamWriter("test.txt"); //use "\r\n" to write newline

        //user defined
        //test click
        void OnClick1(object sender, RoutedEventArgs e) {
            //test change color
            if (view_panel.Background == null) {
                Trace.WriteLine("Color: default");
                view_panel.Background = Brushes.Green;
            } else {
                Trace.WriteLine("Color: " + menu.Background.ToString());
                view_panel.Background = null;
            }
            //test change element value
            Text1 t = new Text1();
            t.Text = "asdfad";
            view_panel.Children.Add(t);
        }

        //test write to file
        void SaveAll(object sender, RoutedEventArgs e) {
            test_disp.AppendText(" end \r\n");
            f.Write(textbox1.Text + " end \r\n");
            f.Flush();
        }

        //show the data panel when a standard is double clicked
        void ShowDataPanel(object sender, RoutedEventArgs e) {
            SaveAll(sender, e);
            view_panel.Children.Clear();
            Text1 t1 = new Text1();
            textbox1.Clear();
            view_panel.Children.Add(t1);
            view_panel.Children.Add(textbox1);
            t1.AppendText("a. A description of the organization's activities");
        }
    }

}

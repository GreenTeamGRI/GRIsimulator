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
using System.Windows.Markup;

namespace GRIsimulator {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        //Constructor
        public MainWindow() {
            InitializeComponent();
            //initial write test
            text1.Clear();
            for (int i = 0; i < 1; i++) {
                text1.AppendText("initial write test success");
            }
            //dynamic tree creation
            FileStream treeFile = new FileStream("GRIstandards.xaml", FileMode.Open, FileAccess.Read);
            UIElement griTree = (UIElement)XamlReader.Load(treeFile);
            
            tree_panel.Children.Add(griTree);
        }

        //class variables
        StreamWriter f = new StreamWriter("test.txt"); //use "\r\n" to write newline

        //user defined

        //NewWindow
        void New(object sender, RoutedEventArgs e) {
            test_disp.AppendText("--open NewWindow window");
            NewWindow newWindow = new NewWindow();
            newWindow.Owner = this;
            newWindow.ShowDialog();
        }

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
            if (sender is Button) {
                ((Button)sender).Content = "what";
            }
        }

        //show the data panel when a standard is double clicked
        //the standard is necessarily an Item
        public void ShowDataPanel(object sender, RoutedEventArgs e) {
            SaveAll(sender, e);
            view_panel.Children.Clear();

            GRIStandard griTree = sender as GRIStandard;
            Item griTreeItem = griTree.SelectedItem as Item;
            String itemHeader = griTreeItem.Header.ToString();
            info_text.Text = itemHeader;
            Text1 t1 = new Text1();
                t1.AppendText(itemHeader);

            textbox1.Clear();
            view_panel.Children.Add(t1);
            //display according to dataType
            String dataType = griTreeItem.dataType;
            if (dataType == "text") {
                view_panel.Children.Add(textbox1);
            }
            else if (dataType == "list") {
                for (int i = 0; i < 5; i++) {
                    TextBox listBox = new TextBox();
                    listBox.Height = 20;
                    listBox.Width = 100;
                    listBox.HorizontalAlignment = HorizontalAlignment.Left;
                    view_panel.Children.Add(listBox);
                }
            }
        }
    }

}

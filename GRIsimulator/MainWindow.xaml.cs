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

//this MainWindow partial class mainly contains methods 
//for the window interactions
namespace GRIsimulator {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        //Constructor
        public MainWindow() {
            InitializeComponent();
            //initial write test
            title.Clear();
            for (int i = 0; i < 1; i++) {
                title.AppendText("initial write test success");
            }

            docName = "GRI Standard - Comprehensive.xaml";
            //dynamic tree creation
            GRIStandard griTree = LoadStandard("Standard", "Comprehensive");
            CurrentGriTree = griTree;

            tree_panel.Children.Add(griTree);
        }
        //loads a GRI standard from lib
        private GRIStandard LoadStandard(String industry, String detail) {
            String fileName = @"lib\" + "GRI " + industry + " - " + detail + ".xaml";
            FileStream treeFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            GRIStandard tree = (GRIStandard)XamlReader.Load(treeFile);
            tree.BorderThickness = new Thickness(0, 0, 0, 0);
            return tree;
        }

        //class variables
        StreamWriter f; //use "\r\n" to write newline
        String docName;

        //user defined

        //NewWindow
        void New(object sender, RoutedEventArgs e) {
            test_disp.AppendText("--open NewWindow window");
            NewWindow newWindow = new NewWindow();
            newWindow.Owner = this;
            newWindow.ShowDialog();
        }
    }

}

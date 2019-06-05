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
//for internal panel logic
namespace GRIsimulator {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        GRIStandard CurrentGriTree; //current document for full save write
        Item currentItem; //keeps track of current item to update
        FlowDocument currentFlowDoc; //keeps track of current FlowDoc to update

        //test click
        void OnClick1(object sender, RoutedEventArgs e) {
            //test change color
            if (data_panel.Background == null) {
                Trace.WriteLine("Color: default");
                data_panel.Background = Brushes.Green;
            } else {
                Trace.WriteLine("Color: " + menu.Background.ToString());
                data_panel.Background = null;
            }
            //test change element value
            Text1 t = new Text1();
            t.Text = "asdfad";
            data_panel.Children.Add(t);
        }

        //stub- save currentFlowDoc to currentItem > ContentContainer 
        void SaveCurrent() {
            if (currentItem != null && currentFlowDoc != null) {
            }
            currentItem = null;
            currentFlowDoc = null;
            test_disp.AppendText(" saved \r\n");
        }

        //test write to file
        void SaveAll(object sender, RoutedEventArgs e) {
            //SaveCurrent();
            f = new StreamWriter(docName, false);
            f.WriteLine(XamlWriter.Save(CurrentGriTree)); 
            f.Flush();
            f.Close();
            test_disp.AppendText(" wrote \r\n");
        }

        //show the data panel when a standard is double clicked
        //the standard is an Item
        public void ShowDataPanel(object sender, RoutedEventArgs e) {
            //SaveCurrent();
            //SaveAll(sender, e);
            data_panel.Children.Clear();

            GRIStandard griTree = sender as GRIStandard;
            Item griTreeItem = griTree.SelectedItem as Item;

            String header = griTreeItem.Header.ToString();
            String description = griTreeItem.description;
            String content = griTreeItem.content;
            FlowDocument doc = griTreeItem.flowDoc;
            String dataType = griTreeItem.dataType;

            //set current context
            currentItem = griTreeItem;
            currentFlowDoc = doc;

            //display description
            info_text.Text = header + " \r\n \r\n" + description;

            //display Header
            title.Text = "Section " + header;
            data_panel.Children.Add(title);

            //display content according to dataType
            //note: currently, regardless of dataType, the default edit field is a RichTextBox
            if (dataType == null || dataType == "" || dataType == " ") { //no dataType means the tree item doesn't require input
                doc = null;
                currentFlowDoc = doc;
            } else {
                richtextbox1.Document = doc;
                //richtextbox1.AppendText(griTreeItem.content);//test
                data_panel.Children.Add(richtextbox1);

            }
        }
    }

}

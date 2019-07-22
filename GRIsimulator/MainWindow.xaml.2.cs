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

        Item currentItem; //keeps track of current item to update
        FlowDocument currentFlowDoc; //keeps track of current FlowDoc to update

        //test click
        //use Trace.WriteLine("");

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
            if (docName == null || docName == "" || docName == " ") {
                if (griTree != null) {
                    SaveAs(sender, e);
                } else {

                }
            } else {
                f = new StreamWriter(docName, false);
                f.WriteLine(XamlWriter.Save(griTree));
                f.Flush();
                f.Close();
                test_disp.AppendText(" wrote \r\n");
            }
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
            if (dataType == null || dataType == "" || dataType == " " || dataType == "none" || dataType == "noHeading") { //no dataType means the tree item doesn't require input
                doc = null;
                currentFlowDoc = doc;
            } else {
                richtextbox1.Document = doc;
                data_panel.Children.Add(edit_bar);
                data_panel.Children.Add(richtextbox1);

            }
        }
    }

}

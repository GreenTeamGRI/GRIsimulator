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
            String industry = "Standard";
            String detail = "Comprehensive";
            String fileName = @"lib\" + "GRI " + industry + " - " + detail + ".xaml";

            Load(fileName);
        }
        //loads a GRI standard from lib
        public void Load(String fileName) {
            FileStream treeFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            griTree = (GRIStandard)XamlReader.Load(treeFile);
            griTree.BorderThickness = new Thickness(0, 0, 0, 0);

            tree_panel.Children.Clear();
            tree_panel.Children.Add(griTree);
            data_panel.Children.Clear();

            test_disp.AppendText("Load successful: " + fileName);
        }

        //class variables
        StreamWriter f; //use "\r\n" to write newline
        GRIStandard griTree;
        public String docName;

        //user defined

        //New
        public void New(object sender, RoutedEventArgs e) {
            NewWindow newWindow = new NewWindow();
            newWindow.Owner = this;
            newWindow.ShowDialog();
        }

        //Open
        public void Open(object sender, RoutedEventArgs e) {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".xaml";
            dlg.Filter = "XAML Files (*.xaml)|*.xaml";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true) {
                docName = dlg.FileName;
                Load(docName);
            }
        }

        //SaveAs
        public void SaveAs(object sender, RoutedEventArgs e) {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "GRI"; // Default file name
            dlg.DefaultExt = ".xaml"; // Default file extension
            dlg.Filter = "XAML Files (*.xaml)|*.xaml"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true) {
                docName = dlg.FileName;
                SaveAll(sender, e);
            }
        }

        //ExportToWord
        public void ExportToWord(object sender, RoutedEventArgs e) {

            if (griTree != null) {
                FlowDocument collective = new FlowDocument();
                foreach (Item node in griTree.Items) {
                    if (node.flowDoc != null) {
                        ExportHelper(collective, node);
                    }
                }

                Stream rtfWrite = new FileStream(docName + ".rtf", FileMode.OpenOrCreate);
                TextRange content;
                content = new TextRange(collective.ContentStart, collective.ContentEnd);
                content.Save(rtfWrite, DataFormats.Rtf);

                rtfWrite.Flush();
                rtfWrite.Close();
            }
        }
        private void ExportHelper(FlowDocument collective, Item node) {
            if (node.flowDoc != null) {
                Paragraph headerPara = new Paragraph(new Run((string)node.Header));

                Trace.WriteLine("tyty " + node.Header);

                FlowDocument currentFlowDoc = new FlowDocument();
                AddDocument(node.flowDoc, currentFlowDoc);
                headerPara.FontSize = 24;
                headerPara.FontWeight = FontWeights.Bold;
                List<Block> flowDocumentBlocks = new List<Block>(currentFlowDoc.Blocks);
                foreach (Block aBlock in flowDocumentBlocks) {
                    collective.Blocks.Add(headerPara);
                    collective.Blocks.Add(aBlock);
                }
            }
            if (node.HasItems) {
                foreach (Item subNode in node.Items) {
                    ExportHelper(collective, subNode);
                }
            }
        }

        /// <summary>
        /// Adds one flowdocument to another.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        public static void AddDocument(FlowDocument from, FlowDocument to) {
            TextRange range = new TextRange(from.ContentStart, from.ContentEnd);
            MemoryStream stream = new MemoryStream();
            System.Windows.Markup.XamlWriter.Save(range, stream);
            range.Save(stream, DataFormats.XamlPackage);
            TextRange range2 = new TextRange(to.ContentEnd, to.ContentEnd);
            range2.Load(stream, DataFormats.XamlPackage);
        }

        //Close
        public void Close(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace GRIsimulator {
    /// <summary>
    /// This is a XAML class that extends TreeView. 
    /// It changes nothing except for the class name. 
    /// </summary>
    public class GRIStandard : TreeView {
        public GRIStandard() {
            //set all GRI tree items to have this click event
            MouseDoubleClick += ShowDataPanelMethod;
        }

        //this click event
        private void ShowDataPanelMethod(object sender, MouseButtonEventArgs e) {
            //The MainWindow instance method ShowDataPanel(object, MouseButtonEventArgs)
            ((MainWindow)Application.Current.MainWindow).ShowDataPanel(this, e);
        }
    }

    /// <summary>
    /// This is a XAML class that extends TreeViewItem. 
    /// </summary>
    public class Item : TreeViewItem {

        public Item() {
            description = "";
            content = "";
            flowDoc = new FlowDocument(new Paragraph(new Run()));
            dataType = "";
        }

        //get, set description
        public String description {
            get { return (String)GetValue(descriptionProperty); }
            set { SetValue(descriptionProperty, value); }
        }
        public static readonly DependencyProperty descriptionProperty =
            DependencyProperty.Register(
            "description",
            typeof(String),
            typeof(Item),
            new FrameworkPropertyMetadata(null,
                FrameworkPropertyMetadataOptions.AffectsRender)
            );

        //get, set content
        public String content {
            get { return (String)GetValue(contentProperty); }
            set { SetValue(contentProperty, value); }
        }
        public static readonly DependencyProperty contentProperty =
            DependencyProperty.Register(
            "content",
            typeof(String),
            typeof(Item),
            new FrameworkPropertyMetadata(null,
                FrameworkPropertyMetadataOptions.AffectsRender)
            );

        //get nested FlowDocument
        public FlowDocument flowDoc { get; set; }
        public FlowDocument getDoc() {
            foreach (var subItem in this.Items) {
                if (subItem.GetType() == typeof(ContentControl)) {
                    foreach (var fd in LogicalTreeHelper.GetChildren((ContentControl)subItem)) {
                        if (fd.GetType() == typeof(FlowDocument)) {
                            ((ContentControl)subItem).Content = null; //disconnect flowDoc from its ContentContainer
                            this.Items.Remove(subItem); //remove ContentContainer from context
                            //System.Diagnostics.Debug.WriteLine("flowDoc returned. ");
                            return (FlowDocument)fd;
                        }
                    }
                }
            }
            return new FlowDocument();
        }

        //get, set datatype
        public String dataType {
            get { return (String)GetValue(dataTypeProperty); }
            set { SetValue(dataTypeProperty, value); }
        }
        public static readonly DependencyProperty dataTypeProperty =
            DependencyProperty.Register(
            "dataType",
            typeof(String),
            typeof(Item),
            new FrameworkPropertyMetadata(null,
                FrameworkPropertyMetadataOptions.AffectsRender)
            );

    }
}

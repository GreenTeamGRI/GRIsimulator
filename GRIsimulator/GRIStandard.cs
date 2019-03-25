using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

            dataType = "text";
        }

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

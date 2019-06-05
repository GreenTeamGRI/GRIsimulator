using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GRIsimulator {
    /// <summary>
    /// Interaction logic for NewWindow.xaml
    /// </summary>
    public partial class NewWindow : Window {
        public NewWindow() {
            InitializeComponent();

            
        }

        //class variables
        String industry;
        String detail;
        String fileName;


        private void OK_Click(object sender, RoutedEventArgs e) {

            RadioButton industryButton = industry_select.Children.OfType<RadioButton>()
                 .FirstOrDefault(r => r.IsChecked.HasValue && r.IsChecked.Value);
            industry = (string)industryButton.Content;
            RadioButton detailButton = detail_select.Children.OfType<RadioButton>()
                 .FirstOrDefault(r => r.IsChecked.HasValue && r.IsChecked.Value);
            detail = (string)detailButton.Content;
            fileName = @"lib\" + "GRI " + industry + " - " + detail + ".xaml";

            ((MainWindow)Owner).Load(fileName);
            ((MainWindow)Owner).docName = "";

            Trace.WriteLine("derp " + fileName);

            this.Close();
        }
    }

}

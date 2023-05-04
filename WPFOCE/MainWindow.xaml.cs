using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFOCE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml0
    /// </summary>
    public partial class MainWindow : Window
    {
        public string TextBoxContent { get; set; }
        public MainWindow()
        {
            TextBoxContent = "Content";
            InitializeComponent();
        }

        private void MyClick(object sender, RoutedEventArgs e)
        {
            ViewTextbox2.Text = TextBoxContent;
        
        }
    }
}

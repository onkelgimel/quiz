using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace QuizzApp_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public FrameworkElement DebugView { get; set; }
        public FrameworkElement MainMenuView { get; set; }

        //public readonly FrameworkElement MainMenuView;
        //public readonly FrameworkElement DebugView;

        public MainWindow()
        {
            InitializeComponent();

            MainMenuView = new Hauptmenue();
            DebugView    = new DebugView2();

            SetWindowContent(MainMenuView);
        }

        public void SetWindowContent(FrameworkElement uc)
        {
            contentFrame.Content = uc;
        }

        private void Menu_Beenden_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Menu_Debug_Click(object sender, RoutedEventArgs e)
        {
            SetWindowContent(DebugView);
        }

        private void Menu_Hauptmenue_Click(object sender, RoutedEventArgs e)
        {
            SetWindowContent(MainMenuView);
        }
    }
}

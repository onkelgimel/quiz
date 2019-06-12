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

namespace QuizzApp_1
{
    /// <summary>
    /// Interaction logic for EndGameView.xaml
    /// </summary>
    public partial class EndGameView : UserControl
    {
        public FrameworkElement GameView { get; set; }

        public EndGameView(int SCORE)
        {
            InitializeComponent();
            LBL_playerScore.Content = string.Format("Erreichte Punkte: {0}", SCORE);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GameView = new GameView();
            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);

            parentWindow.SetWindowContent(GameView);
        }
    }
}
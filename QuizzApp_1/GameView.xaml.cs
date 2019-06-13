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

using System.Threading;
using System.Windows.Media.Animation;

namespace QuizzApp_1
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        // Haelt den Fortschritt des Benutzers fest, wieviele Fragen er schon beantwortet hat
        // Das Spiel endet nach dem alle Fragen beantwortet wurden
        private int QuestionsIndex       = 0;
        public  int PlayerScore          = 0;
        private List<Frage> QuestionList = GameLogic.GetQuestions(10);
        private List<Button> AnswerButtons;

        public FrameworkElement EndGameView { get; set; }
        public ColorAnimation FlashButtonGreen = new ColorAnimation { From = Colors.Green, Duration = new Duration(TimeSpan.FromMilliseconds(1200)), FillBehavior = FillBehavior.Stop };
        public ColorAnimation FlashButtonRed   = new ColorAnimation { From = Colors.Red  , Duration = new Duration(TimeSpan.FromMilliseconds(1200)), FillBehavior = FillBehavior.Stop };
        public Storyboard CellBackgroundChangeStory = new Storyboard();

        public GameView()
        {
            InitializeComponent();
            
            BTN_Antwort1.Background    = new SolidColorBrush(Colors.LightGray);
            BTN_Antwort2.Background    = new SolidColorBrush(Colors.LightGray);
            BTN_Antwort3.Background    = new SolidColorBrush(Colors.LightGray);
            BTN_Antwort4.Background    = new SolidColorBrush(Colors.LightGray);
            AnswerButtons              = new List<Button> { BTN_Antwort1, BTN_Antwort2, BTN_Antwort3, BTN_Antwort4 };
            FlashButtonGreen.Completed += ColorAnimation_Completed;
            FlashButtonRed.Completed   += ColorAnimation_Completed;

            LoadQuestion();
        }

        private void LoadQuestion()
        {
            TXTBLK_Frage.Text   = QuestionList[QuestionsIndex].Fragesatz;
            var RandomizedOrder = GameLogic.UniqueRandom(0, 3).ToList();

            AnswerButtons[RandomizedOrder[0]].Content = QuestionList[QuestionsIndex].Antworten[0]; // CORRECT ANSWER
            AnswerButtons[RandomizedOrder[1]].Content = QuestionList[QuestionsIndex].Antworten[1];
            AnswerButtons[RandomizedOrder[2]].Content = QuestionList[QuestionsIndex].Antworten[2];
            AnswerButtons[RandomizedOrder[3]].Content = QuestionList[QuestionsIndex].Antworten[3];

            StatusBarText.Text = string.Format("Frage {0}/{1}", QuestionsIndex + 1, QuestionList.Count );
        }

        private void BTN_Antwort_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if ((string)clickedButton.Content == QuestionList[QuestionsIndex].Antworten[0])
            {
                PlayerScore++;
                clickedButton.Background.BeginAnimation(SolidColorBrush.ColorProperty, FlashButtonGreen);
            } else {
                clickedButton.Background.BeginAnimation(SolidColorBrush.ColorProperty, FlashButtonRed);
            }

            if (QuestionsIndex < QuestionList.Count - 1) {
                // Wenn nicht die letzte Frage erreicht ist, naechste Frage laden
                QuestionsIndex++;
            } else {
                // Wenn die letzte Frage erreicht war, EndGame Bildschirm anzeigen
                EndGameView = new EndGameView(PlayerScore);
                MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
                parentWindow.SetWindowContent(EndGameView);
            }
        }

        private void ColorAnimation_Completed(object sender, EventArgs e)
        {
            LoadQuestion();
        }
    }
}

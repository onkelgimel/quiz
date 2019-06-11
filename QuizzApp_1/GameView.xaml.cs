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
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        // Haelt den Fortschritt des Benutzers fest, wieviele Fragen er schon beantwortet hat
        // Das Spiel endet nach 10 beantworteten Fragen
        private int QuestionsIndex       = 0;
        public int PlayerScore           = 0;
        private List<Frage> QuestionList = GameLogic.GetQuestions();
        private List<Button> AnswerButtons;
        public FrameworkElement EndGameView { get; set; }

        public GameView()
        {
            InitializeComponent();
            AnswerButtons = new List<Button> { BTN_Antwort1, BTN_Antwort2, BTN_Antwort3, BTN_Antwort4 };
            LoadQuestion();
        }

        private void LoadQuestion()
        {
            LBL_Frage.Content   = QuestionList[QuestionsIndex].Fragesatz;
            var RandomizedOrder = GameLogic.UniqueRandom(0, 3).ToList();

            AnswerButtons[RandomizedOrder[0]].Content = QuestionList[QuestionsIndex].Antworten[0]; // CORRECT ANSWER
            AnswerButtons[RandomizedOrder[1]].Content = QuestionList[QuestionsIndex].Antworten[1];
            AnswerButtons[RandomizedOrder[2]].Content = QuestionList[QuestionsIndex].Antworten[2];
            AnswerButtons[RandomizedOrder[3]].Content = QuestionList[QuestionsIndex].Antworten[3];

            StatusBarText.Text = string.Format("{2} -- Frage {0}/{1}", QuestionsIndex + 1, QuestionList.Count, RandomizedOrder[0] );
        }

        private void BTN_Antwort_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton.Content == QuestionList[QuestionsIndex].Antworten[0])
            {
                PlayerScore++;
            }

            if (QuestionsIndex < QuestionList.Count - 1) {
                // Wenn nicht die letzte Frage erreicht ist, naechste Frage laden
                QuestionsIndex++;
                LoadQuestion();
            } else {
                // Wenn die letzte Frage erreicht war, EndGame Bildschirm anzeigen
                EndGameView = new EndGameView(PlayerScore);
                MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
                parentWindow.SetWindowContent(EndGameView);
            }
        }
    }
}

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
        private int QuestionsIndex = 0;
        private List<Frage> QuestionList = GameLogic.GetQuestions();

        public GameView()
        {
            InitializeComponent();

            NextQuestion();
        }

        private void NextQuestion()
        {
            LBL_Frage.Content    = QuestionList[QuestionsIndex].Fragesatz;
            /*
            BTN_Antwort1.Content = QuestionList[QuestionsIndex].Antworten[0];
            BTN_Antwort2.Content = QuestionList[QuestionsIndex].Antworten[1];
            BTN_Antwort3.Content = QuestionList[QuestionsIndex].Antworten[2];
            BTN_Antwort4.Content = QuestionList[QuestionsIndex].Antworten[3];
            */
            StatusBarText.Text = string.Format("Frage {0}/{1}", QuestionsIndex + 1, QuestionList.Count);
            QuestionsIndex++;
        }

        private void BTN_Antwort_Click(object sender, RoutedEventArgs e)
        {
            NextQuestion();
        }
    }
}

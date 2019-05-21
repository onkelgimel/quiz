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

using System.IO;
using System.Data;
using System.Data.OleDb;

namespace QuizzApp_1
{
    /// <summary>
    /// Interaction logic for DebugView2.xaml
    /// </summary>
    public partial class DebugView2 : UserControl
    {
        public DebugView2()
        {
            var Data = GameLogic.ParseCSVFile(@"./../../../quizzdb.csv");

            InitializeComponent();
            DataGrid1.ItemsSource = Data.Tables[0].DefaultView;
           
        }
    }

}

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
            var Data = CSVParser.ParseCSVFile(@"U:\QuizzApp_1\quizzdb.csv");
            InitializeComponent();
            DataGrid1.ItemsSource = Data.Tables[0].DefaultView;
        }
    }

    class CSVParser
    {
        public static DataSet ParseCSVFile(string FilePath)
        {
            DataSet ds = new DataSet("csvData");
            string dir = System.IO.Path.GetDirectoryName(FilePath);
            // HDR=YES wuerde die erste Zeile als Header einlesen
            string connstr = String.Format("Provider = Microsoft.Jet.OleDb.4.0; Data Source={0}; Extended Properties = \"Text;HDR=NO;FMT=Delimited\"", dir);

            using (System.Data.OleDb.OleDbConnection conn = new OleDbConnection(connstr))
            {
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + System.IO.Path.GetFileName(FilePath), conn);
                adapter.Fill(ds);
            }

            return ds; //<-- here is your data;
        }
    }
}

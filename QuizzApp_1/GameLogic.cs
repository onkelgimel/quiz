using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Data;
using System.Data.OleDb;

namespace QuizzApp_1
{
    class GameLogic
    {
        public static uint gl_AnzahlFragen = 10;

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

    class Frage
    {
        public string Frage { get; }
        public List<String> Antworten { get; }
        public string Ant { get; }
    }
}

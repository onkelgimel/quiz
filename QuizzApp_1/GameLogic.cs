﻿using System;
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

        public static List<Frage> GetQuestions()
        {
            var Data = ParseCSVFile(@"./../../../quizzdb.csv");
            List<Frage> Liste = new List<Frage>();

            foreach (DataRow Zeile in Data.Tables[0].Rows)
            {
                var Frage = new Frage
                {
                    Fragesatz = Zeile[0].ToString()
                };

                Liste.Add(Frage);
            }

            return Liste;
        }

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
        public string Fragesatz { get; set; }
        public List<string> Antworten { get; set; }

        // Die erste Antwort ist immer die richtige
        public static uint RichtigeAntwortIndex { get; private set; } = 1;
    }

}

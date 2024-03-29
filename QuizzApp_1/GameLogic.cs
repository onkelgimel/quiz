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
        public static List<Frage> GetQuestions(int Amount)
        {
            var Data = ParseCSVFile(@"quizzdb.csv");
            //var Data = ParseCSVFile(@"../../../quizzdb.csv");
            List<Frage> Liste = new List<Frage>();

            // Get Amount-many Random numbers from 0 to the amount of available questions
            if (Amount >= Data.Tables[0].Rows.Count)
            {
                Amount = Data.Tables[0].Rows.Count;
            }
            var QuestionsToGet = UniqueRandom(0, Data.Tables[0].Rows.Count - 1).ToList().GetRange(0, Amount);

            // i ist der Index in das Array aller moeglichen Fragen die in der CSV enthalten sind.
            // Da die Zahlen in QuestionsToGet zufaellig sind holen wir uns hier Fragen von zufaelligen Positionen
            foreach (var i in QuestionsToGet)
            {
                if (Amount > 0)
                {
                    var FragenDaten = Data.Tables[0].Rows[i];
                    var Frage = new Frage
                    {
                        Fragesatz = FragenDaten[0].ToString(),
                        Antworten = new List<string> { FragenDaten[1].ToString(), FragenDaten[2].ToString(), FragenDaten[3].ToString(), FragenDaten[4].ToString() }
                    };

                    Liste.Add(Frage);
                    Amount--;
                }
            }
            
            return Liste;
        }

        public static DataSet ParseCSVFile(string FileName)
        {
            DataSet ds = new DataSet("csvData");
            string progExePath  = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string progRootPath = System.IO.Directory.GetParent(progExePath).FullName;
            // HDR=YES wuerde die erste Zeile als Header einlesen
            string connstr = String.Format("Provider = Microsoft.Jet.OleDb.4.0; Data Source={0}; Extended Properties = \"Text;HDR=NO;FMT=Delimited\"", progRootPath);

            using (System.Data.OleDb.OleDbConnection conn = new OleDbConnection(connstr))
            {
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + FileName, conn);
                adapter.Fill(ds);
            }

            return ds;
        }

        // Alle Zahlen zwischen min und max zurueckgeben, aber in zufaelliger Reihenfolge
        public static IEnumerable<int> UniqueRandom(int minInclusive, int maxInclusive)
        {
            List<int> candidates = new List<int>();
            for (int i = minInclusive; i <= maxInclusive; i++)
            {
                candidates.Add(i);
            }
            Random rnd = new Random();
            while (candidates.Count > 0)
            {
                int index = rnd.Next(candidates.Count);
                yield return candidates[index];
                candidates.RemoveAt(index);
            }
        }

    }

    class Frage
    {
        public string Fragesatz { get; set; }
        public List<string> Antworten { get; set; }
    }

}

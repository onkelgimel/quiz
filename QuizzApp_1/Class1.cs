using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp_1
{
    public class Frage
    {
        public String Fragesatz { get; set; }
        public String Antwort_1 { get; set; }
        public String Antwort_2 { get; set; }
        public String Antwort_3 { get; set; }
        public String Antwort_4 { get; set; }

        public Frage(String fragesatz, String antwort_1, String antwort_2, String antwort_3, String antwort_4)
        {
            Fragesatz = fragesatz;
            Antwort_1 = antwort_1;
            Antwort_2 = antwort_2;
            Antwort_3 = antwort_3;
            Antwort_4 = antwort_4;
        }



    }
}

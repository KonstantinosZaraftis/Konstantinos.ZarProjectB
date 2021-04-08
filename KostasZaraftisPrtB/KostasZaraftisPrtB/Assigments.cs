using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KostasZaraftisPrtB
{
    class Assigments
    {

     
        public string Title { get; set; }
        public string Description { get; set; }

        public string SubDateTime { get; set; }

        public int OralMark { get; set; }
        public int TotalMark { get; set; }

        public Assigments(string title,string description,string subDateTime,int oralMark,int totalMark)
        {
            
            Title = title;
            Description = description;
            SubDateTime = subDateTime;
            OralMark = oralMark;
            TotalMark = totalMark;
        }








    }
}

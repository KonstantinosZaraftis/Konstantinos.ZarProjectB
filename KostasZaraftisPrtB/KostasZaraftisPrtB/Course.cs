using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KostasZaraftisPrtB
{
    class Course
    {

        
        public string Title { get; set; }
        public string Stream { get; set; }
        public string Type { get; set; }

        public DateTime Start_date { get; set; }

        public DateTime End_date { get; set; }

       

        public Course( string title, string stream, string type, DateTime start_date, DateTime end_date)


        {


            Title = title;
            Stream = stream;
            Type = type;
            Start_date = start_date;
            End_date = end_date;
           
        }





    }
}

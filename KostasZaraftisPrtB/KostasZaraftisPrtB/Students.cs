using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KostasZaraftisPrtB
{
    class Students
    {



        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int TuitionFees { get; set; }

        


        public Students( string firstName, string lastName, DateTime dateOfDirth, int tuitionFees)
        {
           
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfDirth;
            TuitionFees = tuitionFees;
          
        }





    }
}

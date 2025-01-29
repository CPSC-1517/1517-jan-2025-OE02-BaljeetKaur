﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ResidentAddress Address { get; set; }

       


        public Person()
        {
            FirstName = "Unknown";
            LastName = "Unknown";
            

        }
        public Person( string firstname, string lastname, ResidentAddress address)
        {
            FirstName = firstname;
            LastName = lastname;
            Address = address;

        }
    }
}

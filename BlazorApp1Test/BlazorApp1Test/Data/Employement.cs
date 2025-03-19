using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReviewJan14
{
    public class Employement
    {
        #region Data Member
        private string _Title;
        private double _Years;
        private SupervisoryLevel _Level;

        #endregion


        #region Properties
        public string Title
        {
            get { return _Title; }
            set
            {

                //reffered as mutator and you can write your valdation check here
                // incoming data is accessed by keyword value

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"The Title value ({value}) is not acceptable");
                }

                _Title = value;
            }
        }

        public double Year
        {
            get { return _Years; }
            set
            {
                //validation check
                // if (value < 0 )
                // throw exception with appropriate message
                _Years = value;
            }
        }

        public SupervisoryLevel Level
        {
            get { return _Level; }
            private set
            {
                // Enum.IsDefined(typeof(SupervisoryLevel), value)
                if (!Enum.IsDefined(typeof(SupervisoryLevel), value))
                {
                    throw new ArgumentException($"Supervisory Level ({value}) is Invalid");
                }
                _Level = value;

            }
        }

        public DateTime StartDate { get; set; }

        #endregion

        #region Constructor

        public Employement()
        {
            Title = "unknown";
            Level = SupervisoryLevel.TeamMember;
            StartDate = DateTime.Today;
            Year = 0.0;

        }

        public Employement( string title, SupervisoryLevel level , DateTime startdate , double year )
        {
            Title = title;
            Level = level;
            
            if (startdate >= DateTime.Today.AddDays(1))
            {
                throw new ArgumentException($"Start date {startdate} is in the future");
            }
            StartDate = startdate;
           // using Utility class funtions to do a generic operation
            if ( !Utilities.IsZeroOrPositive(year))
            {
                throw new ArgumentException("The value of year is negative");
            }

            Year = year;
        }
        #endregion

        #region Members
        // property
        // method


        public void SetEmployementResponsibilityLevel(SupervisoryLevel level)
        {
            Level = level;
        }
        public void CorrectstartDate(DateTime startdate)
        {
            // add validation

            if (startdate >= DateTime.Today.AddDays(1))
            { throw new ArgumentException($" the satrt date ({startdate}) is in future"); }
            StartDate = startdate;

            TimeSpan days = DateTime.Today - startdate;
            Year = Math.Round((days.Days / 365.2), 1);
        }

        // override the default class method called ToSting()

        public override string ToString()
        {
            return $"{Title},{Level},{StartDate.ToString("MM dd yyyy")}, {Year}";
        }



        #endregion



    }
}
    
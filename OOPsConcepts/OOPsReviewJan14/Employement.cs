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

    }
}
    
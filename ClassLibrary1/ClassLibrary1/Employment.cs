using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOPsReview
{
    public class Employment
    {
        //data members (aka fields, variables, attributes)
        //typically data members are private and hold data for use
        //  within your class
        //usually associated with a property
        //a data member does not have any built-in validation
        private string _Title;
        private double _Years;
        private SupervisoryLevel _Level;

        //Properties
        //are associated with a single piece of data.
        //Properties can be implemented by:
        //  a) fully implemented property
        //  b) auto implemented property

        //A property does not need to store data
        //  this type of property is referred to as a read-only
        //  this property typically uses existing data values
        //      within the instance to return a computed value

        //fully implemented properties usually has additional logic
        //  to execute for control over the data: such as validation
        //fully implemented properties will have a declared data
        //  member to store the data into

        //auto implemented properties do not have additional logic
        //Auto implemented properties do not have a declared
        //  data member instead the o/s will create on the property's
        //  behave a storage that is accessable ONLY by the property

        ///<summary>
        ///Property: Title
        ///datatype: string
        ///validation: there must be a character in the string
        ///a property will always have a getter (accessor)
        ///a property may or maynot have a setter (mutator)
        /// no mutator the property is consider "read-only" and is
        ///         usually returning a computed field
        /// has a mutator, the property will at some point save the data
        ///     to storage
        /// the mutator may be public (default) or private
        ///     public: accessable by outside users of the class
        ///     private: accessable ONLY within the class, usually
        ///                 via the constructor or a method
        /// !!!!! a property DOES NOT have ANY declared incoming parameters !!!!!!
        /// </summary>
        /// 
        public string Title
        {
            //accessor (getter)
            //returns the string associated with this property
            get { return _Title; }

            //mutator (setter)
            //it is within the set that the validation of the data
            //  is done to determine if the data is acceptable
            //if all processing of the string is done via the property
            //  it will ensure that good data is within the associated string
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    //the class does not write to the console
                    //the class with throw an exception that is to be handled
                    //  by the outside user
                    throw new ArgumentNullException("Title", "Title cannot be empty or just blanks");
                }
                else
                {
                    //it is a very good practice to remove leading and trailing spaces on strings
                    //  so that only the required and important characters are stored.
                    //to do this santization use .Trim()
                    _Title = value.Trim();
                }
            }
        }

        ///<summary>
        ///Property: Years
        ///validation: the value must be 0 or greater
        ///datatype: double
        ///</summary>
        ///

        public double Years
        {
            get { return _Years; }
            set
            {
                //replace the hard-code validation with a generic utility method
                //if (value < 0)

                if (!Utilities.IsZeroOrPositive(value))
                    throw new ArgumentException($"The value {value} is not acceptable for years. Years must be 0 or greater.");
                _Years = value;
            }
        }

        ///<summary>
        ///Property: StartDate
        ///validation: none
        ///set access: private
        ///</summary>
        //since the access to this property for the mutator is private ANY validation
        //  for this data will need to be done elsewhere
        //possible locations for the validation could be in
        //  a) a constructor
        //  b) any method that will alter the data
        //a private mutator will NOT allow alteration of the data via a property for the
        //  outside user, however, methods within the class will still be able to
        //  use the property
        

        //this property can be coded as an auto-implemented property
        //the private is independent of the auto-implemented property
        public DateTime StartDate { get; private set; }

        ///<summary>
        ///Property: Level
        ///validation: none
        ///datatype: this is an enum (SupervisoryLevel)
        ///</summary>

        //can an auto-implemented be coded as a fully implemented
        public SupervisoryLevel Level
        {
            //get;set;
            get { return _Level; }

            //the set was changed to a private set to demo using a method to alter the data
            private set { _Level = value; }
        }


        //Constructors
        //your class does not technically need a coded constructor
        //if you code a constructor for your class you are responsible for coding ALL constructors
        //if you do not code a constructor then the system will assign the software datatype defaults
        //  to your variables (data members/auto-implemented properties)

        //syntax: accesslevel constructorname([list of parameters]) { .... }
        //NOTE: NO return datatype
        //      the constructorname MUST be the class name

        //Default
        //simulates the "system defaults"
        public Employment()
        {
            //if there is no code within this constructor, the actions for setting
            //  your internal fields will be using the system defaults for the datatype

            //optionally
            // you could assign values to your initial fields within this constructor typically
            //      using literal values
            //Why?
            // your internal fields may have validation attached to the data for the field
            // this validation is usually within the property
            // you would wish to have valid data values for your internal fields

            Title = "UnKnown"; //assigned to meet validation requirements
            Level = SupervisoryLevel.TeamMember; //wish to have a different initial value
            StartDate =DateTime.Today; //a meaningful value default 0001/01/01

            //Years?
            //the default is fine (0.0)
            //however, if you wish you could actually assign the value 0 yourself
            Years = 0.0;

        }

        //Greedy
        //this is the constructor typically used to assign values to a instance at the time of
        //    creation
        //the list of parameters may or maynot contain default parameter values
        //if you have assigned default parameter values then those parameters MUST be at the end of
        //  the parameter list
        //in this example years is a default parameter (it has an assigned value if the value
        //  is not included on the coded constructor in the user program
        public Employment(string title, SupervisoryLevel level,
                            DateTime startdate, double years = 0.0)
        {
            Title = title;
            Level = level;
            //Years = years;

            //one could add valiation, especially if the property has a private set  OR the property
            //  is an auto-implemented property that has restrictions
            //example
            //validation, start date must not exist in the future
            //validation can be done anywhere in your class
            //since the property is auto-implemented AND/OR has a private set,
            //      validation can be done  in the constructor OR a behaviour 
            //      that alters the property
            //IF the validation is done in the property, IT WOULD NOT be an
            //      auto-implemented property BUT a fully-implemented property
            // .Today has a time of 00:00:00 AM
            // .Now has a specific time of day 13:05:45 PM
            //by using the .Today.AddDays(1) you cover all times on a specific date
            if (CheckDate(startdate))
                StartDate = startdate;

            //during the testing of the unit tests, it has been discovered that the number of years
            //   should also be altered to have a correct timespan
            if (years != 0.0)
            {
                Years = years;
            }
            else
            {
                if (startdate != DateTime.Today)
                {
                    TimeSpan days = DateTime.Today - startdate;
                    Years = Math.Round((days.Days / 365.2), 1);
                }
            }
        }

        //Methods (aka Behaviours)
        public override string ToString()
        {
            //this string is known as a "comma separate value" string (csv)
            //concern: when the date is used, it could have a , within the data value
            //solution: IF this is a possibility that a value that is used in creating the string pattern
            //              could make the pattern invalid, you should explicitly handle how the value should be
            //              displayed in the string
            //example Date:  Jan 05, 2025 (due to using StartDate.ToShortDate())
            //solution:  specific your own format  StartDate.ToString("MMM dd yyyy")

            //Another solution is to change your delimitator that separates your values to a character
            //  that is not within your range of possible values
            //example use a '/'
            //when you use the .Split(delimitator) method to breakup the string into separate values
            //  you would use the delimitator '/':  string [] pieces = thestring.Split('/')

            return $"{Title},{Level},{StartDate.ToString("MMM dd yyyy")},{Years}";
        }

        //Sample action: changed the SupervisoryLevel to be a private set
        //this means altering the Level must be done in constructor (which executes ONLY ONCE during creation) or
        //  via a method (at a time after creation of the instance)

        public void SetEmploymentResponsibilityLevel(SupervisoryLevel newlevel)
        {
            Level = newlevel;
        }

        //StartDate is private set
        //Note: when you have a private set, you MAY NEED to duplicate validation in several
        //      places (constructor AND this method)
        public void CorrectStartDate(DateTime startdate)
        {
            if (CheckDate(startdate))
                StartDate = startdate;
            
            //during the testing of the unit tests, it has been discovered that the number of years
            //   should also be altered to have a correct timespan

            TimeSpan days = DateTime.Today - StartDate;
            Years = Math.Round((days.Days / 365.2), 1);
        }

        //create a private method to handle duplicate code within a class where the method
        //  is NOT for use by the outside user
        //Example: the validation of startdate is in two places
        //          reduce redundance by making a private method 
        private bool CheckDate(DateTime value)
        {

            if (value >= DateTime.Today.AddDays(1))
                throw new ArgumentException($"The start date of {value} is invalid, dates cannot be in the future");
            return true;
        }
    }
}

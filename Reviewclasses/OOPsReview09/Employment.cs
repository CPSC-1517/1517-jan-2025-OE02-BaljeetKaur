using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview09
{
    public class Employment
    {
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set
            {
                if (IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The Title need to have required parameter");

                    _Title = value;
                }
            }
        }

        private bool IsNullOrWhiteSpace(string value)
        {
            throw new NotImplementedException();
        }
    }
}

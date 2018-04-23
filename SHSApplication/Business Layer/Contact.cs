using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class Contact
    {
        private string cell;
        private string email;

        public Contact()
        {

        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }


        public string Cell
        {
            get { return cell; }
            set { cell = value; }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

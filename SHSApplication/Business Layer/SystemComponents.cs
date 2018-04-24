using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class SystemComponents
    {
        private string compCode;
        private string prodCode;
        private string description;

        public SystemComponents()
        {

        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string ProdCode
        {
            get { return prodCode; }
            set { prodCode = value; }
        }


        public string CompCode
        {
            get { return compCode; }
            set { compCode = value; }
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

        public void addComponent() { }

        public void removeComponent() { }


    }
}

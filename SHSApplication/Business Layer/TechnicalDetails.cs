using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class TechnicalDetails
    {
        private string detailId;
        private string prodCode;
        private string configCode;
        private string docPath;

        public TechnicalDetails()
        {

        }

        public string DocPath
        {
            get { return docPath; }
            set { docPath = value; }
        }


        public string ConfigCode
        {
            get { return configCode; }
            set { configCode = value; }
        }


        public string ProdCode
        {
            get { return prodCode; }
            set { prodCode = value; }
        }


        public string DetailId
        {
            get { return detailId; }
            set { detailId = value; }
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

        public void addDetail() { }

        public void updateDetail() { }

        public void removeDetail() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class TechnicalDetails
    {
        private int detailId;
        private Configurations techDet_config;
        private string docPath;

        public TechnicalDetails()
        {

        }

        public string DocPath
        {
            get { return docPath; }
            set { docPath = value; }
        }


        public Configurations TechDet_Config
        {
            get { return techDet_config; }
            set { techDet_config = value; }
        }


        public int DetailId
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

        public void removeDetail() { }
    }
}

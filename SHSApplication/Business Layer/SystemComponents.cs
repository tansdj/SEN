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
        private Product sysComps_product;
        private string description;

        public SystemComponents(string compCode, Product sysComps_product, string description)
        {
            this.CompCode = compCode;
            this.SysComps_Product = sysComps_product;
            this.Description = description;
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public Product SysComps_Product
        {
            get { return sysComps_product; }
            set { sysComps_product = value; }
        }


        public string CompCode
        {
            get { return compCode; }
            set { compCode = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            SystemComponents sc = obj as SystemComponents;
            if ((object)sc==null)
            {
                return false;
            }
            return (this.CompCode==sc.CompCode)&&(this.Description==sc.Description)&&(this.SysComps_Product==sc.SysComps_Product);
        }

        public override int GetHashCode()
        {
            return this.CompCode.GetHashCode()^this.Description.GetHashCode()^this.SysComps_Product.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void addComponent() { }

        public void removeComponent() { }


    }
}

﻿using Serverside.HelperLibraries;
using ServerSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class ComponentVendors
    {
        private SystemComponents cvComponent;
        private Vendor cvVendor;
        public ComponentVendors(SystemComponents cvComponent, Vendor cvVendor)
        {
            this.CvComponents = cvComponent;
            this.CvVendor = cvVendor;
        }

        public Vendor CvVendor
        {
            get { return cvVendor; }
            set { cvVendor = value; }
        }


        public SystemComponents CvComponents
        {
            get { return cvComponent; }
            set { cvComponent = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            ComponentVendors cv = obj as ComponentVendors;
            if ((object)cv==null)
            {
                return false;
            }
            return (this.CvComponents==cv.CvComponents)&&(this.CvVendor==cv.CvVendor);
        }

        public override int GetHashCode()
        {
            return this.CvComponents.GetHashCode()^this.CvVendor.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void InsertComponentVendor()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> compVend_details = new Dictionary<string, string[]>();

            compVend_details.Add(DataAccesHelper.cvCompCode, new string[] { DataAccesHelper.typeString, this.CvComponents.CompCode});
            compVend_details.Add(DataAccesHelper.cvVendorCode, new string[] { DataAccesHelper.typeString, this.CvVendor.VendorCode });

            dh.runQuery(DataAccesHelper.targetCompVendors, DataAccesHelper.requestInsert, compVend_details);
        }

        public void RemoveComponentVendor()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> compVend_details = new Dictionary<string, string[]>();

            compVend_details.Add(DataAccesHelper.cvCompCode, new string[] { DataAccesHelper.typeString, this.CvComponents.CompCode });
            compVend_details.Add(DataAccesHelper.cvVendorCode, new string[] { DataAccesHelper.typeString, this.CvVendor.VendorCode });

            dh.runQuery(DataAccesHelper.targetCompVendors, DataAccesHelper.requestDelete, compVend_details,DataAccesHelper.cvCompCode+" = '"+this.CvComponents.CompCode+"' AND "+DataAccesHelper.cvVendorCode+" = '"+this.CvVendor.VendorCode+"'");
        }

    }
}

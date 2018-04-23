﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class Configuration
    {

        private string configId;
        private string name;
        private string description;
        private string productCode;
        private double addCost;

        public Configuration()
        {

        }

        public double AddCost
        {
            get { return addCost; }
            set { addCost = value; }
        }


        public string ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }


        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public string ConfigId
        {
            get { return configId; }
            set { configId = value; }
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

        public void newConfig() { }

        public void updateConfig() { }

        public void removeConfig() { }
    }
}
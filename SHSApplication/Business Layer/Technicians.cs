﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class Technicians
    {
        private string techId;
        private string name;
        private string surname;
        private Address techAddress;
        private Contact techContact;

       

        public Technicians()
        {

        }
        public Contact TechContact
        {
            get { return techContact; }
            set { techContact = value; }
        }


        public Address TechAddress
        {
            get { return techAddress; }
            set { techAddress = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public string TechId
        {
            get { return techId; }
            set { techId = value; }
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

        public void addTech() { }

        public void removeTech() { }

    }
}

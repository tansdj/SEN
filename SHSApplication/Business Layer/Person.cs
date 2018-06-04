using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class Person
    {
        private string personId;
        private string name;
        private string surname;
        private Address personAddress;
        private Contact personContact;

        public Person(string personId, string name, string surname, Address personAddress, Contact personContact)
        {
            this.PersonId = personId;
            this.Name = name;
            this.Surname = surname;
            this.PersonAddress = personAddress;
            this.PersonContact = personContact;
        }

        public Person()
        {

        }

        public Contact PersonContact
        {
            get { return personContact; }
            set { personContact = value; }
        }


        public Address PersonAddress
        {
            get { return personAddress; }
            set { personAddress = value; }
        }


        public string Surname
        {
            get { return surname; }
            set { surname = value.Trim(' '); }
        }


        public string Name
        {
            get { return name; }
            set { name = value.Trim(' '); }
        }


        public string PersonId
        {
            get { return personId; }
            set { personId = value.Trim(' '); }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Person p = obj as Person;
            if ((object)p==null)
            {
                return false;
            }
            return (this.PersonId==p.PersonId)&&(this.Name==p.Name)&&(this.Surname==p.Surname)&&(this.PersonAddress==p.PersonAddress)&&(this.PersonContact==p.PersonContact);
        }

        public override int GetHashCode()
        {
            return this.PersonId.GetHashCode()^this.Name.GetHashCode()^this.Surname.GetHashCode()^this.PersonAddress.GetHashCode()^this.PersonContact.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}

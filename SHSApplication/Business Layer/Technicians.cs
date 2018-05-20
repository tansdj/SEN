using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerSide;
using Serverside.HelperLibraries;
using System.Data;

namespace SHSApplication.Business_Layer
{
    public class Technicians:Person
    {
        private string status;
        private string skillLevel;

        public Technicians(string personId, string name, string surname, Address personAddress, Contact personContact, string status, string skillLevel) :base(personId,name, surname,personAddress,personContact)
        {
            this.Status = status;
            this.SkillLevel = skillLevel;
        }

        public Technicians()
        {

        }
        public string SkillLevel
        {
            get { return skillLevel; }
            set { skillLevel = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            Technicians t = obj as Technicians;
            if ((object)t==null)
            {
                return false;
            }
            return base.Equals(obj)&&(this.Status==t.Status)&&(this.SkillLevel==t.SkillLevel);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode()^this.Status.GetHashCode()^this.SkillLevel.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void AddTech()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> tech_details = new Dictionary<string, string[]>();
            this.PersonAddress.AddressId = "ADDR" + this.PersonId;
            this.PersonContact.ContactId = "CONT" + this.PersonId;

            tech_details.Add(DataAccesHelper.techId, new string[] { DataAccesHelper.typeString, this.PersonId });
            tech_details.Add(DataAccesHelper.techName, new string[] { DataAccesHelper.typeString, this.Name });
            tech_details.Add(DataAccesHelper.techSurname, new string[] { DataAccesHelper.typeString, this.Surname });
            tech_details.Add(DataAccesHelper.techAddressId, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressId });
            tech_details.Add(DataAccesHelper.techContactId, new string[] { DataAccesHelper.typeString, this.PersonContact.ContactId });
            tech_details.Add(DataAccesHelper.techStatus, new string[] { DataAccesHelper.typeString, this.Status });
            tech_details.Add(DataAccesHelper.techSkill, new string[] { DataAccesHelper.typeString, this.SkillLevel });

        }


        public void UpdateTech()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> tech_details = new Dictionary<string, string[]>();
            Dictionary<string, string[]> addr_details = new Dictionary<string, string[]>();
            Dictionary<string, string[]> cont_details = new Dictionary<string, string[]>();
            this.PersonAddress.AddressId = "ADDR" + this.PersonId;
            this.PersonContact.ContactId = "CONT" + this.PersonId;

            tech_details.Add(DataAccesHelper.techId, new string[] { DataAccesHelper.typeString, this.PersonId });
            tech_details.Add(DataAccesHelper.techName, new string[] { DataAccesHelper.typeString, this.Name });
            tech_details.Add(DataAccesHelper.techSurname, new string[] { DataAccesHelper.typeString, this.Surname });
            tech_details.Add(DataAccesHelper.techAddressId, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressId });
            tech_details.Add(DataAccesHelper.techContactId, new string[] { DataAccesHelper.typeString, this.PersonContact.ContactId });
            tech_details.Add(DataAccesHelper.techStatus, new string[] { DataAccesHelper.typeString, this.Status });
            tech_details.Add(DataAccesHelper.techSkill, new string[] { DataAccesHelper.typeString, this.SkillLevel });

        }

        public void RemoveTech()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> tech_details = new Dictionary<string, string[]>();
            Dictionary<string, string[]> addr_details = new Dictionary<string, string[]>();
            Dictionary<string, string[]> cont_details = new Dictionary<string, string[]>();
            this.PersonAddress.AddressId = "ADDR" + this.PersonId;
            this.PersonContact.ContactId = "CONT" + this.PersonId;

            tech_details.Add(DataAccesHelper.techId, new string[] { DataAccesHelper.typeString, this.PersonId });
            tech_details.Add(DataAccesHelper.techName, new string[] { DataAccesHelper.typeString, this.Name });
            tech_details.Add(DataAccesHelper.techSurname, new string[] { DataAccesHelper.typeString, this.Surname });
            tech_details.Add(DataAccesHelper.techAddressId, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressId });
            tech_details.Add(DataAccesHelper.techContactId, new string[] { DataAccesHelper.typeString, this.PersonContact.ContactId });
            tech_details.Add(DataAccesHelper.techStatus, new string[] { DataAccesHelper.typeString, this.Status });
            tech_details.Add(DataAccesHelper.techSkill, new string[] { DataAccesHelper.typeString, this.SkillLevel });

        }

        public List<Technicians> GetAllTechnicians()
        {
            Datahandler dh = Datahandler.getData();
            List<Technicians> techs = new List<Technicians>();
            DataTable table = dh.readDataFromDB(DataAccesHelper.QueryGetTechnicians);

            foreach (DataRow item in table.Rows)
            {
                Technicians t = new Technicians();
                t.PersonId = item[DataAccesHelper.techId].ToString();
                t.Name = item[DataAccesHelper.techName].ToString();
                t.Surname = item[DataAccesHelper.techSurname].ToString();
                t.PersonAddress = new Address(item[DataAccesHelper.addressId].ToString(), item[DataAccesHelper.addrLine1].ToString(), item[DataAccesHelper.addrLine2].ToString(), item[DataAccesHelper.addrCity].ToString(), item[DataAccesHelper.addrPostalCode].ToString());
                t.PersonContact = new Contact(item[DataAccesHelper.contactId].ToString(), item[DataAccesHelper.contactCell].ToString(), item[DataAccesHelper.contactEmail].ToString());
                t.Status = item[DataAccesHelper.techStatus].ToString();
                t.SkillLevel = item[DataAccesHelper.techSkill].ToString();
                techs.Add(t);
            }

            return techs;
        }
    }

    }


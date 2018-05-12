using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerSide;
using Serverside.HelperLibraries;

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

            this.PersonAddress.InsertAddress();
            this.PersonContact.InsertContact();
            dh.runQuery(DataAccesHelper.targetTechnicians, DataAccesHelper.requestInsert, tech_details);
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

            this.PersonAddress.UpdateAddress();
            this.PersonContact.UpdateContact();
            dh.runQuery(DataAccesHelper.targetTechnicians, DataAccesHelper.requestUpdate, tech_details,DataAccesHelper.techId +" = '"+this.PersonId+"'");
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

            dh.runQuery(DataAccesHelper.targetTechnicians, DataAccesHelper.requestDelete, tech_details, DataAccesHelper.techId + " = '" + this.PersonId+"'");
        }
    }

    }


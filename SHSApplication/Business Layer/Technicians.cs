using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerSide;
using Serverside.HelperLibraries;
using System.Data;
using ServerSide.HelperLibrabries;

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
            set { skillLevel = value.Trim(' '); }
        }

        public string Status
        {
            get { return status; }
            set { status = value.Trim(' '); }
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
            return this.Status.GetHashCode()^this.SkillLevel.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} {1}({2})",this.Name,this.Surname,this.PersonId);
        }

        public bool AddTech()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> tech_details = new Dictionary<string, string[]>();

            tech_details.Add(QueryBuilder.spAddTech.sp_id, new string[] { DataAccesHelper.typeString, this.PersonId });
            tech_details.Add(QueryBuilder.spAddTech.sp_name, new string[] { DataAccesHelper.typeString, this.Name });
            tech_details.Add(QueryBuilder.spAddTech.sp_surname, new string[] { DataAccesHelper.typeString, this.Surname });
            tech_details.Add(QueryBuilder.spAddTech.sp_status, new string[] { DataAccesHelper.typeString, this.Status });
            tech_details.Add(QueryBuilder.spAddTech.sp_skill, new string[] { DataAccesHelper.typeString, this.SkillLevel });
            tech_details.Add(QueryBuilder.spAddTech.sp_addrLine1, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressLine1 });
            tech_details.Add(QueryBuilder.spAddTech.sp_addrLine2, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressLine2 });
            tech_details.Add(QueryBuilder.spAddTech.sp_city, new string[] { DataAccesHelper.typeString, this.PersonAddress.City });
            tech_details.Add(QueryBuilder.spAddTech.sp_postCode, new string[] { DataAccesHelper.typeString, this.PersonAddress.PostalCode });
            tech_details.Add(QueryBuilder.spAddTech.sp_cell, new string[] { DataAccesHelper.typeString, this.PersonContact.Cell });
            tech_details.Add(QueryBuilder.spAddTech.sp_email, new string[] { DataAccesHelper.typeString, this.PersonContact.Email });

            return dh.runStoredProcedure(QueryBuilder.spAddTech.sp, tech_details);

        }


        public bool UpdateTech()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> tech_details = new Dictionary<string, string[]>();

            tech_details.Add(QueryBuilder.spUpdateTech.sp_id, new string[] { DataAccesHelper.typeString, this.PersonId });
            tech_details.Add(QueryBuilder.spUpdateTech.sp_name, new string[] { DataAccesHelper.typeString, this.Name });
            tech_details.Add(QueryBuilder.spUpdateTech.sp_surname, new string[] { DataAccesHelper.typeString, this.Surname });
            tech_details.Add(QueryBuilder.spUpdateTech.sp_status, new string[] { DataAccesHelper.typeString, this.Status });
            tech_details.Add(QueryBuilder.spUpdateTech.sp_skill, new string[] { DataAccesHelper.typeString, this.SkillLevel });
            tech_details.Add(QueryBuilder.spUpdateTech.sp_addrLine1, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressLine1 });
            tech_details.Add(QueryBuilder.spUpdateTech.sp_addrLine2, new string[] { DataAccesHelper.typeString, this.PersonAddress.AddressLine2 });
            tech_details.Add(QueryBuilder.spUpdateTech.sp_city, new string[] { DataAccesHelper.typeString, this.PersonAddress.City });
            tech_details.Add(QueryBuilder.spUpdateTech.sp_postCode, new string[] { DataAccesHelper.typeString, this.PersonAddress.PostalCode });
            tech_details.Add(QueryBuilder.spUpdateTech.sp_cell, new string[] { DataAccesHelper.typeString, this.PersonContact.Cell });
            tech_details.Add(QueryBuilder.spUpdateTech.sp_email, new string[] { DataAccesHelper.typeString, this.PersonContact.Email });

            return dh.runStoredProcedure(QueryBuilder.spUpdateTech.sp, tech_details);

        }

        public List<Technicians> GetAllTechnicians(string techId="")
        {
            Datahandler dh = Datahandler.getData();
            List<Technicians> techs = new List<Technicians>();
            DataTable table = new DataTable();
            if (techId!="")
            {
                table = dh.readDataFromDB(DataAccesHelper.QueryGetTechnicians+" WHERE "+DataAccesHelper.techId+" = '"+this.PersonId+"'");
            }
            else
            {
                table = dh.readDataFromDB(DataAccesHelper.QueryGetTechnicians);
            }

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


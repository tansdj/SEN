using Serverside.HelperLibraries;
using ServerSide;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class ServiceLevel
    {
        private int Id;
        private string level;
        private double monthlyCost;

        public ServiceLevel(string level, double monthlyCost=0,int Id = 0)
        {
            this.ID = Id;
            this.Level = level;
            this.MonthlyCost = monthlyCost;
        }
        public ServiceLevel()
        {

        }

        public double MonthlyCost
        {
            get { return monthlyCost; }
            set { monthlyCost = value; }
        }


        public string Level
        {
            get { return level; }
            set { level = value.Trim(' '); }
        }


        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            ServiceLevel sl = (ServiceLevel)obj;
            if ((object)sl==null)
            {
                return false;
            }

            return (this.ID == sl.ID) && (this.Level == sl.Level) && (this.MonthlyCost == sl.MonthlyCost);
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode() ^ this.Level.GetHashCode() ^ this.MonthlyCost.GetHashCode();
        }

        public override string ToString()
        {
            return this.Level;
        }

        public bool InsertServiceLevel()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> sLevel_details = new Dictionary<string, string[]>();

            sLevel_details.Add(DataAccesHelper.serviceLevelId, new string[] { DataAccesHelper.typeInt, this.ID.ToString() });
            sLevel_details.Add(DataAccesHelper.serviceLevelDesc, new string[] { DataAccesHelper.typeString, this.Level });
            sLevel_details.Add(DataAccesHelper.serviceLevelMonthlyCost, new string[] { DataAccesHelper.typeDouble, this.MonthlyCost.ToString() });

            return dh.runQuery(DataAccesHelper.targetServiceLevel, DataAccesHelper.requestInsert, sLevel_details);
        }

        public bool UpdateServiceLevel()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> sLevel_details = new Dictionary<string, string[]>();

            sLevel_details.Add(DataAccesHelper.serviceLevelId, new string[] { DataAccesHelper.typeInt, this.ID.ToString() });
            sLevel_details.Add(DataAccesHelper.serviceLevelDesc, new string[] { DataAccesHelper.typeString, this.Level });
            sLevel_details.Add(DataAccesHelper.serviceLevelMonthlyCost, new string[] { DataAccesHelper.typeDouble, this.MonthlyCost.ToString() });

            return dh.runQuery(DataAccesHelper.targetServiceLevel, DataAccesHelper.requestInsert, sLevel_details,DataAccesHelper.serviceLevelId+" = "+this.ID);
        }

        public List<ServiceLevel> GetServiceLevels(string level="")
        {
            Datahandler dh = Datahandler.getData();
            List<ServiceLevel> levels = new List<ServiceLevel>();
            DataTable table = new DataTable();
            if (level!="")
            {
                table = dh.readDataFromDB(DataAccesHelper.QueryGetServiceLevels+ " WHERE "+DataAccesHelper.serviceLevelDesc+" = '"+level+"'");
            }
            else
            {
                table = dh.readDataFromDB(DataAccesHelper.QueryGetServiceLevels);
            }

            foreach (DataRow item in table.Rows)
            {
                ServiceLevel sl = new ServiceLevel();
                sl.ID = Convert.ToInt32(item[DataAccesHelper.serviceLevelId].ToString());
                sl.Level = item[DataAccesHelper.serviceLevelDesc].ToString();
                sl.MonthlyCost = Convert.ToDouble(item[DataAccesHelper.serviceLevelMonthlyCost].ToString());
                levels.Add(sl);
            }

            return levels;
        }

    }
}

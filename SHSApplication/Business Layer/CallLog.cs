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
    public class CallLog
    {
        private CallOperators logOperator;
        private Client logClient;
        private DateTime startTime;
        private DateTime endTime;
        private string remarks;

        public CallLog(CallOperators logOperator, Client logClient, DateTime startTime, DateTime endTime, string remarks)
        {
            this.LogOperator = logOperator;
            this.LogClient = logClient;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Remarks = remarks;
        }

        public CallLog()
        {

        }

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value.Trim(' '); }
        }


        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }


        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }


        public Client LogClient
        {
            get { return logClient; }
            set { logClient = value; }
        }


        public CallOperators LogOperator
        {
            get { return logOperator; }
            set { logOperator = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            CallLog cl = (CallLog)obj;
            if ((object)cl==null)
            {
                return false;
            }
            return (this.LogOperator==cl.LogOperator)&&(this.LogClient==cl.LogClient)&&(this.StartTime==cl.StartTime)&&(this.EndTime==cl.EndTime)&&(this.Remarks==cl.Remarks);
        }

        public override int GetHashCode()
        {
            return this.LogOperator.GetHashCode()^this.LogClient.GetHashCode()^this.StartTime.GetHashCode()^this.EndTime.GetHashCode()^this.Remarks.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool InsertCall()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> call_details = new Dictionary<string, string[]>();

            call_details.Add(DataAccesHelper.callOperatorId, new string[] { DataAccesHelper.typeString, this.LogOperator.PersonId });
            call_details.Add(DataAccesHelper.callClientId, new string[] { DataAccesHelper.typeString, this.LogClient.ClientIdentifier });
            call_details.Add(DataAccesHelper.callStartTime, new string[] { DataAccesHelper.typeDateTime, this.StartTime.ToString() });
            call_details.Add(DataAccesHelper.callEndTime, new string[] { DataAccesHelper.typeDateTime, this.EndTime.ToString() });
            call_details.Add(DataAccesHelper.callRemarks, new string[] { DataAccesHelper.typeString, this.Remarks });

            return dh.runQuery(DataAccesHelper.targetCallLog, DataAccesHelper.requestInsert, call_details);
        }

        public List<CallLog> GetCalls(string clientId = "")
        {
            Datahandler dh = Datahandler.getData();
            List<CallLog> calls = new List<CallLog>();
            DataTable table = new DataTable();
            if (clientId!="")
            {
                table = dh.readDataFromDB(DataAccesHelper.QueryGetAllCalls + " WHERE "+DataAccesHelper.callClientId+" = '"+clientId+"'");
            }
            else
            {
                table = dh.readDataFromDB(DataAccesHelper.QueryGetAllCalls);
            }

            foreach (DataRow item in table.Rows)
            {
                CallLog c = new CallLog();
                c.LogOperator = new CallOperators(item[DataAccesHelper.callOperatorId].ToString(),item[DataAccesHelper.operatorName].ToString(),item[DataAccesHelper.operatorSurname].ToString(),null,null,"");
                c.LogClient = new Client("","","",null,null,"","",item[DataAccesHelper.callClientId].ToString());
                c.StartTime = Convert.ToDateTime(item[DataAccesHelper.callStartTime].ToString());
                c.EndTime = Convert.ToDateTime(item[DataAccesHelper.callEndTime].ToString());
                c.Remarks = item[DataAccesHelper.callRemarks].ToString();
                calls.Add(c);
            }

            return calls;
        }

    }
}

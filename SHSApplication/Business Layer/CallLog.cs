using System;
using System.Collections.Generic;
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
            set { remarks = value; }
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

    }
}

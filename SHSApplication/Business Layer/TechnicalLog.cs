using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class TechnicalLog
    {
        private string eventId;
        private Client techLog_client;
        private Technicians techLog_tech;
        private DateTime date;
        private string remarks;

        public TechnicalLog(string eventId, Client techLog_client, Technicians techLog_tech, DateTime date, string remarks)
        {
            this.EventId = eventId;
            this.TechLog_Client = techLog_client;
            this.TechLog_Tech = techLog_tech;
            this.Date = date;
            this.Remarks = remarks;
        }

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }


        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }


        public Technicians TechLog_Tech
        {
            get { return techLog_tech; }
            set { techLog_tech = value; }
        }


        public Client TechLog_Client
        {
            get { return techLog_client; }
            set { techLog_client = value; }
        }


        public string EventId
        {
            get { return eventId; }
            set { eventId = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            TechnicalLog tl = obj as TechnicalLog;
            if ((object)tl==null)
            {
                return false;
            }
            return (this.EventId==tl.EventId)&&(this.TechLog_Client==tl.TechLog_Client)&&(this.TechLog_Tech==tl.TechLog_Tech)&&(this.Date==tl.Date)&&(this.Remarks==tl.Remarks);
        }

        public override int GetHashCode()
        {
            return this.EventId.GetHashCode()^this.TechLog_Client.GetHashCode()^this.TechLog_Tech.GetHashCode()^this.Date.GetHashCode()^this.Remarks.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void logEvent() { }

    }
}

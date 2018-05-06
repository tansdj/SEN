using ServerSide;
using SHSApplication.HelperLibraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class TechnicalLog
    {
        private int eventId;
        private Client techLog_client;
        private Technicians techLog_tech;
        private DateTime date;
        private string remarks;
        private string status;

        public TechnicalLog(int eventId, Client techLog_client, Technicians techLog_tech, DateTime date, string remarks)
        {
            this.EventId = eventId;
            this.TechLog_Client = techLog_client;
            this.TechLog_Tech = techLog_tech;
            this.Date = date;
            this.Remarks = remarks;
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
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


        public int EventId
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

        public void LogEvent()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> tecLog_details = new Dictionary<string, string[]>();

            tecLog_details.Add(DataAccesHelper.eventId, new string[] { DataAccesHelper.typeInt, this.EventId.ToString() });
            tecLog_details.Add(DataAccesHelper.eventClientId, new string[] { DataAccesHelper.typeString, this.TechLog_Client.PersonId });
            tecLog_details.Add(DataAccesHelper.eventTechId, new string[] { DataAccesHelper.typeString, this.TechLog_Tech.PersonId });
            tecLog_details.Add(DataAccesHelper.eventDate, new string[] { DataAccesHelper.typeDateTime, this.Date.ToShortDateString() });
            tecLog_details.Add(DataAccesHelper.eventRemarks, new string[] { DataAccesHelper.typeString, this.Remarks });
            tecLog_details.Add(DataAccesHelper.eventStatus, new string[] { DataAccesHelper.typeString, this.Status });

            dh.runQuery(DataAccesHelper.targetTechEvents, DataAccesHelper.requestInsert, tecLog_details);
        }

        public void UpdateEvent()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> tecLog_details = new Dictionary<string, string[]>();

            tecLog_details.Add(DataAccesHelper.eventId, new string[] { DataAccesHelper.typeInt, this.EventId.ToString() });
            tecLog_details.Add(DataAccesHelper.eventClientId, new string[] { DataAccesHelper.typeString, this.TechLog_Client.PersonId });
            tecLog_details.Add(DataAccesHelper.eventTechId, new string[] { DataAccesHelper.typeString, this.TechLog_Tech.PersonId });
            tecLog_details.Add(DataAccesHelper.eventDate, new string[] { DataAccesHelper.typeDateTime, this.Date.ToShortDateString() });
            tecLog_details.Add(DataAccesHelper.eventRemarks, new string[] { DataAccesHelper.typeString, this.Remarks });
            tecLog_details.Add(DataAccesHelper.eventStatus, new string[] { DataAccesHelper.typeString, this.Status });

            dh.runQuery(DataAccesHelper.targetTechEvents, DataAccesHelper.requestUpdate, tecLog_details,DataAccesHelper.eventId+" = "+this.EventId);
        }

    }
}

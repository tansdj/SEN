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
    public class RequestedEvents
    {
        private int eventId;
        private Client techLog_client;
        private DateTime requestedDate;
        private string remarks;
        private string status;
        private string skillRequired;
        private DateTime completedDate;

        public RequestedEvents(int eventId, Client techLog_client, DateTime requestedDate, DateTime completedDate, string status, string remarks, string skillRequired)
        {
            this.EventId = eventId;
            this.TechLog_Client = techLog_client;
            this.RequestedDate = requestedDate;
            this.CompletedDate = completedDate;
            this.Remarks = remarks;
            this.Status = status;
            this.SkillRequired = skillRequired;
        }

        public DateTime CompletedDate
        {
            get { return completedDate; }
            set { completedDate = value; }
        }

        public RequestedEvents()
        {

        }
        public string SkillRequired
        {
            get { return skillRequired; }
            set { skillRequired = value; }
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


        public DateTime RequestedDate
        {
            get { return requestedDate; }
            set { requestedDate = value; }
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

            RequestedEvents tl = obj as RequestedEvents;
            if ((object)tl==null)
            {
                return false;
            }
            return (this.EventId==tl.EventId)&&(this.TechLog_Client==tl.TechLog_Client)&&(this.RequestedDate==tl.RequestedDate)&&(this.CompletedDate==tl.CompletedDate)&&(this.Status==tl.Status) &&(this.Remarks==tl.Remarks&&(this.SkillRequired==tl.SkillRequired));
        }

        public override int GetHashCode()
        {
            return this.EventId.GetHashCode()^this.TechLog_Client.GetHashCode()^this.RequestedDate.GetHashCode()^this.CompletedDate.GetHashCode()^this.Status.GetHashCode()^this.Remarks.GetHashCode()^this.SkillRequired.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool NewEvent()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> event_details = new Dictionary<string, string[]>();

            event_details.Add(DataAccesHelper.eventId, new string[] { DataAccesHelper.typeInt, this.EventId.ToString() });
            event_details.Add(DataAccesHelper.eventClientId, new string[] { DataAccesHelper.typeString, this.TechLog_Client.PersonId });
            event_details.Add(DataAccesHelper.eventReqDate, new string[] { DataAccesHelper.typeDateTime, this.RequestedDate.ToShortDateString() });
            event_details.Add(DataAccesHelper.eventCompDate, new string[] { DataAccesHelper.typeDateTime, this.CompletedDate.ToShortDateString() });
            event_details.Add(DataAccesHelper.eventRemarks, new string[] { DataAccesHelper.typeString, this.Remarks });
            event_details.Add(DataAccesHelper.eventStatus, new string[] { DataAccesHelper.typeString, this.Status });
            event_details.Add(DataAccesHelper.skillReq, new string[] { DataAccesHelper.typeString, this.SkillRequired });

            return dh.runQuery(DataAccesHelper.targetTechEvents, DataAccesHelper.requestInsert, event_details);
        }

        public bool UpdateEvent()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> event_details = new Dictionary<string, string[]>();

            event_details.Add(DataAccesHelper.eventId, new string[] { DataAccesHelper.typeInt, this.EventId.ToString() });
            event_details.Add(DataAccesHelper.eventClientId, new string[] { DataAccesHelper.typeString, this.TechLog_Client.PersonId });
            event_details.Add(DataAccesHelper.eventReqDate, new string[] { DataAccesHelper.typeDateTime, this.RequestedDate.ToShortDateString() });
            event_details.Add(DataAccesHelper.eventCompDate, new string[] { DataAccesHelper.typeDateTime, this.CompletedDate.ToShortDateString() });
            event_details.Add(DataAccesHelper.eventRemarks, new string[] { DataAccesHelper.typeString, this.Remarks });
            event_details.Add(DataAccesHelper.eventStatus, new string[] { DataAccesHelper.typeString, this.Status });
            event_details.Add(DataAccesHelper.skillReq, new string[] { DataAccesHelper.typeString, this.SkillRequired });

            return dh.runQuery(DataAccesHelper.targetTechEvents, DataAccesHelper.requestUpdate, event_details,DataAccesHelper.eventId+" = "+this.EventId);
        }

        public List<RequestedEvents> GetRequestedEvents()
        {
            Datahandler dh = Datahandler.getData();
            List<RequestedEvents> events = new List<RequestedEvents>();
            DataTable table = dh.readDataFromDB(DataAccesHelper.QueryGetRequestedEvents);

            foreach (DataRow item in table.Rows)
            {
                RequestedEvents tl = new RequestedEvents();
                tl.EventId = Convert.ToInt32(item[DataAccesHelper.eventId].ToString());
                tl.TechLog_Client = new Client();
                tl.TechLog_Client.PersonId = item[DataAccesHelper.eventClientId].ToString();
                tl.RequestedDate = Convert.ToDateTime(item[DataAccesHelper.eventReqDate].ToString());
                tl.CompletedDate = Convert.ToDateTime(item[DataAccesHelper.eventCompDate].ToString());
                tl.Remarks = item[DataAccesHelper.eventRemarks].ToString();
                tl.SkillRequired = item[DataAccesHelper.skillReq].ToString();
                tl.Status = item[DataAccesHelper.eventStatus].ToString();
                events.Add(tl);
            }

            return events;
        }

    }
}

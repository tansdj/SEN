using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class TechnicalLog
    {
        private RequestedEvents reqEvent;
        private Technicians tlTech;

        public TechnicalLog(RequestedEvents reqEvent, Technicians tlTech)
        {
            this.ReqEvent = reqEvent;
            this.TlTech = tlTech;
        }

        public TechnicalLog()
        {

        }

        public Technicians TlTech
        {
            get { return tlTech; }
            set { tlTech = value; }
        }


        public RequestedEvents ReqEvent
        {
            get { return reqEvent; }
            set { reqEvent = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            TechnicalLog tl = (TechnicalLog)obj;
            if ((object)tl==null)
            {
                return false;
            }
            return (this.ReqEvent==tl.ReqEvent)&&(this.TlTech==tl.TlTech);
        }

        public override int GetHashCode()
        {
            return this.ReqEvent.GetHashCode()^this.TlTech.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide.HelperLibrabries
{
    public struct ErrorHandler
    {
        private Exception E;
        public string Msg;

        public ErrorHandler(Exception e)
        {
            E = e;
            Msg = "";
        }

        public void PrintError()
        {
            Msg = "";
            if (E is ArgumentException)
            {
                Msg = "Invalid data have been entered into the system. Please try again.";
            }
            else if (E is InvalidOperationException)
            {
                Msg = "This function is currently not available. Please try again later.";
            }
            else
            {
                Msg = "Something went wrong. We are fixing the problem, please be patient.";
            }
            FileHandler f = new FileHandler("Errors.csv");
            f.WriteToTxt(new List<string>() { String.Format("{0} {1} {2}", Msg, E.Message, DateTime.UtcNow.ToString())});
        }
    }
}

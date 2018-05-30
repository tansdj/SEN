using Serverside.HelperLibraries;
using ServerSide;
using SHSApplication.Business_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class User:ILogin<User>
    {
        private string username;
        private string password;
        private string name;
        private string surname;
        private string email;
        private string access;

        public User(string username, string password, string name, string surname, string email, string access)
        {
            this.Username = username;
            this.Password = password;
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Access = access;
        }

        public User()
        {

        }

        public string Access
        {
            get { return access; }
            set { access = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }


        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            User u = obj as User;
            if ((object)u==null)
            {
                return false;
            }
            return (this.Username==u.Username)&&(this.Password==u.Password)&&(this.Name==u.Name)&&(this.Surname==u.Surname)&&(this.Email==u.Email)&&(this.Access==u.Access);
        }

        public override int GetHashCode()
        {
            return this.Username.GetHashCode()^this.Password.GetHashCode()^this.Name.GetHashCode()^this.Surname.GetHashCode()^this.Email.GetHashCode()^this.Access.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool InsertUser()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> user_details = new Dictionary<string, string[]>();

            user_details.Add(DataAccesHelper.uUsername, new string[] { DataAccesHelper.typeString, this.Username });
            user_details.Add(DataAccesHelper.uPassword, new string[] { DataAccesHelper.typeString, this.Password });
            user_details.Add(DataAccesHelper.uName, new string[] { DataAccesHelper.typeString, this.Name });
            user_details.Add(DataAccesHelper.uSurname, new string[] { DataAccesHelper.typeString, this.Surname });
            user_details.Add(DataAccesHelper.uEmail, new string[] { DataAccesHelper.typeString, this.Email });
            user_details.Add(DataAccesHelper.uAccess, new string[] { DataAccesHelper.typeString, this.Access });

            return dh.runQuery(DataAccesHelper.targetUsers, DataAccesHelper.requestInsert, user_details);
        }

        public bool UpdateUser()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> user_details = new Dictionary<string, string[]>();

            user_details.Add(DataAccesHelper.uUsername, new string[] { DataAccesHelper.typeString, this.Username });
            user_details.Add(DataAccesHelper.uPassword, new string[] { DataAccesHelper.typeString, this.Password });
            user_details.Add(DataAccesHelper.uName, new string[] { DataAccesHelper.typeString, this.Name });
            user_details.Add(DataAccesHelper.uSurname, new string[] { DataAccesHelper.typeString, this.Surname });
            user_details.Add(DataAccesHelper.uEmail, new string[] { DataAccesHelper.typeString, this.Email });
            user_details.Add(DataAccesHelper.uAccess, new string[] { DataAccesHelper.typeString, this.Access });

            return dh.runQuery(DataAccesHelper.targetUsers, DataAccesHelper.requestUpdate, user_details,DataAccesHelper.uEmail+" = '"+this.Email+"'");
        }

        public bool RemoveUser()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> user_details = new Dictionary<string, string[]>();

            user_details.Add(DataAccesHelper.uUsername, new string[] { DataAccesHelper.typeString, this.Username });
            user_details.Add(DataAccesHelper.uPassword, new string[] { DataAccesHelper.typeString, this.Password });
            user_details.Add(DataAccesHelper.uName, new string[] { DataAccesHelper.typeString, this.Name });
            user_details.Add(DataAccesHelper.uSurname, new string[] { DataAccesHelper.typeString, this.Surname });
            user_details.Add(DataAccesHelper.uEmail, new string[] { DataAccesHelper.typeString, this.Email });
            user_details.Add(DataAccesHelper.uAccess, new string[] { DataAccesHelper.typeString, this.Access });

            return dh.runQuery(DataAccesHelper.targetUsers, DataAccesHelper.requestDelete, user_details, DataAccesHelper.uEmail + " = '" + this.Email + "'");
        }

        public List<User> GetAllUsers(string userEmail="")
        {
            Datahandler dh = Datahandler.getData();
            List<User> users = new List<User>();
            DataTable table = new DataTable();
            if (userEmail != "")
            {
                table = dh.readDataFromDB(DataAccesHelper.QueryGetUsers+" WHERE "+DataAccesHelper.uEmail+" = '"+this.Email+"'");
            }
            else
            {
                table = dh.readDataFromDB(DataAccesHelper.QueryGetUsers);
            }

            foreach (DataRow item in table.Rows)
            {
                User u = new User();
                u.Username = item[DataAccesHelper.uUsername].ToString();
                u.Password = item[DataAccesHelper.uPassword].ToString();
                u.Name = item[DataAccesHelper.uName].ToString();
                u.Surname = item[DataAccesHelper.uSurname].ToString();
                u.Email = item[DataAccesHelper.uEmail].ToString();
                u.Access = item[DataAccesHelper.uAccess].ToString();
                users.Add(u);
            }

            return users;
        }

        public CallOperators GetMatchingCallOperator()
        {
            CallOperators callOp = new CallOperators();
            List<CallOperators> callOps = callOp.GetCallOperators();

            var results = from ops in callOps where ops.PersonContact.Email == this.Email select ops;
            if (results!=null)
            {
                foreach (CallOperators item in results)
                {
                    callOp = item;
                }
            }

            return callOp;
        }

        public bool TestLogin(ref User userObject)
        {
            User user =new User(userObject.Username,userObject.Password,"","","","");
            List<User> users = userObject.GetAllUsers();
            var item = (from u in users where u.Username == user.Username && u.Password == user.Password select u);
            if (item!=null)
            {
                foreach (var u in item)
                {
                    userObject = u;  
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RecoverPassword(User userObject)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("additionaladdress.tanya@gmail.com");
                mail.To.Add(userObject.Email);
                mail.Subject = "Password Recovery";
                mail.Body = string.Format(@"Dear {0},
                                           Your Password for the Sorceress Lodge application is: {1}", userObject.Username, userObject.Password);
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("additionaladdress.tanya", "AdditionalAddress1!");
                smtp.EnableSsl = true;

                smtp.Send(mail);
                return true;
            }
            catch (Exception)
            {
                CustomExceptions error = new CustomExceptions("The password email could not be sent to user: " + userObject.Username, "Email Error!");
                return false;
            }
        }

        
    }
}

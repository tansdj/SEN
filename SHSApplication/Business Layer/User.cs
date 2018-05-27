using Serverside.HelperLibraries;
using ServerSide;
using SHSApplication.Business_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public User(string username, string password, string name, string surname, string email)
        {
            this.Username = username;
            this.Password = password;
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
        }

        public User()
        {

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
            return (this.Username==u.Username)&&(this.Password==u.Password)&&(this.Name==u.Name)&&(this.Surname==u.Surname)&&(this.Email==u.Email);
        }

        public override int GetHashCode()
        {
            return this.Username.GetHashCode()^this.Password.GetHashCode()^this.Name.GetHashCode()^this.Surname.GetHashCode()^this.Email.GetHashCode();
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
                users.Add(u);
            }

            return users;
        }

        public bool TestLogin(User userObject)
        {
            throw new NotImplementedException();
        }

        public void RecoverPassword(User userObject)
        {
            throw new NotImplementedException();
        }
    }
}

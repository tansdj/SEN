using Serverside.HelperLibraries;
using ServerSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class User
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

        public void InsertUser()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> user_details = new Dictionary<string, string[]>();

            user_details.Add(DataAccesHelper.uUsername, new string[] { DataAccesHelper.typeString, this.Username });
            user_details.Add(DataAccesHelper.uPassword, new string[] { DataAccesHelper.typeString, this.Password });
            user_details.Add(DataAccesHelper.uName, new string[] { DataAccesHelper.typeString, this.Name });
            user_details.Add(DataAccesHelper.uSurname, new string[] { DataAccesHelper.typeString, this.Surname });
            user_details.Add(DataAccesHelper.uEmail, new string[] { DataAccesHelper.typeString, this.Email });

            dh.runQuery(DataAccesHelper.targetUsers, DataAccesHelper.requestInsert, user_details);
        }

        public void UpdateUser()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> user_details = new Dictionary<string, string[]>();

            user_details.Add(DataAccesHelper.uUsername, new string[] { DataAccesHelper.typeString, this.Username });
            user_details.Add(DataAccesHelper.uPassword, new string[] { DataAccesHelper.typeString, this.Password });
            user_details.Add(DataAccesHelper.uName, new string[] { DataAccesHelper.typeString, this.Name });
            user_details.Add(DataAccesHelper.uSurname, new string[] { DataAccesHelper.typeString, this.Surname });
            user_details.Add(DataAccesHelper.uEmail, new string[] { DataAccesHelper.typeString, this.Email });

            dh.runQuery(DataAccesHelper.targetUsers, DataAccesHelper.requestUpdate, user_details,DataAccesHelper.uEmail+" = '"+this.Email+"'");
        }

        public void RemoveUser()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> user_details = new Dictionary<string, string[]>();

            user_details.Add(DataAccesHelper.uUsername, new string[] { DataAccesHelper.typeString, this.Username });
            user_details.Add(DataAccesHelper.uPassword, new string[] { DataAccesHelper.typeString, this.Password });
            user_details.Add(DataAccesHelper.uName, new string[] { DataAccesHelper.typeString, this.Name });
            user_details.Add(DataAccesHelper.uSurname, new string[] { DataAccesHelper.typeString, this.Surname });
            user_details.Add(DataAccesHelper.uEmail, new string[] { DataAccesHelper.typeString, this.Email });

            dh.runQuery(DataAccesHelper.targetUsers, DataAccesHelper.requestDelete, user_details, DataAccesHelper.uEmail + " = '" + this.Email + "'");
        }

    }
}

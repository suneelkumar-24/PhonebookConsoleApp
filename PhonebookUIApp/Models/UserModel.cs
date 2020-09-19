using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace PhonebookUIApp.Models
{
    public class UserModel
    {
        public List<UserData> Users { get; set; }

        public List<UserPhoneBookData> PhoneBook { get; set; }
        
        public UserModel()
        {
            Users = new List<UserData>();
            PhoneBook = new List<UserPhoneBookData>();
        }

    }


    public class UserPhoneBookData
    {
        public UserData User { get; set; }

        public List<UserData> Contacts { get; set; }

    }
}
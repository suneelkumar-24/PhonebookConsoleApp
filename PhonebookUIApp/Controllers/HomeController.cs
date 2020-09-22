using DataAccessLayer;
using PhonebookUIApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhonebookUIApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //SQL Server

            SQLDALManager manager = new SQLDALManager("dbConnKey");
            DataTable allUsers = manager.executeStoreProcedure("getAllUser");

            List<UserData> usersList = new List<UserData>();
            List<UserPhoneBookData> phoneBooks = new List<UserPhoneBookData>();


            foreach(DataRow row in allUsers.Rows)
            {
                UserData user = new UserData
                {
                    UserId = Convert.ToInt32(row["user_id"]),
                    UserName = row["user_name"].ToString()
                };
                
                usersList.Add(user);


                DataTable contacts = manager.executeStoreProcedure("getContacts", new List<SqlParameter> { new SqlParameter("@userId", Convert.ToInt32(row["user_id"]))});


                List<UserData> contcts = new List<UserData>();

                foreach(DataRow contact in contacts.Rows)
                {
                    contcts.Add(new UserData
                    {
                        UserId = Convert.ToInt32(contact["user_id"]),
                        UserName = contact["user_name"].ToString()
                    });
                }

                phoneBooks.Add(new UserPhoneBookData { User = user, Contacts = contcts });
            };


            UserModel model = new UserModel
            {
                Users = usersList,
                PhoneBook = phoneBooks
            };


                ////////////////------------------------------------------------------------------
                //List<UserData> dummyUser = new List<UserData>
                //{
                //    new UserData { UserId = 1, UserName = "Alice" },
                //    new UserData { UserId = 2, UserName = "Bob" },
                //    new UserData { UserId = 3, UserName = "Michel" }
                //};

                //List<UserPhoneBookData> dummyPhonebook = new List<UserPhoneBookData>
                //{
                //    new UserPhoneBookData { User = dummyUser[0], Contacts = new List<UserData> { dummyUser[1], dummyUser[2] } },
                //    new UserPhoneBookData { User = dummyUser[1], Contacts= new List<UserData> {dummyUser[0],dummyUser[2]}}
                //};


                //UserModel model2 = new UserModel
                //{
                //    Users = dummyUser,
                //    PhoneBook = dummyPhonebook

                //};
                ///////////////////////////////////////---------------------------------------------




                return View(model);
            }



        [HttpPost]
        public ActionResult Create(UserModel data)
        {
            SQLDALManager manager = new SQLDALManager("dbConnKey");
            manager.executeStoreProcedure("insertUser", new List<SqlParameter> { new SqlParameter("@userName", data.newUser.UserName) });
            return RedirectToAction("Index");
        }
    }
}
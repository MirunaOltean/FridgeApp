using Project.Models;
using Project.Validators;
using Project.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Project.DataService
{
    public class SQLiteDataService
    {
        #region Private fields

        private HealthProfilePageViewModel healthProfilePageViewModel;
        private static SQLiteDataService sqliteDataService;
        private static SQLiteConnection database;

        #endregion

        #region Properties

        public static Person Person { get; set; }

        public static SQLiteDataService Instance => sqliteDataService ?? (sqliteDataService = new SQLiteDataService());


        public HealthProfilePageViewModel HealthProfilePageViewModel =>
            healthProfilePageViewModel ?? (healthProfilePageViewModel = PopulateData());

        #endregion

        public SQLiteDataService()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "SQLiteDB.db");
            database = new SQLiteConnection(path);

            //Create table if not exists
            //database.DropTable<Person>();
            database.CreateTable<Person>();


            if (database.Table<Person>().Count() == 0)
            {
                Person person;
                var assembly = typeof(App).GetTypeInfo().Assembly;

                using (var stream = assembly.GetManifestResourceStream("Project.Data.profile.json"))
                {
                    var serializer = new DataContractJsonSerializer(typeof(Person));
                    person = (Person)serializer.ReadObject(stream);
                }

                database.Insert(person);
            }
        }

        private static HealthProfilePageViewModel PopulateData()
        {
            HealthProfilePageViewModel data;

            var assembly = typeof(App).GetTypeInfo().Assembly;
            using (var stream = assembly.GetManifestResourceStream("Project.Data.cardItems.json"))
            {
                var serializer = new DataContractJsonSerializer(typeof(HealthProfilePageViewModel));
                data = (HealthProfilePageViewModel)serializer.ReadObject(stream);
            }
            data.Person = Person;
            return data;
        }

        internal Person LogInCheck(string email, string password)
        {
            Person = database.Table<Person>().Where(item => item.Email == email && item.Password == password).FirstOrDefault();
            if(Person == null)  
                return null;
            return Person;
        }

        internal void AddPerson(Person person)
        {
            database.Insert(person);
            Person = person;
            HealthProfilePageViewModel.Person = person;
        }
    }
}

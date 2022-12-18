using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Project.Models
{
    [Preserve(AllMembers = true)]
    public class Person
    {
        private string profileImage;

        [SQLite.AutoIncrement, SQLite.PrimaryKey]
        public int Id { get; set; }
        public string ProfileImage 
        {
            get => profileImage;
            set 
            {
                if (value.Contains("sync"))
                    profileImage = value;
                else profileImage = App.ImageServerPath + value;
            }
        }
        public string ProfileName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Person()
        {
            ProfileImage = "ProfileImage4.png";
            ProfileName = "";
            City = "";
            Country = "";
            Age = 0;
            Weight = "";
            Height = "";
            Email = "";
            Password = "";
        }
    }
}

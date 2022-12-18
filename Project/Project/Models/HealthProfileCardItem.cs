
using SQLite;
using System.Runtime.Serialization;

namespace Project.Models
{
    [Preserve(AllMembers = true)]
    [DataContract]
    public class HealthProfileCardItem
    {
        [DataMember(Name = "Category")]
        public string Category { get; set; }
        [DataMember(Name = "CategoryValue")]
        public string CategoryValue { get; set; }
        [DataMember(Name = "CategoryImage")]
        public string CategoryImage { get; set; }

    }
}

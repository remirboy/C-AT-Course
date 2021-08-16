using address_book_web.DBModels;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace address_book_web.Models
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>,IComparable<GroupData> 
    {
        private string groupName;
        private string groupHeader;
        private string groupFooter;

        [Column(Name = "group_id"),PrimaryKey,Identity]
        public string Id { get; set; }

        [Column(Name = "group_name")]
        public string GroupName
        {
            get
            {
                return groupName;
            }
            set
            {
                groupName = value;
            }
        }

        [Column(Name = "group_header")]
        public string GroupHeader
        {
            get
            {
                return groupHeader;
            }
            set
            {
                groupHeader = value;
            }
        }

        [Column(Name = "group_footer")]
        public string GroupFooter
        {
            get
            {
                return groupFooter;
            }
            set
            {
                groupFooter = value;
            }
        }

        public GroupData(string groupName, string groupHeader, string groupFooter)
        {
            this.groupName = groupName;
            this.groupHeader = groupHeader;
            this.groupFooter = groupFooter;
        }

        public GroupData(string groupName)
        {
            this.groupName = groupName;
        }

        public GroupData() { }

        public static List<GroupData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }

        public int CompareTo(GroupData group)
        {
            if (Object.ReferenceEquals(null, group))
                return 1;
            return GroupName.CompareTo(group.GroupName);

        }

        public bool Equals(GroupData otherGroup)
        {
            if (Object.ReferenceEquals(otherGroup, null))
                return false;
            if (Object.ReferenceEquals(this, otherGroup))
                return true;
            return GroupName == otherGroup.GroupName;
        }

        public override int GetHashCode()
        {
            return GroupName.GetHashCode();
        }

        public override string ToString()
        {
            return "name:"+ GroupName;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace address_book_web.Models
{
    public class GroupData : IEquatable<GroupData>,IComparable<GroupData> 
    {
        private string groupName;
        private string groupHeader;
        private string groupFooter;

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

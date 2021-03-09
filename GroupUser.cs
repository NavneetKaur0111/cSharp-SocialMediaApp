using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public class GroupUser
    {
        public GroupUser(User user, Group group)
        {
            this.User = user;
            this.Group = group;
        }
        public User User { get; set; }
        public Group Group { get; set; }
    }
}

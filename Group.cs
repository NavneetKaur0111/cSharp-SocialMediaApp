using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public class Group
    {

        public Group(string name)
        {
            this.Name = name;
            this.Users = new HashSet<GroupUser>();
            this.Posts = new List<Post>();
        }
        public string Name { get; set; }
        public HashSet<GroupUser> Users { get; set; }
        public List<Post> Posts { get; set; }
    }
}

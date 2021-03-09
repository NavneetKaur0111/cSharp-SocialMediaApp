using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class App
    {
        public App(string name)
        {
            this.Name = name;
            this.Groups = new List<Group>();
            this.Users = new List<User>();
        }
        public string Name { get; set; }
        public List<Group> Groups { get; set; }
        public List<User> Users { get; set; }

        public User CreateUser(string Name)
        {
            User user = new User(Name);
            Users.Add(user);
            return user;
        }
        public Group CreateGroup(string Name)
        {
            Group group = new Group(Name);
            Groups.Add(group);
            return group;
        }
        public User MostPopularUser()
        {
            User result = Users[0];
            int highestCommentCount = 0;

            foreach (var user in Users)
            {
                if (user.Posts.Count > 0)
                {
                    if (user.PostWithMostComments() != null)
                    {
                        int CommentCount = user.PostWithMostComments().Comments.Count;
                        if (CommentCount > highestCommentCount)
                        {
                            highestCommentCount = CommentCount;
                            result = user;
                        }
                    }
                }
                 else
                {
                    throw new emptyException("Sorry, there are no posts for this user.");
                }
            }

            return result;
        }
        public List<User> UsersWithHatedPosts(int n)
        {
            List<User> result = new List<User>();
            foreach (var user in Users)
            {
                if (user.NumberOfHatedPosts() >= n)
                    result.Add(user);
            }
            return result;
        }
    }
}

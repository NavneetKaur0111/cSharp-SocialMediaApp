using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public class User
    {
        public User(string name)
        {
            this.Name = name;
            this.Posts = new List<Post>();
            this.Groups = new HashSet<GroupUser>();
        }
        public string Name { get; set; }
        public List<Post> Posts { get; set; }
        public HashSet<GroupUser> Groups { get; set; }

        public Post MakeAPost(string Title, Group group)
        {
            GroupUser groupUser = new GroupUser(this, group);
            AddGroup(groupUser, group);
            Post post = new Post(Title, this, group);
            Posts.Add(post);
            return post;
        }
        public void AddGroup(GroupUser newgroupUser, Group group)
        {
            foreach (var groupUser in Groups)
            {
                if (groupUser.Group.Name.Equals(newgroupUser.Group.Name))
                    return;
            }
            this.Groups.Add(newgroupUser);
            group.Users.Add(newgroupUser);
        }
        public void PrintPosts()
        {
            if (Posts.Count < 1)
                Console.WriteLine("Sorry, this user have no posts");
            else
            {
                foreach (var post in Posts)
                {
                    post.PrintPost();
                }
            }
        }
        public void PrintPostsWithComments()
        {
            if (Posts.Count < 1)
                Console.WriteLine("Sorry, this user have no posts");
            else
            {
                foreach (var post in Posts)
                {
                    post.PrintPostWithComments();
                }
            }
        }
        public Post PostWithMostComments()
        {
            if (Posts.Count > 0)
            {
                Post result = null;
                int highestCommentCount = 0;

                foreach (var post in Posts)
                    if (highestCommentCount < post.Comments.Count)
                    {
                        highestCommentCount = post.Comments.Count;
                        result = post;
                    }

                return result;
            }
            else
            {
                Console.WriteLine("sorry, this user didn't post anything yet.");
                return null;
            }
        }
        public List<Post> PostsWithTopReactionLove()
        {
            List<Post> result = new List<Post>();
            foreach (var post in Posts)
            {
                if (post.TopReaction() == Type.Love)
                {
                    result.Add(post);
                }
            }
            return result;
        }
        public int NumberOfHatedPosts()
        {
            int result = 0;
            foreach (var post in Posts)
            {
                if (post.TopReaction() == Type.Hate)
                {
                    result++;
                }
            }
            return result;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}

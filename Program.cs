using System;
using System.Collections.Generic;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            // Make an app 
            App app = new App("app");

            //  Make Users
            User user1 = app.CreateUser("user1");
            User user2 = app.CreateUser("user2");
            User user3 = app.CreateUser("user3");
            User user4 = app.CreateUser("user4");
            User user5 = app.CreateUser("user5");
            User user6 = app.CreateUser("user6");
            User user7 = app.CreateUser("user7");
            User user8 = app.CreateUser("user8");
            User user9 = app.CreateUser("user9");
            User user10 = app.CreateUser("user10");

            //Make Groups
            Group group1 = app.CreateGroup("group1");
            Group group2 = app.CreateGroup("group2");
            Group group3 = app.CreateGroup("group3");
            Group group4 = app.CreateGroup("group4");
            Group group5 = app.CreateGroup("group5");

            //postSomething
            Post post1 = user1.MakeAPost("Hello EveryOne", group1);
            Post post2 = user1.MakeAPost("Good Morning", group1);
            Post post3 = user2.MakeAPost("Good afternoon", group3);
            Post post4 = user2.MakeAPost("Good evening", group4);
            Post post5 = user2.MakeAPost("Good night", group5);


            //ReactOnpost
            post2.AddReaction(user2, Type.Love);
            post2.AddReaction(user2, Type.Like);
            post2.AddReaction(user2, Type.Like);
            post2.AddReaction(user3, Type.Surprize);
            post2.AddReaction(user6, Type.Love);
            post2.AddReaction(user8, Type.Love);
            post2.AddReaction(user9, Type.Love);
            post1.AddReaction(user4, Type.Like);
            post1.AddReaction(user5, Type.Like);
            post1.AddReaction(user6, Type.Like);
            post1.AddReaction(user7, Type.Like);
            post1.AddReaction(user8, Type.Like);
            post3.AddReaction(user9, Type.Hate);
            post4.AddReaction(user9, Type.Hate);
            post5.AddReaction(user9, Type.Hate);
            post5.AddReaction(user9, Type.Hate);

            //addcomments
            post1.AddComment("hi, how are you");
            post1.AddComment(null);
            post1.AddComment("");
            post1.AddComment("hi, how are you");
            post1.AddComment("hi, how are you");
            post1.AddComment("hi, how are you");

            try
            {

                //Printpost 
                user1.PrintPosts();

                //PrintPost With Comments
                Console.WriteLine("\n\nPosts With Comments: \n");
                user1.PrintPostsWithComments();

                //show user his highest comments post
                Console.WriteLine(user1.PostWithMostComments());

                //mostpopularUser
                Console.WriteLine(app.MostPopularUser());

                // TopReaction
                if (post2.Reactions.Count > 0)
                {
                    Console.WriteLine(post2.TopReaction());
                }

                //posts with top reaction love
                Console.WriteLine("\nposts with top reaction love");
                printList(user1.PostsWithTopReactionLove());

                //users with at least 3 hated posts
                printList(app.UsersWithHatedPosts(3));
            }
            catch (emptyException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public static void printList(List<User> list)
        {
            foreach (var user in list)
                Console.WriteLine(user);
        }

        public static void printList(List<Post> list)
        {
            foreach (var post in list)
                Console.WriteLine(post);
        }
    }
}

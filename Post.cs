using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public class Post
    {
        public Post(string title, User user, Group group)
        {
            this.Title = title;
            this.User = user;
            this.Group = group;
            this.DateCreated = DateTime.Now;
            this.Comments = new List<string>();
            this.Reactions = new List<Reaction>();
        }
        public string Title { get; set; }
        public User User { get; set; }
        public Group Group { get; set; }
        public DateTime DateCreated { get; set; }
        public List<string> Comments { get; set; }
        public List<Reaction> Reactions { get; set; }

        public void PrintPost()
        {
            Console.WriteLine($"{Title} by {User}\n\t-{DateCreated}");
        }
        public void PrintPostWithComments()
        {
            PrintPost();
            Console.WriteLine($"Comments:");

            if (Comments.Count < 1)
                Console.WriteLine("Nobody Commented on this post yet.");
            else
                foreach (var comment in Comments)
                {
                    Console.WriteLine($"{comment}");
                }
            Console.WriteLine("\n");
        }
        public void AddComment(string comment)
        {
            if (!String.IsNullOrEmpty(comment))
                this.Comments.Add(comment);
        }
        public void AddReaction(User user, Type type)
        {
            Reaction newReaction = new Reaction(this, user, type);
            if (Reactions.Count == 0)
                this.Reactions.Add(newReaction);
            else
            {
                foreach (var reaction in Reactions)
                {
                    if (reaction.UserWhoReacted == user)
                    {
                        if (reaction.ReactionType == type)
                            Reactions.Remove(reaction);
                        else
                            reaction.ReactionType = type;
                        return;
                    }
                }
                this.Reactions.Add(newReaction);
            }
        }
        public Type TopReaction()
        {
            if (Reactions.Count == 0)
                throw new emptyException("There are no reactions in this post.");

            Dictionary<Type, int> reactionDict = new Dictionary<Type, int>();
            foreach (var reaction in Reactions)
            {
                if (reactionDict.ContainsKey(reaction.ReactionType))
                {
                    reactionDict[reaction.ReactionType]++;
                }
                else
                {
                    reactionDict.Add(reaction.ReactionType, 1);
                }
            }

            Type result = Reactions[0].ReactionType;
            int highestReactionCount = 0;
            foreach (var reaction in reactionDict)
            {
                if (reaction.Value > highestReactionCount)
                {
                    highestReactionCount = reaction.Value;
                    result = reaction.Key;
                }
            }

            return result;

        }
        public override string ToString()
        {
            return Title;
        }
    }
}

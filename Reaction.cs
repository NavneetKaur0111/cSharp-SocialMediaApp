using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public enum Type
    {
        Like,
        Hate,
        Love,
        Surprize
    }
    public class Reaction
    {
        public Reaction(Post post, User user, Type reactionType)
        {
            this.Post = post;
            this.UserWhoReacted = user;
            this.ReactionType = reactionType; 
        }
        public Post Post { get; set; }
        public User UserWhoReacted { get; set; }
        public Type ReactionType { get; set; }
        public override string ToString()
        {
            return $"{this.ReactionType}";
        }
    }
}

using FollowersPark.DataAccess.Tables.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FollowersPark.DataAccess.Tables
{
    public class Task : EntityBase
    {
        public int TaskId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public virtual ICollection<Log> Logs { get; set; } = new HashSet<Log>();

        //
        public byte Action { get; set; }

        public byte Resource { get; set; }
        public bool Status { get; set; }
        public byte UnfollowOption { get; set; }
        public byte WhereUserResource { get; set; }

        //[MaxLength(255)]
        //public string InstagramUserId { get; set; }

        public byte DirectMessageSource { get; set; }
        public string GeoraphicalLocations { get; set; }//array
        public string PostsShortCode { get; set; }//array
        public string UserList { get; set; }//array

        [MaxLength(255)]
        public string Username { get; set; }
        public string Hashtags { get; set; }
        public bool InteractWithPosts { get; set; }
        public byte InteractWithPostsDays { get; set; }
        public int IntervalSpeed { get; set; }
        public bool IsDeleteAfterSendingMessage { get; set; }
        public bool IsSkipSentMessage { get; set; }
        public short MaximumNumberTransactions { get; set; }
        public short NumberTransactions { get; set; }
        public int? DirectMessageId { get; set; }
        public virtual DirectMessage DirectMessage { get; set; }
    }
}
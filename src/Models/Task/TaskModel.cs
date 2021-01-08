using FollowersPark.Models.DirectMessage;
using System.Collections.Generic;

namespace FollowersPark.Models.Task
{
    public class TaskModel
    {
        public int TaskId { get; set; }

        //
        public byte Action { get; set; }

        public byte Resource { get; set; }
        public bool Status { get; set; }
        public byte UnfollowOption { get; set; }
        public byte WhereUserResource { get; set; }

        //[Required]
        //[MaxLength(255)]
        //[JsonProperty("userId")]
        //public string InstagramUserId { get; set; }

        public byte DirectMessageSource { get; set; }
        public IEnumerable<string> GeoraphicalLocations { get; set; }//array
        public IEnumerable<string> PostsShortCode { get; set; }//array
        public IEnumerable<string> UserList { get; set; }//array
        public IEnumerable<string> Hashtags { get; set; }//array

        //[Required]
        //[MaxLength(255)]
        public string Username { get; set; }

        public bool InteractWithPosts { get; set; }
        public byte InteractWithPostsDays { get; set; }
        public int IntervalSpeed { get; set; }
        public bool IsDeleteAfterSendingMessage { get; set; }
        public bool IsSkipSentMessage { get; set; }
        public short MaximumNumberTransactions { get; set; }
        public short NumberTransactions { get; set; }

        public int? DirectMessageId { get; set; }
        public List<DirectMessageTaskModel> DirectMessages { get; set; }
    }
}
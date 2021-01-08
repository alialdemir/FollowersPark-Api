using FollowersPark.DataAccess.Tables.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FollowersPark.DataAccess.Tables
{
    public class DirectMessage : EntityBase
    {
        public int DirectMessageId { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        [MaxLength(255)]
        public string ListName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Messages { get; set; }

        public virtual ICollection<Task> Tasks { get; set; } = new HashSet<Task>();
    }
}
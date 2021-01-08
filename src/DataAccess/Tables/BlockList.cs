using FollowersPark.DataAccess.Tables.Entity;
using System.ComponentModel.DataAnnotations;

namespace FollowersPark.DataAccess.Tables
{
    public class BlockList : EntityBase
    {
        public int BlockListId { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        [MaxLength(255)]
        public string ListName { get; set; }

        public string Usernames { get; set; }
    }
}
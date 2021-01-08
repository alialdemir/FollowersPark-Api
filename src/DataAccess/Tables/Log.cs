using FollowersPark.DataAccess.Tables.Entity;
using System.ComponentModel.DataAnnotations;

namespace FollowersPark.DataAccess.Tables
{
    public class Log : EntityBase
    {
        public int LogId { get; set; }

        public string Status { get; set; }

        public int TaskId { get; set; }
        public virtual Task Task { get; set; }

        [Required]
        [MaxLength(255)]
        public string InstagramUserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string InstagramUserName { get; set; }

        public int ActionId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
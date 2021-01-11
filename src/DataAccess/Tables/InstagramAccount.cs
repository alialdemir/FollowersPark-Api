using FollowersPark.DataAccess.Tables.Entity;
using System.ComponentModel.DataAnnotations;

namespace FollowersPark.DataAccess.Tables
{
    public class InstagramAccount : EntityBase
    {
        public int InstagramAccountId { get; set; }

        [Required]
        [MaxLength(255)]
        public string InstagramId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Username { get; set; }

        [Required]
        [MaxLength(255)]
        public string Fullname { get; set; }
        [Required]
        [MaxLength(255)]
        public string CsrfToken { get; set; }

        public long FollowersCount { get; set; }

        public long FollowingCount { get; set; }

        public bool IsVerified { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
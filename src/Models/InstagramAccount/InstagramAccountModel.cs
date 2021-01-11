using System.ComponentModel.DataAnnotations;

namespace FollowersPark.Models.InstagramAccount
{
    public class InstagramAccountModel
    {
        [Required]
        [MaxLength(255)]
        public string InstagramId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Username { get; set; }

        [Required]
        [MaxLength(255)]
        public string Fullname { get; set; }

        public long FollowersCount { get; set; }

        public long FollowingCount { get; set; }

        public bool IsVerified { get; set; }
        [Required]
        [MaxLength(255)]
        public string CsrfToken { get; set; }
    }
}
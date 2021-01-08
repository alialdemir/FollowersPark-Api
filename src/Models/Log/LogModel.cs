using System.ComponentModel.DataAnnotations;

namespace FollowersPark.Models.Log
{
    public class LogModel
    {
        public int LogId { get; set; }

        public string Status { get; set; }

        public int TaskId { get; set; }

        [Required]
        [MaxLength(255)]
        public string InstagramUserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string InstagramUserName { get; set; }

        public int ActionId { get; set; }
    }
}
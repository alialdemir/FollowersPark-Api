using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FollowersPark.Models.DirectMessage
{
    public class DirectMessageModel
    {
        public int DirectMessageId { get; set; }

        [Required]
        [MaxLength(255)]
        public string ListName { get; set; }

        public IEnumerable<MessageModel> DirectMessages { get; set; } = new List<MessageModel>();
    }
}
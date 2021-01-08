using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FollowersPark.Models.BlockList
{
    public class BlockListModel
    {
        public int BlockListId { get; set; }

        [Required]
        [MaxLength(255)]
        public string ListName { get; set; }

        public IEnumerable<string> Usernames { get; set; }
    }
}
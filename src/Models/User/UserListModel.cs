using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FollowersPark.Models.User
{
    public class UserListModel
    {
        public int UserListId { get; set; }

        [Required]
        [MaxLength(255)]
        public string ListName { get; set; }

        public IEnumerable<string> Usernames { get; set; }
    }
}
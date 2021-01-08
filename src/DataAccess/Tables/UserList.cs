using FollowersPark.DataAccess.Tables.Entity;
using System.ComponentModel.DataAnnotations;

namespace FollowersPark.DataAccess.Tables
{
    public class UserList : EntityBase
    {
        public int UserListId { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        [MaxLength(255)]
        public string ListName { get; set; }

        public string Usernames { get; set; }
    }
}
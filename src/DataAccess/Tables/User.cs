using FollowersPark.DataAccess.Tables.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace FollowersPark.DataAccess.Tables
{
    public class User : IdentityUser, IEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
        public bool Deleted { get; set; }
        public virtual ICollection<BlockList> BlockLists { get; set; } = new HashSet<BlockList>();
        public virtual ICollection<DirectMessage> DirectMessages { get; set; } = new HashSet<DirectMessage>();
        public virtual ICollection<Task> Tasks { get; set; } = new HashSet<Task>();
        public virtual ICollection<Log> Logs { get; set; } = new HashSet<Log>();
        public virtual ICollection<UserList> UserLists { get; set; } = new HashSet<UserList>();
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
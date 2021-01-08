using System;

namespace FollowersPark.DataAccess.Tables.Entity
{
    public class EntityBase : IEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }

        public bool Deleted { get; set; }
    }
}
using System;

namespace FollowersPark.DataAccess.Tables.Entity
{
    public interface IEntity
    {
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        bool Deleted { get; set; }
    }
}
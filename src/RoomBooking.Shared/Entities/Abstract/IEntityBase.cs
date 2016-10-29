using System;
using System.Linq.Expressions;

namespace RoomBooking.Shared.Entities.Abstract
{
    public interface IEntityBase
    {
        Guid Id { get; set; }

        Expression<Func<IEntityBase, object>>[] AllIncludingParams { get; set; }
    }
}
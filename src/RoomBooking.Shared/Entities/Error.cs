using RoomBooking.Shared.Entities.Abstract;
using System;
using System.Linq.Expressions;

namespace RoomBooking.Shared.Entities
{
    public class Error : IEntityBase
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime DateCreated { get; set; }
        public Expression<Func<IEntityBase, object>>[] AllIncludingParams { get; set; }
    }
}

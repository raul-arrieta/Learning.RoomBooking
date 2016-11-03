using System;
using System.Collections.Generic;
using RoomBooking.DataProvider.Repositories.Abstract;
using RoomBooking.Shared.Core;
using RoomBooking.Shared.Entities.Abstract;

namespace RoomBooking.Manager.Abstract
{
    public interface IManager<T, TRepo>
        where T : class, IEntityBase, new()
        where TRepo : class, IBaseRepository<T>
    {
        BaseResult Delete(Guid id);
        T Get(Guid? id);
        List<T> Get(int? page, int? pageSize, out int totalCount);
    }
}
using System.Linq;
using AutoMapper;
using RoomBooking.Models;
using RoomBooking.Shared.Entities;

namespace RoomBooking.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Room, RoomViewModel>();
            Mapper.CreateMap<Hotel, HotelViewModel>()
                .ForMember(vm => vm.TotalRooms, map => map.MapFrom(a => a.Rooms.Count))
                .ForMember(vm => vm.TotalRoomReservations,
                    map => map.MapFrom(a => a.Rooms.ToList().Sum(room => room.RoomReservations.Count)));
            Mapper.CreateMap<RoomReservation, RoomReservationViewModel>();
        }
    }
}
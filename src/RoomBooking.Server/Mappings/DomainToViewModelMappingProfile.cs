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
            Mapper.CreateMap<Hotel, HotelViewModel>();
            Mapper.CreateMap<RoomReservation, RoomReservationViewModel>();
        }
    }
}
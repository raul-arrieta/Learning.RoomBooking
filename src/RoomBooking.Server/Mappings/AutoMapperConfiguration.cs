﻿using AutoMapper;

namespace RoomBooking.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                //x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}
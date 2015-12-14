using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TrainBooking.DAL.Entities;
using TrainBooking.Models.RouteModels;

namespace TrainBooking.Mappings
{
    public class WebMapping
    {
        public static void CreateMappings()
        {
            Mapper.CreateMap<Route, RouteViewModel>()
                .ForMember(x => x.StartingStation, opt => opt.MapFrom(src => src.StartingStation.Station.Name))
                .ForMember(x => x.LastStation, opt => opt.MapFrom(src => src.LastStation.Station.Name))
                .ForMember(x => x.WayStations, opt => opt.MapFrom(src => src.WayStations.ToList()))
                .ForMember(x => x.EmptyPlaces, opt => opt.MapFrom(src => src.Wagons.Select(w => w.WagonType.NumberOfPlaces).Sum()))
                .ForMember(x => x.Price, opt => opt.MapFrom(src => src.FullPrice));

         
        }
    }
}
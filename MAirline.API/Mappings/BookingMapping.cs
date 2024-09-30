using AutoMapper;
using MAirline.API.Dtos;
using MAirline.API.Entities;

namespace MAirline.API.Mappings
{
    public class BookingMapping : Profile
    {
        public BookingMapping()
        {
            CreateMap<CreateBookingDto, Booking>().ReverseMap();
        }
    }
}
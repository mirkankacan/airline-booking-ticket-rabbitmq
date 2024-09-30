using AutoMapper;
using MAirline.API.Context;
using MAirline.API.Dtos;
using MAirline.API.Entities;

namespace MAirline.API.Services
{
    public class BookingService : IBookingService
    {
        private readonly MAirlineDbContext _context;
        private readonly IMapper _mapper;

        public BookingService(MAirlineDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateBookingAsync(CreateBookingDto createBookingDto)
        {
            var newBooking = _mapper.Map<Booking>(createBookingDto);
            await _context.Bookings.AddAsync(newBooking);
            await _context.SaveChangesAsync();
        }
    }
}
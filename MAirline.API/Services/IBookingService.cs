using MAirline.API.Dtos;

namespace MAirline.API.Services
{
    public interface IBookingService
    {
        Task CreateBookingAsync(CreateBookingDto createBookingDto);
    }
}
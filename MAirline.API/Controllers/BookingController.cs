using Bogus;
using MAirline.API.Dtos;
using MAirline.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace MAirline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMessageProducer _messageProducer;
        private readonly IBookingService _bookingService;

        public BookingController(IMessageProducer messageProducer, IBookingService bookingService)
        {
            _messageProducer = messageProducer;
            _bookingService = bookingService;
        }

        [HttpGet("CreateRandom100Booking")]
        public async Task<IActionResult> CreateRandom100Booking()
        {
            var faker = new Faker<CreateBookingDto>()
                 .RuleFor(x => x.PassangerName, f => f.Name.FullName())
                 .RuleFor(x => x.PassportNumber, f => f.Random.Replace("??######"))
                 .RuleFor(x => x.From, f => f.Address.Country())
                 .RuleFor(x => x.To, f => f.Address.Country())
                 .RuleFor(x => x.Status, f => f.Random.Int(0, 1));
            var fakerData = faker.Generate(100);

            foreach (var data in fakerData)
            {
                await _bookingService.CreateBookingAsync(data);
                await _messageProducer.SendingMessage(data);
            }

            return Ok("Booking has been created. Have a good flight.");
        }
    }
}
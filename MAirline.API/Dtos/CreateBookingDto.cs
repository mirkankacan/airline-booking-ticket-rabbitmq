namespace MAirline.API.Dtos
{
    public class CreateBookingDto
    {
        public string PassangerName { get; set; }
        public string PassportNumber { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Status { get; set; }
    }
}
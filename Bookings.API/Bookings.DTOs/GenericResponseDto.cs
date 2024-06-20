namespace Bookings.DTOs
{
    public class GenericResponseDto<TResult>
    {
        public bool Success { get; set; }
        public TResult? Result { get; set; }
    }
}
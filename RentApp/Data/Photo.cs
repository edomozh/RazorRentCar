namespace RentApp.Data
{
    public class Photo : BaseEntity
    {
        public byte[] Value { get; set; } = Array.Empty<byte>();
    }
}

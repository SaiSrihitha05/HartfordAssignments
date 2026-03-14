namespace ComplaintsApi.DTOs
{
    public class ComplaintResponseDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string CustomerName { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}
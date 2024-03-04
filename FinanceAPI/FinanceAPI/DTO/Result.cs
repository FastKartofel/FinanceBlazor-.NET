namespace FinanceAPI.DTO
{
    public class Result
    {
        public long V { get; set; } // Volume
        public decimal O { get; set; } // Open
        public decimal C { get; set; } // Close
        public decimal H { get; set; } // High
        public decimal L { get; set; } // Low
        public long T { get; set; } // Timestamp
    }
}

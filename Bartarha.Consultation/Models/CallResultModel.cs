namespace Bartarha.Consultation.Models
{
    public class CallResultModel
    {
        public string SessionId { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public int DurationInSeconds 
        {
            get
            {
                _ = int.TryParse(Duration, out var number);
                return number;
            }
        }
    }
}
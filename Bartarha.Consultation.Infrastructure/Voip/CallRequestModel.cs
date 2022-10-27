namespace Bartarha.Consultation.Infrastructure.Voip;

public class CallRequestModel
{
    public string Token { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public string Duration { get; set; } = string.Empty;
    public string CallBack { get; set; } = string.Empty;
    public string ExtraParams { get; } = "{}";
}
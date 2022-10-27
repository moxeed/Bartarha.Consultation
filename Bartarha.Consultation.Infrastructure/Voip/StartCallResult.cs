namespace Bartarha.Consultation.Infrastructure.Voip;

public class StartCallResultData
{
    public string SessionId { get; set; }
}

public class StartCallResult
{
    public bool Result { get; set; }
    public IEnumerable<StartCallResultData>? Data { get; set; }

    public string? TracingCode
    {
        get
        {
            if (Data.Any())
            {
                return Data.First().SessionId;
            }

            return null;
        }
    }
}
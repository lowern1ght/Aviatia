namespace AuthorizationService.Models.Authorization;

public class Result
{
    public ResultStatus? Status { get; set; }
    public string? DescriptionMessage { get; set; }
}

public enum ResultStatus
{
    Successes,
    Error,
}
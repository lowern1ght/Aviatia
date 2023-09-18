namespace AuthorizationService.Models.Authorization;

public class UserDto
{
    public string? Email { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? PasswordConfirmation { get; set; }
}
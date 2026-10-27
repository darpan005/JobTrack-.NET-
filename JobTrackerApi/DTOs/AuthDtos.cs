using System.ComponentModel.DataAnnotations;

namespace JobTrackerApi.DTOs;

public class RegisterDto
{
    [Required]
    public string Name {get; set;}=string.Empty;
    
    [Required,EmailAddress]
    public string Email {get; set;}=string.Empty;

    [Required,MinLength(8)]
    public string Password {get; set;}=string.Empty;
}

public class LoginDto
{
    [Required, EmailAddress]
    public string Email {get; set;}=string.Empty;

    [Required]
    public string Password {get; set;}= string.Empty;
}
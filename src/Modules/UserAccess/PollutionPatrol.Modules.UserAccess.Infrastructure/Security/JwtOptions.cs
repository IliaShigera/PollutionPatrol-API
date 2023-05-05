namespace PollutionPatrol.Modules.UserAccess.Infrastructure.Security;

public sealed class JwtOptions
{
    public const string SectionName = "JwtOptions";
    
    [Required]
    public string SecretKey { get; set; }
    
    
    [Required]
    public string Issuer { get; set; }
    
    
    [Required]
    public string Audience { get; set; }
    
    
    [Required, Range(1, 60)]
    public int ExpirationTimeInMinutes { get; set; }
}
namespace PollutionPatrol.BuildingBlocks.Notification.Email;

public sealed class EmailOptions
{
    public const string Section = "EmailOptions";
    
    [Required, EmailAddress]
    public string EmailAddress { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Password { get; set; }

    
    [Required]
    public string Host { get; set; }
    
    
    [Required]
    public int Port { get; set; }
}
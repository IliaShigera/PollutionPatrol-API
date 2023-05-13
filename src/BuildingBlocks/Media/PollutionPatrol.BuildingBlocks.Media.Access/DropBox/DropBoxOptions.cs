namespace PollutionPatrol.BuildingBlocks.Media.Access.DropBox;

public sealed class DropBoxOptions
{
    public const string Section = "External:DropBox";
    
    [Required]
    public string AppKey { get; set; }
    
    
    [Required]
    public string AppSecret { get; set; }
    
    
    [Required]
    public string AuthToken { get; set; }
}
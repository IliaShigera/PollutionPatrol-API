namespace PollutionPatrol.Modules.UserAccess.Infrastructure.Security;

internal sealed class ConfirmationCodeGenerator : IConfirmationCodeGenerator
{
    private const int CodeLength = 6;

    public string GenerateConfirmationCode()
    {
        // using var sha256 = SHA512.Create();
        // var data = Encoding.UTF8.GetBytes(userId);
        // var hash = sha256.ComputeHash(data);
        // var code = BitConverter.ToString(hash).Replace("-", "");
        var code = $"{Guid.NewGuid()}".Substring(startIndex: 0, CodeLength);
        return code;
    }
}
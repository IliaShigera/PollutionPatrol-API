namespace PollutionPatrol.Modules.UserAccess.Infrastructure.Security;

internal sealed class TokenClaimsService : ITokenClaimsService
{
    private readonly JwtOptions _jwtOptions;

    public TokenClaimsService(IOptions<JwtOptions> options) => _jwtOptions = options.Value;

    public string GenerateToken(ApplicationUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(CustomClaimTypes.UserId, $"{user.Id}")
        };

        foreach (var role in user.Roles)
            claims.Add(new Claim(CustomClaimTypes.Roles, role.Value));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims.ToArray()),
            Issuer = _jwtOptions.Issuer,
            Audience = _jwtOptions.Audience,
            Expires = DateTime.Now.AddMinutes(_jwtOptions.ExpirationTimeInMinutes),
            SigningCredentials = signinCredentials
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
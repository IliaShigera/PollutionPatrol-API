namespace PollutionPatrol.Modules.UserAccess.Infrastructure.Security;

internal sealed class TokenClaimsService : ITokenClaimsService
{
    private readonly JwtOptions _jwtOptions;

    public TokenClaimsService(IOptions<JwtOptions> options) => _jwtOptions = options.Value;

    public string GenerateAccessToken(ApplicationUser user)
    {
        if (user is null)
            throw new ArgumentNullException(nameof(user), "User cannot be null");

        var tokenHandler = new JwtSecurityTokenHandler();
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(CustomClaimTypes.UserId, $"{user.Id}"),
            new Claim(CustomClaimTypes.EmailAddress, $"{user.EmailAddress}")
        };

        foreach (var role in user.Roles)
            claims.Add(new Claim(CustomClaimTypes.Roles, role.Value));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims.ToArray()),
            Issuer = _jwtOptions.Issuer,
            Audience = _jwtOptions.Audience,
            Expires = DateTime.UtcNow.AddMinutes(_jwtOptions.AccessTokenExpirationTimeInMinutes),
            SigningCredentials = signinCredentials
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public ClaimsPrincipal ValidateExpiredToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
            throw new ArgumentNullException(nameof(token), "Access token cannot be null or empty");

        var tokenHandler = new JwtSecurityTokenHandler();
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = false,
            ValidIssuer = _jwtOptions.Issuer,
            ValidAudience = _jwtOptions.Audience,
            IssuerSigningKey = secretKey,
        };

        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (securityToken is null || !jwtSecurityToken!.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Failed to validate token: invalid token.");

        return principal;
    }

    public Guid GetUserIdFromPrincipal(ClaimsPrincipal principal)
    {
        var claim = principal.FindFirst(CustomClaimTypes.UserId);
        if (claim is null)
            throw new SecurityTokenException("User ID claim not found in token.");

        if (!Guid.TryParse(claim.Value, out var userId))
            throw new SecurityTokenException("User ID claim has invalid value.");

        return userId;
    }

    public RefreshToken GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return new RefreshToken(
            value: Convert.ToBase64String(randomNumber),
            creationDate: DateTime.UtcNow,
            expirationDate: DateTime.UtcNow.AddDays(_jwtOptions.RefreshTokenExpirationTimeInDays)
        );
    }
}
namespace planit.Persistance.Tokens;
public class JWTConfiguration
{

    public string Secret { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int TokenExpirationInMinutes { get; set; }
    // public int RefreshExpirationInDays { get; set; }
}

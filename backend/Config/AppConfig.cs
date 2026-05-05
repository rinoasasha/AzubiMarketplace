namespace backend.Config;

public class AppConfig
{
    public MySqlDbConfig Database { get; set; } = new MySqlDbConfig();
    public OAuthConfig OAuth { get; set; } = new OAuthConfig();
}
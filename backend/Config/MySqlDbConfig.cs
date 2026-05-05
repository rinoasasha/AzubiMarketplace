namespace backend.Config;

public class MySqlDbConfig
{
    public string Host { get; set; } = "localhost";
    public int Port { get; set; } = 3306;
    public string Database { get; set; } = "AzubiMarketplace";
    public string Username { get; set; } = "root";
    public string Password { get; set; } = "";
    public string ConnectionString => $"Server={Host};Port={Port};Database={Database};Uid={Username};Pwd={Password};";
}
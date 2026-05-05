namespace backend.Config;

public class OAuthConfig
{
    public string ClientId { get; set; } = "733ad3f5-f26b-4c69-8ac1-c88d69a22992";
    public string ClientSecret { get; set; } = Guid.NewGuid().ToString("N");
    public string TenantId { get; set; } = "0ae51e19-07c8-4e4b-bb6d-648ee58410f4";

    public string MetaDataAddress { get; set; } =
        "https://login.microsoftonline.com/0ae51e19-07c8-4e4b-bb6d-648ee58410f4/v2.0/.well-known/openid-configuration";
    public string Scopes { get; set; } = "openid profile email ProfilePhoto.Read.All";
}
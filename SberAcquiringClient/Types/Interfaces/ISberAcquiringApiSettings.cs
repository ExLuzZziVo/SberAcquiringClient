namespace SberAcquiringClient.Types.Interfaces
{
    public interface ISberAcquiringApiSettings
    {
        string UserName { get; set; }

        string Password { get; set; }

        string Token { get; set; }

        string ApiHost { get; set; }
    }
}
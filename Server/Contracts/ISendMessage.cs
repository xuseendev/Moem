namespace MoeSystem.Server.Contracts
{
    public interface ISendMessage
    {
        Task SendSms(string body,string phone);
    }
}

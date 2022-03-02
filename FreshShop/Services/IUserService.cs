namespace FreshShop.Services
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}
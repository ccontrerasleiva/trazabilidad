using Microsoft.IdentityModel.Clients.ActiveDirectory;

//security
namespace Services.Security
{
    public interface IADALTokenCacheService
    {
        void Clear(ADALTokenCache token);
        void BeforeAccessNotification(TokenCacheNotificationArgs args);
        void AfterAccessNotification(TokenCacheNotificationArgs args);
        void BeforeWriteNotification(TokenCacheNotificationArgs args);
        //void DeleteItem(TokenCacheItem item);
    }
}

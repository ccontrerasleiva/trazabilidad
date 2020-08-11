namespace Services.Security
{
    using Data.Extensions.Interfaces;
    using Domain.Models;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Services.Extensions;
    using System.Linq;

    public class ADALTokenCache : TokenCache
    {
        //UserId
        public string userId;
        private UserTokenCache Cache;

        public ADALTokenCache(string signedInUserId)
        {
            // associate the cache to the current user of the web app
            userId = signedInUserId;
            //AfterAccess = AfterAccessNotification;
            //BeforeAccess = BeforeAccessNotification;
            //BeforeWrite = BeforeWriteNotification;
            // look up the entry in the database
            //Cache = db.UserTokenCacheList.FirstOrDefault(c => c.WebUserUniqueId == userId);
            //// place the entry in memory
            //this.Deserialize((Cache == null) ? null : MachineKey.Unprotect(Cache.CacheBits,"ADALCache"));
        }
    }

    //public class ADALTokenCacheService : BaseService<UserTokenCache>, IADALTokenCacheService
    //{
    //    public ADALTokenCacheService(IBaseRepository<UserTokenCache> baseRepo) : base(baseRepo)
    //    {
    //    }

    //    public void AfterAccessNotification(TokenCacheNotificationArgs args)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public void BeforeAccessNotification(TokenCacheNotificationArgs args)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public void BeforeWriteNotification(TokenCacheNotificationArgs args)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public void Clear(ADALTokenCache token)
    //    {
    //        token.Clear();
    //        var cacheEntry = _repository.Get().FirstOrDefault(tk=> tk.WebUserUniqueId.Equals(token.userId));
    //        _repository.Delete(cacheEntry);
    //        _repository.SaveChangesAsync();
    //    }
    //}
}
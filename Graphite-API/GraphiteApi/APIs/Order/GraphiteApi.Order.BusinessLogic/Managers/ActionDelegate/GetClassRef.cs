using GraphiteApi.Order.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphiteApi.Order.BusinessLogic.Managers.ActionDelegate
{
    public static class GetClassRef
    {
        #region ActionRef Events

        public static event ActionRef<OrderContext> OnGetDbContext;
        public static event ActionRef<HttpClient> OnGetHttpClient;

        #region Invokes

        public static void GetDbContext(ref OrderContext dbContext) => OnGetDbContext?.Invoke(ref dbContext);
        public static void GetHttpClient(ref HttpClient httpClient) => OnGetHttpClient?.Invoke(ref httpClient);

        #endregion

        #endregion
    }
}

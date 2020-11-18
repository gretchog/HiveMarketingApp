using DataProvider;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi
{
    public class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDBProvider, MongoDBProvider>();
        }
    }
}

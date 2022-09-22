using Microsoft.EntityFrameworkCore;
using TC.Products.RnR.Manager.Services;
using TC.Products.RnR.Repository.Data;
using TC.Products.RnR.Repository.Repository;

namespace TC.Products.RnR
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddHttpClient();
        }
    }
}

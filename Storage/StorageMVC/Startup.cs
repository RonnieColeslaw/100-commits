using StorageMVC.Controllers;
using Microsoft.EntityFrameworkCore;
using StorageMVC.Data;


public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<SharedServices>();
        services.AddControllersWithViews();

        services.AddDbContext<LegoContext>(options =>
     options.UseSqlServer(Configuration.GetConnectionString("LegoDb")));


    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            
            app.UseExceptionHandler("/Home/Error");
        }

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}

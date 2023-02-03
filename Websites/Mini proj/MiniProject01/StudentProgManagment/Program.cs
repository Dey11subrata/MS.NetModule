namespace StudentProgManagment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(10); //session timeout
                options.Cookie.HttpOnly = true; //whether client side script can access cookie. false means yes
                options.Cookie.IsEssential = true; //cookie will be always created if true
            });
            
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();
            

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "login",
                pattern: "{controller=Login}/{action=Create}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Students}/{action=Index}/{id?}");
            
          /*  app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Students}/{action=Index}/{id?}");*/
            

            app.Run();
        }
    }
}
namespace ProductReview
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();


        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        /*public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add_start
            builder.Services.AddControllersWithViews();

            //Add_End

            var app = builder.Build();
            //Update_Start
            //app.MapGet("/", () => "Hello World!");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Product}/{action=Index}/{id?}"
                );
            //Update_End
            app.Run();
        }*/
    }
}
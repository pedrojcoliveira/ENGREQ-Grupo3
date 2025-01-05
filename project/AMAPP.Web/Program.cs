namespace AMAPP.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register HttpClient with BaseAddress
            builder.Services.AddHttpClient("APIClient", client =>
            {
                //client.BaseAddress = new Uri("https://localhost:7237/"); 
                client.BaseAddress = new Uri("http://localhost:5143/"); //HTTP VERSION
            });
            
// Enable TempData with session-based storage
builder.Services.AddDistributedMemoryCache(); // Required for session state
builder.Services.AddSession(); // Add session support
builder.Services.AddHttpContextAccessor(); // Ensure TempData works

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

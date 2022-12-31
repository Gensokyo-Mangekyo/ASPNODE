var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddControllersWithViews(); // добавл€ем сервисы MVC
builder.Services.AddCors(options =>
{
   
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyHeader();//»з-за этой херни не работал JSON в ASP.NET
                          policy.AllowAnyOrigin(); //”казываем что можно обрабаывать любые запросы от приложений
                      });
});

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);



// устанавливаем сопоставление маршрутов с контроллерами
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
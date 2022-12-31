var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddControllersWithViews(); // ��������� ������� MVC
builder.Services.AddCors(options =>
{
   
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyHeader();//��-�� ���� ����� �� ������� JSON � ASP.NET
                          policy.AllowAnyOrigin(); //��������� ��� ����� ����������� ����� ������� �� ����������
                      });
});

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);



// ������������� ������������� ��������� � �������������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
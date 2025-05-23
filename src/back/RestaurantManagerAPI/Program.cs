using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString == "env")
    connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/api/funcionarios/login";
        options.AccessDeniedPath = "/api/funcionarios/nao-autorizado";
        options.Cookie.HttpOnly = true;
        options.Cookie.SameSite = SameSiteMode.Lax;
        options.Cookie.SecurePolicy = CookieSecurePolicy.None;
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Gerente", policy => policy.RequireRole("Gerente"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalNetwork", policy =>
    {
        policy.SetIsOriginAllowed(origin => 
                origin.StartsWith("http://192.168.") || 
                origin.Contains("restaurant-manager.local") || 
                origin.StartsWith("http://localhost"))
              .AllowCredentials() 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });
});

builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<ProdutoService>();
builder.Services.AddSignalR();

builder.WebHost.UseUrls("http://*:5000");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseCors("AllowLocalNetwork");
app.UseAuthentication();
app.UseAuthorization();
app.MapHub<PedidoHub>("/hub/pedidos");
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

app.Run();

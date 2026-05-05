using Microsoft.EntityFrameworkCore;

using SocialNetwork.Components;
using SocialNetwork.Repository;
using SocialNetwork.Repository.Interface;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IFriendRepository, FriendRepository>();
builder.Services.AddScoped<IGroupsRepository, GroupsRepository>();
builder.Services.AddControllers();

var app = builder.Build();

// middleware
/*app.MapGet("/", context =>
{
    context.Response.Redirect("api/friend");
    return Task.CompletedTask;
});*/

app.MapControllers();
app.UseDefaultFiles(); // ищет index.html
app.UseStaticFiles();
app.UseCors("AllowAll");
app.Run();
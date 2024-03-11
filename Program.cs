using Microsoft.EntityFrameworkCore;
using TutorialApi.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TutorialContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("TutorialContext")));
builder.Services.AddControllers();
var app = builder.Build();
app.UseCors(
        options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()
    );
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
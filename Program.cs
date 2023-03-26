using EmailSender.BL.Interfases;
using EmailSender.BL.Reposatories;
using EmailSender.DAL.Database;
using EmailSender.Mapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
 string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
    builder =>
    {
        builder.WithOrigins("http://localhost:5263",
                            "http://localhost:4200"
                            )
                            .AllowAnyHeader()
                            .AllowAnyMethod();
    });
});
builder.Services.AddDbContextPool<DbContainer>(opts =>
opts.UseSqlServer(
builder.Configuration.GetConnectionString("SharpDbConnection")
));

//builder.Services.AddCors(c =>
//{
//    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
//});

builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

builder.Services.AddScoped<IMessagesRep, MessagesRep>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);
//app.UseCors(x => x
//       .AllowAnyOrigin()
//       .AllowAnyMethod()
//       .AllowAnyHeader());

//app.UseHttpsRedirection();
//app.UseCors(options => options.AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();







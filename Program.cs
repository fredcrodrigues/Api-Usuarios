using Users;

var builder = WebApplication.CreateBuilder(args);

//Connection with mongo DB
builder.Services.Configure<UserDatabaseSettings>(
    builder.Configuration.GetSection("Cluster0")
);
// suprit the injections construct
builder.Services.AddSingleton<UserService>();
// Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

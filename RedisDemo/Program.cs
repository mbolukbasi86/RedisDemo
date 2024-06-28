using RedisDemo.Interfaces;
using RedisDemo.RedisConfiguration;
using RedisDemo.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


var redisConfig = builder.Configuration.GetSection("Redis").Get<RedisOptions>();
var multiplexer = ConnectionMultiplexer.Connect(redisConfig.ConnectionString);
builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRedisService, RedisService>();

//https://medium.com/@cihanacay/addtransient-addscoped-addsingleton-nedir-nas%C4%B1l-%C3%A7al%C4%B1%C5%9F%C4%B1r-aralar%C4%B1ndaki-fark-ne-3b738166bcdc
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

using WoodPelletsLib.repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(new WoodPelletRepository(true));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAny",
     builder => builder.AllowAnyOrigin().
     AllowAnyMethod().
    AllowAnyHeader()
     );

    options.AddPolicy("AllowOnlyGetPutPost",
    builder => builder.AllowAnyOrigin().
    WithMethods("GET", "PUT", "POST").
   AllowAnyHeader()
    );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors("AllowOnlyGetPutPost");

app.MapControllers();

app.Run();

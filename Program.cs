using SolomonsAdviceApi.RandomAdvice.Endpoints;
using SolomonsAdviceApi.ByIdAdvice.Endpoints;
var builder = WebApplication.CreateBuilder(args);

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
app.MapMethods(SolomonsAdviceGet.TemplateAdviceRandom, SolomonsAdviceGet.MetodoAdviceRandom, SolomonsAdviceGet.FuncAdviceRandom);
app.MapMethods(SolomonAdviceByIdGet.TemplateAdviceById, SolomonAdviceByIdGet.MetodoAdviceById, SolomonAdviceByIdGet.FuncAdviceById);
app.Run();

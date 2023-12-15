using SolomonsAdviceApi.Endpoints.RandomAdvice;
using SolomonsAdviceApi.Endpoints.ByIdAdvice;
using SolomonsAdviceApi.Endpoints.ByTextGet;
using SolomonsAdviceApi.Endpoints.AdvicePost;
using SolomonsAdviceApi.Endpoints.AdvicePut;
using SolomonsAdviceApi.Endpoints.AdviceDelete;

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
app.MapMethods(SolomonAdviceByTextGet.TemplateAdviceByText, SolomonAdviceByTextGet.MetodoAdviceByText, SolomonAdviceByTextGet.FuncAdviceByText);
app.MapMethods(SolomonAdvicePost.TemplateAdvicePost, SolomonAdvicePost.MetodoAdvicePost, SolomonAdvicePost.FuncAdvicePost);
app.MapMethods(SolomonAdvicePut.TemplateAdvicePut, SolomonAdvicePut.MetodoAdvicePut, SolomonAdvicePut.FuncAdvicePut);
app.MapMethods(SolomonAdviceDelete.TemplateAdviceDelete, SolomonAdviceDelete.MetodoAdviceDelete, SolomonAdviceDelete.FuncAdviceDelete);
app.Run();

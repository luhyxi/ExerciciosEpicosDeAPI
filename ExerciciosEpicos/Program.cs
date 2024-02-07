// Coisas random da API

using ExerciciosEpicos.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();





List<Imovel> imoveisLista = Enumerable.Range(1, 5).Select(_ => new Imovel()).ToList();

app.MapGet("/imovel", () =>
    {
        List<string> imovelInfos = new List<string>();
        foreach (var imovel in imoveisLista)
        {
            imovelInfos.Add(imovel.GetInfo());
        }
        return imovelInfos;
    })
    .WithName("VerImoveis")
    .WithOpenApi();

app.MapGet("/imovel/{id:int}", (int id) =>
    {
        return imoveisLista.FirstOrDefault(x => x.Id == id).GetInfo();
    })
    .WithName("VerImovelEspecificoViaID")
    .WithOpenApi();


app.MapPost("/imovel", () =>
    {
        imoveisLista.Add(new Imovel());
    })
    .WithName("GerarImovelAleatorio")
    .WithOpenApi();    
app.Run();

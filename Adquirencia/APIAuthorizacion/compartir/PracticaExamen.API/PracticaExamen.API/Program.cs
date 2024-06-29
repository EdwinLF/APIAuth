using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PracticaExamen.BW.CU;
using PracticaExamen.BW.Interfaces.BW;
using PracticaExamen.BW.Interfaces.DA;
using PracticaExamen.BW.Interfaces.SG;
using PracticaExamen.DA.Acciones;
using PracticaExamen.DA.Contexto;
using PracticaExamen.SG.Acciones;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddTransient<IManageAuthorizationBW, ManageAuthorizationBW>();
builder.Services.AddTransient<IManageAuthorizationDA, ManageAuthorizationDA>();
builder.Services.AddTransient<IManageGatewayBW, ManageGatewayBW>();
builder.Services.AddTransient<IManageGatewaySG, ManageGatewaySG>();
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));
builder.Services.AddSingleton<IMongoClient, MongoClient>(sp => new MongoClient(sp.GetRequiredService<IOptions<MongoDBSettings>>().Value.ConnectionString));
builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IMongoClient>().GetDatabase(
        sp.GetRequiredService<IOptions<MongoDBSettings>>().Value.DatabaseName));


var app = builder.Build();
/*
using (var scope = app.Services.CreateScope()) { 
    var context = scope.ServiceProvider.GetRequiredService<AdmUsuarioContext>();
    context.Database.Migrate();
}*/

// Configure the HTTP request pipeline.

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseAuthorization();

app.MapControllers();

app.Run();

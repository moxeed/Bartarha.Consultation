using Bartarha.Consultation.Common;
using Bartarha.Consultation.Core;
using Bartarha.Consultation.Infrastructure;
using Bartarha.Consultation.Infrastructure.Voip;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddDomainServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<VoipOptions>(builder.Configuration.GetSection(nameof(VoipOptions)));

var app = builder.Build();

app.MigrateDatabase();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
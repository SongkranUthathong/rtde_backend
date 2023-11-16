using System.Text.Json;

var rtde = new BackgroundRTED();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>{
options
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithOrigins("http://192.168.1.19:8080");
});

// app.UseCors(options =>{
//     options.WithOrigins("http://192.168.1.19:8080");
// });


app.UseHttpsRedirection();

app.MapPost("/connect", async (IPAddress iP) => new []{
    // Console.WriteLine( iP.ipAdd) ;
     JsonDocument.Parse(await rtde.rtdeConnect(iP.ipAdd))
    // new status_RTDE(await rtde.rtdeConnect("192.168.47.128"))
});
app.MapGet("/disconnect",async ()=> new[]{

    JsonDocument.Parse(await rtde.rtdeDisConnect())
});
app.MapGet("/preformance",()=> new[]{
    JsonDocument.Parse(rtde.act_Preformance())
});
app.MapGet("/steam",()=> new[]{
    JsonDocument.Parse(rtde.act_Steaming())
});
app.MapGet("/getConnection",()=> new[]{
    JsonDocument.Parse(rtde.getConnection())
});

app.Run();

// record preformance_rtde(JsonDocument actPreformance);
// record steam_rtde(JsonDocument actSteam);
record IPAddress(string ipAdd);

record connection_RTDE(string connection);
record actJ_RTED(double[] actJoint);

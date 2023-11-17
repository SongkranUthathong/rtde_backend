using System.Text.Json;

var rtdeWorker = new BackgroundRTED();
var builder = WebApplication.CreateBuilder(args);

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
app.UseHttpsRedirection();


#region |----------------[ Station 1 API ]--------------------|
app.MapPost("/station1/connect",  async (resIPAdd address) => new []{
     JsonDocument.Parse(await rtdeWorker.station1Connect(address.ipAdd))
    // new status_RTDE(await rtde.rtdeConnect("192.168.47.128"))
});
app.MapGet("/station1/disconnect",async ()=> new[]{

    JsonDocument.Parse(await rtdeWorker.station1Discconect())
});
app.MapGet("/station1/preformance",()=> new[]{
    JsonDocument.Parse(rtdeWorker.station1Preformance())
});
app.MapGet("/station1/steam",()=> new[]{
    JsonDocument.Parse(rtdeWorker.station1Steam())
});
app.MapGet("/station1/getConnection",()=> new[]{
    JsonDocument.Parse(rtdeWorker.getStation1Connection())
});
#endregion
#region |----------------[ Station 2 API ]--------------------|
app.MapPost("/station2/connect",  async (resIPAdd address) => new []{
     JsonDocument.Parse(await rtdeWorker.station2Connect(address.ipAdd))
    // new status_RTDE(await rtde.rtdeConnect("192.168.47.128"))
});
app.MapGet("/station2/disconnect",async ()=> new[]{

    JsonDocument.Parse(await rtdeWorker.station2Discconect())
});
app.MapGet("/station2/preformance",()=> new[]{
    JsonDocument.Parse(rtdeWorker.station2Preformance())
});
app.MapGet("/station2/steam",()=> new[]{
    JsonDocument.Parse(rtdeWorker.station2Steam())
});
app.MapGet("/station2/getConnection",()=> new[]{
    JsonDocument.Parse(rtdeWorker.getStation2Connection())
});
#endregion





app.Run();


record resIPAdd(string ipAdd);
record connection_RTDE(string connection);
record actJ_RTED(double[] actJoint);



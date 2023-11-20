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
app.MapGet("/station1/forcetorque",()=> new[]{
    JsonDocument.Parse(rtdeWorker.station1ForceTorque())
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
app.MapGet("/station2/forcetorque",()=> new[]{
    JsonDocument.Parse(rtdeWorker.station2ForceTorque())
});
#endregion

#region |----------------[ Station 3 API ]--------------------|
app.MapPost("/station3/connect",  async (resIPAdd address) => new []{
     JsonDocument.Parse(await rtdeWorker.station3Connect(address.ipAdd))
    // new status_RTDE(await rtde.rtdeConnect("192.168.47.128"))
});
app.MapGet("/station3/disconnect",async ()=> new[]{

    JsonDocument.Parse(await rtdeWorker.station3Discconect())
});
app.MapGet("/station3/preformance",()=> new[]{
    JsonDocument.Parse(rtdeWorker.station3Preformance())
});
app.MapGet("/station3/steam",()=> new[]{
    JsonDocument.Parse(rtdeWorker.station3Steam())
});
app.MapGet("/station3/getConnection",()=> new[]{
    JsonDocument.Parse(rtdeWorker.getStation3Connection())
});
app.MapGet("/station3/forcetorque",()=> new[]{
    JsonDocument.Parse(rtdeWorker.station3ForceTorque())
});
#endregion

#region |----------------[ Station 4 API ]--------------------|
app.MapPost("/station4/connect",  async (resIPAdd address) => new []{
     JsonDocument.Parse(await rtdeWorker.station4Connect(address.ipAdd))
    // new status_RTDE(await rtde.rtdeConnect("192.168.47.128"))
});
app.MapGet("/station4/disconnect",async ()=> new[]{

    JsonDocument.Parse(await rtdeWorker.station4Discconect())
});
app.MapGet("/station4/preformance",()=> new[]{
    JsonDocument.Parse(rtdeWorker.station4Preformance())
});
app.MapGet("/station4/steam",()=> new[]{
    JsonDocument.Parse(rtdeWorker.station4Steam())
});
app.MapGet("/station4/getConnection",()=> new[]{
    JsonDocument.Parse(rtdeWorker.getStation4Connection())
});
app.MapGet("/station4/forcetorque",()=> new[]{
    JsonDocument.Parse(rtdeWorker.station4ForceTorque())
});
#endregion

#region |----------------[ Station 5 API ]--------------------|
app.MapPost("/station5/connect",  async (resIPAdd address) => new []{
     JsonDocument.Parse(await rtdeWorker.station5Connect(address.ipAdd))
    // new status_RTDE(await rtde.rtdeConnect("192.168.47.128"))
});
app.MapGet("/station5/disconnect",async ()=> new[]{

    JsonDocument.Parse(await rtdeWorker.station5Discconect())
});
app.MapGet("/station5/preformance",()=> new[]{
    JsonDocument.Parse(rtdeWorker.station5Preformance())
});
app.MapGet("/station5/steam",()=> new[]{
    JsonDocument.Parse(rtdeWorker.station5Steam())
});
app.MapGet("/station5/getConnection",()=> new[]{
    JsonDocument.Parse(rtdeWorker.getStation5Connection())
});
app.MapGet("/station5/forcetorque",()=> new[]{
    JsonDocument.Parse(rtdeWorker.station5ForceTorque())
});
#endregion




app.Run();


record resIPAdd(string ipAdd);
record connection_RTDE(string connection);
record actJ_RTED(double[] actJoint);



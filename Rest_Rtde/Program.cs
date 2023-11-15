using System.Threading.Tasks;

var rtde = new BackgroundRTED();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.MapGet("/connect", async ()=> new[]{
     new status_RTDE(await rtde.rtdeConnect("192.168.47.128")) 
    // new status_RTDE(await rtde.rtdeConnect("192.168.47.128"))
});
app.MapGet("/disconnect",async ()=> new[]{
    new status_RTDE (await rtde.rtdeDisConnect())
});
app.MapGet("/getActual",()=> new[]{
    new actJ_RTED(rtde.actJoint())
});



app.Run();

record status_RTDE(bool status);
record actJ_RTED(double[] actJoint);

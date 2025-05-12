using Employee.Management.API.Data;
using Employee.Management.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("EmployeeManagement");
builder.Services.AddSqlite<EmployeeManagementContext>(connString);
var app = builder.Build();
app.MapEmployeeEnpoints();
await app.MigrateDbAsync();


app.Run();

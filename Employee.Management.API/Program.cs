using Employee.Management.API.Data;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("EmployeeManagement");
builder.Services.AddSqlite<EmployeeManagementContext>(connString);
var app = builder.Build();

await app.MigrateDbAsync();


app.Run();

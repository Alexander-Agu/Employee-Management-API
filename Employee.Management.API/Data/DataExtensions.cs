using System;
using Microsoft.EntityFrameworkCore;

namespace Employee.Management.API.Data;

public static class DataExtensions
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EmployeeManagementContext>();
        await dbContext.Database.MigrateAsync();
    }
}

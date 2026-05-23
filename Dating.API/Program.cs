// ------------------------------------------------------------------------------------------------
// Application Entry Point
// ------------------------------------------------------------------------------------------------

using Dating.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------------------------------------------------------------------------
// Service Container
// ------------------------------------------------------------------------------------------------

builder.Services.AddControllers();

builder.Services.AddDbContext<DatingSQLDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatingSQLDBConnection"));
});

var app = builder.Build();

// ------------------------------------------------------------------------------------------------
// HTTP Request Pipeline
// ------------------------------------------------------------------------------------------------

app.MapControllers();

app.Run();

// ------------------------------------------------------------------------------------------------
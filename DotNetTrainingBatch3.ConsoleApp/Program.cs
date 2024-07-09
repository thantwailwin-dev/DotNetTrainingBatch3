// See https://aka.ms/new-console-template for more information
/*Console.WriteLine("Hello, World!");
*/

using Serilog;
using Serilog.Sinks.MSSqlServer;

Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Debug()
           .WriteTo.Console()
           .WriteTo.File("logs/DotNetTrainingBatch3.ConsoleApp_.txt", rollingInterval: RollingInterval.Day)
           .WriteTo.MSSqlServer(connectionString: "Server=.;Database=AceInternship;User ID=sa;Password=twl@123;TrustServerCertificate=true;",
           sinkOptions: new MSSqlServerSinkOptions { TableName = "Tbl_LogEvents",AutoCreateSqlTable=true })
           .CreateLogger();

Log.Information("Hello, world!");

int a = 10, b = 0;
try
{
    Log.Debug("Dividing {A} by {B}", a, b);
    Console.WriteLine(a / b);
}
catch (Exception ex)
{
    Log.Error(ex, "Something went wrong");
}
finally
{
    await Log.CloseAndFlushAsync();
}

Console.ReadKey();
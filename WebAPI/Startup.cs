using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Serilog;
using Serilog.Sinks.MSSqlServer;

[assembly: OwinStartup(typeof(WebAPI.Startup))]

namespace WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            var TableName = "Logs";
            var columnOpts = new ColumnOptions();
            Log.Logger = new LoggerConfiguration()
           .WriteTo.MSSqlServer(
               connectionString: "Server=DESKTOP-HJHKJJL\\SQLEXPRESS;Database=CorretorDB;Integrated Security=True;",
               tableName: TableName,
               columnOptions: columnOpts)
           .CreateLogger();
            try
            {
            }
            catch(Exception ex)
            {
                Log.Logger.Warning(ex, "TEMOS UMA EXCEPTION no STARTUP");
            }
            

        }
    }
}

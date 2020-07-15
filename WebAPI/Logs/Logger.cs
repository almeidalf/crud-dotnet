using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace WebAPI.Logs
{
    public class Logger
    {
        public static ILogger _logger;

        [Obsolete]
        static Logger()
        {
            var connStr = "Server=DESKTOP-HJHKJJL;Database=CorretorDB;Trusted_Connection=True;";

            var tableName = "Serilog";
            var columnOpts = new ColumnOptions();
            var _logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.MSSqlServer(connectionString: connStr
                    , tableName: tableName
                    , columnOptions: columnOpts)
                .CreateLogger();

            Serilog.Debugging.SelfLog.Enable(msg => Console.WriteLine(msg));
        }
    }
}
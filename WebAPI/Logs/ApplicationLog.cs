using System;
using WebAPI.Interfaces;

namespace WebAPI.Logs
{
    public class ApplicationLog : ILog
    {
        private readonly Serilog.ILogger Logger;
        public ApplicationLog(Serilog.ILogger logger)
        {
            this.Logger = logger;
        }

        public void Info(string message, params object[] messageParams)
        {
            Logger.Information(message, messageParams);
        }

        public void Info<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            Logger.Information(messageTemplate, propertyValue0, propertyValue1, propertyValue2);
        }

        public void Debug(string message, params object[] messageParams)
        {
            Logger.Debug(message, messageParams);
        }

        public void Debug<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            Logger.Debug(messageTemplate, propertyValue0, propertyValue1, propertyValue2);
        }

        public void Warn(string message, System.Exception ex = null, params object[] messageParams)
        {
            Logger.Warning(message, messageParams, ex);
        }

        public void Warn<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            Logger.Warning(messageTemplate, propertyValue0, propertyValue1, propertyValue2);
        }

        public void Error(string message, System.Exception ex, params object[] messageParams)
        {
            Logger.Error(ex, message, messageParams);
        }

        public void Error<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            Logger.Error(messageTemplate, propertyValue0, propertyValue1, propertyValue2);
        }

        public void Fatal(string message, System.Exception ex, params object[] messageParams)
        {
            Logger.Fatal(message, messageParams, ex);
        }

        public void Fatal<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            Logger.Fatal(messageTemplate, propertyValue0, propertyValue1, propertyValue2);
        }

        public void Error(Exception ex, string message)
        {
            Logger.Error(ex, message);
        }

        public void Fatal(Exception ex, string message)
        {
            Logger.Fatal(ex, message);
        }
    }
    }

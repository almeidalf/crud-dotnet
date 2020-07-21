using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Interfaces
{
    public class ILog
    {
        public interface IAppLog
        {
            void Info(string message, params object[] messageParams);
            void Info<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2);
            void Debug(string message, params object[] messageParams);
            void Debug<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2);
            void Warn(string message, System.Exception ex = null, params object[] messageParams);
            void Warn<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2);
            void Error(System.Exception ex, string message);
            void Error(string message, System.Exception ex, params object[] messageParams);
            void Error<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2);
            void Fatal(System.Exception ex, string message);
            void Fatal(string message, System.Exception ex, params object[] messageParams);
            void Fatal<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2);
        }
    }
}
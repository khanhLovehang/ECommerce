using Contracts.Manager;
using NLog;

namespace LoggerService
{
    public class LoggerManager : ILoggerManager
    {
        #region properties
        //change ILogger -> Logger to improve performance
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region constructor
        public LoggerManager() { 
        }
        #endregion

        #region
        public void LogDebug(string message) => logger.Debug(message);
        public void LogError(string message) => logger.Error(message);
        public void LogInfo(string message) => logger.Info(message);
        public void LogWarn(string message) => logger.Warn(message);
        #endregion
    }
}

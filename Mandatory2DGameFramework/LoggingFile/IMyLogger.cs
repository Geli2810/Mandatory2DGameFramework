using System.Diagnostics;

namespace Mandatory2DGameFramework.LoggingFile
{
    public interface IMyLogger
    {
        static abstract MyLogger Instance { get; }

        void AddListener(TraceListener listener);
        void LogError(string message);
        void LogInfo(string message);
        void LogWarning(string message);
        void RemoveListener(TraceListener listener);
    }
}
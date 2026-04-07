using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.LoggingFile
{
    public sealed class MyLogger : IMyLogger
    {
        /// <summary>
        /// Singleton instance of MyLogger. It is initialized to null, and it is created when the Instance property is accessed for the first time. The lock is used to ensure that only one instance of MyLogger is created in a multithreaded environment.
        /// </summary>
        private static MyLogger instance = null;
        private static readonly object padlock = new object();

        /// <summary>
        /// The constructor for the MyLogger class. It sets the AutoFlush property of the Trace class to true. This means that the Trace class will automatically flush its buffers when a message is written to it.
        /// </summary>
        MyLogger()
        {
            Trace.AutoFlush = true;
        }

        /// <summary>
        /// The Instance property returns the singleton instance of MyLogger. It uses the lock keyword to ensure that only one instance of MyLogger is created in a multithreaded environment.
        /// </summary>
        public static MyLogger Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new MyLogger();
                    }
                    return instance;
                }
            }
        }

        /// <summary>
        /// The AddListener method adds a TraceListener to the Trace.Listeners collection. If the listener is not already in the collection, it is added.
        /// </summary>
        /// <param name="listener"> The listener to be added to the Trace.Listeners collection</param>
        public void AddListener(TraceListener listener)
        {
            if (!Trace.Listeners.Contains(listener))
                Trace.Listeners.Add(listener);
        }


        /// <summary>
        /// The RemoveListener method removes a TraceListener from the Trace.Listeners collection.  If the listener is in the collection, it is removed.
        /// </summary>
        /// <param name="listener"> The listener to be removed from the Trace.Listeners collection</param>
        public void RemoveListener(TraceListener listener)
        {
            if (Trace.Listeners.Contains(listener))
                Trace.Listeners.Remove(listener);
        }


        /// <summary>
        /// The LogInfo method writes an information message to the Trace class. It uses the Trace.TraceInformation method to write the message to the trace listeners.
        /// </summary>
        /// <param name="message"> The message to be logged and it should be an string message</param>
        public void LogInfo(string message)
        {
            Trace.TraceInformation(message);
        }


        /// <summary>
        /// The LogWarning method writes a warning message to the Trace class. It uses the Trace.TraceWarning method to write the message to the trace listeners.
        /// </summary>
        /// <param name="message"> The message to be logged and it should be an string message</param>
        public void LogWarning(string message)
        {
            Trace.TraceWarning(message);
        }

        /// <summary>
        /// The LogError method writes an error message to the Trace class. It uses the Trace.TraceError method to write the message to the trace listeners.
        /// </summary>
        /// <param name="message"> The message to be logged and it should be an string message</param>
        public void LogError(string message)
        {
            Trace.TraceError(message);
        }
    }
}

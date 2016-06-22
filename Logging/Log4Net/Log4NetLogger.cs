

namespace Logging
{
    #region Using Directives

    using log4net;
    using log4net.Core;
    
    using Newtonsoft.Json;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    #endregion Using Directives

    /// <summary>
    /// Log4NetLogger
    /// </summary>
    public class Log4NetLogger : ILogger
    {
        /// <summary>
        /// The ILog interface is used by application to log messages into the log4net framework.
        /// </summary>
        private ILog _logger = null;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LogMessage"/> class.
        /// </summary>
        /// <param name="log">The log.</param>
        public Log4NetLogger(string name)
        {
            _logger = LogManager.GetLogger(name);
            log4net.Config.XmlConfigurator.Configure();
        }

        #endregion Constructors

        #region Fields






        /// <summary>
        /// Reference Id
        /// </summary>
        public Guid ReferenceID { get; set; }


        /// <summary>
        /// Input Parameters
        /// </summary>
        public Dictionary<string, object> inputParameters { get; set; }

        #endregion Fields

        #region Methods

        /// <summary>
        /// Writes info log messages
        /// </summary>
        /// <param name="message">Log message</param>
        /// <param name="viewLevel">View Level for restricting the logs</param>
        /// <param name="exception">Exception</param>

        public void Info
        (
            string message,
            ViewLevel logViewLevel,
            Exception exception = null
        )
        {

            if (_logger.IsInfoEnabled)
            {
                Write
                (
                    Level.Info,
                    this.ReferenceID,
                    message,
                    logViewLevel,
                    this.inputParameters,
                    exception
                );
            }
        }

        /// <summary>
        /// Writes log messages which are of level Error
        /// </summary>
        /// <param name="message">Log message</param>
        /// <param name="viewLevel">View Level for restricting the logs</param>
        /// <param name="exception">Exception</param>
        public void Error
        (
            string message,
            ViewLevel logViewLevel,
            Exception exception = null
        )
        {
            Write
            (
                Level.Error,
                this.ReferenceID,
                message,
                logViewLevel,
                this.inputParameters,
                exception
            );
        }

        /// <summary>
        /// Writes log messages which are of level Warning
        /// </summary>
        /// <param name="message">Log message</param>
        /// <param name="viewLevel">View Level for restricting the logs</param>
        /// <param name="inputs">Other properties</param>
        /// <param name="exception">Exception</param>
        public void Warning
        (
            string message,
            ViewLevel logViewLevel,
            Exception exception = null
        )
        {
            Write
            (
                Level.Warn,
                this.ReferenceID,
                message,
                logViewLevel,
                this.inputParameters,
                exception

            );
        }

        /// <summary>
        /// Writes log messages which are of level Verbose
        /// </summary>
        /// <param name="message">Log message</param>
        /// <param name="viewLevel">View Level for restricting the logs</param>
        /// <param name="inputs">Other properties</param>
        /// <param name="exception">Exception</param>

        public void Verbose
        (
            string message,
            ViewLevel logViewLevel,
            Exception exception = null
        )
        {
            Write
            (
                Level.Verbose,
                this.ReferenceID,
                message,
                logViewLevel,
                this.inputParameters,
                exception

            );
        }

        /// <summary>
        /// Writes log messages which are of level critical
        /// </summary>
        /// <param name="message">Log message</param>
        /// <param name="viewLevel">View Level for restricting the logs</param>
        /// <param name="inputs">Other properties</param>
        /// <param name="exception">Exception</param>
        public void Critical
        (
            string message,
            ViewLevel logViewLevel,
            Exception exception = null
        )
        {
            Write
            (
                Level.Critical,
                this.ReferenceID,
                message,
                logViewLevel,
                this.inputParameters,
                exception
            );
        }

        /// <summary>
        /// Writes log to the given appenders
        /// </summary>
        /// <param name="level">Log level</param>
        /// <param name="ReferenceID">Reference id to track logs</param>
        /// <param name="applicationName">Application name</param>
        /// <param name="message">Log message</param>
        /// <param name="viewLevel">View Level for restricting the logs</param>
        /// <param name="serviceName">Service name</param>
        /// <param name="customerShortName"Customer short name></param>
        /// <param name="projectShortName">Project short name</param>
        /// <param name="inputParameters">Input parameters</param>
        /// <param name="inputs">Other properties</param>
        /// <param name="exception">Exception</param>

        public void Write
        (
            Level level,
            Guid ReferenceID,
            string message,
            ViewLevel logViewLevel,
            Dictionary<string, object> inputParameters = null,
            Exception exception = null
        )
        {
            try
            {
                #region Properties

                inputParameters = inputParameters ?? new Dictionary<string, object>();
                var inputs = JsonConvert.SerializeObject
                                         (
                                            FormatParameters(inputParameters, true),
                                            new JsonSerializerSettings()
                                            {
                                                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                                            }
                                         );

                inputs = inputParameters.Count == 0 ? "" : inputs;
                log4net.LogicalThreadContext.Properties["inputs"] = inputs;
                log4net.LogicalThreadContext.Properties["ref_id"] = ReferenceID;

                #endregion Properties

                if (level == Level.Error)
                {
                    _logger.Logger.Log(typeof(Log4NetLogger), level, message, exception);
                }
                else
                {
                    _logger.Logger.Log(typeof(Log4NetLogger), level, message, null);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Methods

        #region Helpers

        public Dictionary<string, object> FormatParameters
        (
            Dictionary<string, object> loggingParameters,
            bool collectionAsCount = false
        )
        {
            return loggingParameters.Select
                            (
                                (paramInfo, index) =>
                                    new
                                    {
                                        type = paramInfo.Value.GetType(),
                                        name = paramInfo.Key,
                                        value = paramInfo.Value
                                    }
                            ).
                            ToDictionary
                            (
                                entry => entry.name,
                                entry =>
                                    collectionAsCount ?
                                                 entry.value != null ?
                                                    (entry.value is ICollection) ?
                                                            string.Format
                                                            (
                                                                entry.name + " has '{0}' items",
                                                                ((ICollection)entry.value).Count
                                                            )
                                                    : entry.value.ToString()
                                                : "value is null"
                                    : entry.value
                            );
        }

        #endregion Helpers
    }
}
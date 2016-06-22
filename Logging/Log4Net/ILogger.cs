

namespace Logging
{
    #region Directives

    using System;
    using System.Collections.Generic;

    #endregion Directives

    /// <summary>
    /// ILogger for log4net
    /// </summary>
    public interface ILogger
    {


        /// <summary>
        /// Reference Id
        /// </summary>
        Guid ReferenceID { get; set; }



        /// <summary>
        /// Input Parameters
        /// </summary>
        Dictionary<string, object> inputParameters { get; set; }

        /// <summary>
        /// Writes log messages which are of level Critical
        /// </summary>
        /// <param name="message">Log message</param>
        /// <param name="logViewLevel">View Level for restricting the logs</param>
        /// <param name="exception">Exception</param> List<exception cref=">"
        void Critical
        (
            string message,
            ViewLevel logViewLevel,
            Exception exception = null
        );

        /// <summary>
        /// Writes log messages which are of level Error
        /// </summary>
        /// <param name="message">Log message</param>
        /// <param name="logViewLevel">View Level for restricting the logs</param>
        /// <param name="inputs">Other properties</param>
        /// <param name="exception">Exception</param>
        void Error
        (
            string message,
            ViewLevel logViewLevel,
            Exception exception = null
        );

        /// <summary>
        /// Writes log messages which are of level Warning
        /// </summary>
        /// <param name="message">Log message</param>
        /// <param name="logViewLevel">View Level for restricting the logs</param>
        /// <param name="exception">Exception</param>
        void Warning
        (
            string message,
            ViewLevel logViewLevel,
            Exception exception = null
        );

        /// <summary>
        /// Writes log messages which are of level Verbose
        /// </summary>
        /// <param name="message">Log message</param>
        /// <param name="logViewLevel">View Level for restricting the logs</param>
        /// <param name="exception">Exception</param>

        void Verbose
        (
            string message,
            ViewLevel logViewLevel,
            Exception exception = null
        );

        /// <summary>
        /// Writes log messages which are of level Info
        /// </summary>
        /// <param name="message">Log message</param>
        /// <param name="logViewLevel">View Level for restricting the logs</param>
        /// <param name="exception">Exception</param>
        void Info
        (
            string message,
            ViewLevel logViewLevel,
            Exception exception = null
        );
    }
}
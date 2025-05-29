using System;

namespace GameMacro.Services
{
    /// <summary>
    /// 日志服务接口
    /// </summary>
    public interface ILoggingService
    {
        /// <summary>
        /// 记录调试信息
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">格式化参数</param>
        void Debug(string message, params object[] args);

        /// <summary>
        /// 记录信息
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">格式化参数</param>
        void Info(string message, params object[] args);

        /// <summary>
        /// 记录警告
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">格式化参数</param>
        void Warning(string message, params object[] args);

        /// <summary>
        /// 记录错误
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">格式化参数</param>
        void Error(string message, params object[] args);

        /// <summary>
        /// 记录错误
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">格式化参数</param>
        void Error(Exception ex, string message, params object[] args);

        /// <summary>
        /// 记录致命错误
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">格式化参数</param>
        void Fatal(string message, params object[] args);

        /// <summary>
        /// 记录致命错误
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">格式化参数</param>
        void Fatal(Exception ex, string message, params object[] args);
    }
} 
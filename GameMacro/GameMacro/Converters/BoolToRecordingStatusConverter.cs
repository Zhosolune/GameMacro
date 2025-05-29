using System;
using System.Globalization;
using System.Windows.Data;

namespace GameMacro.Converters
{
    /// <summary>
    /// 将布尔值转换为录制状态文本的转换器
    /// </summary>
    public class BoolToRecordingStatusConverter : IValueConverter
    {
        /// <summary>
        /// 将布尔值转换为录制状态文本
        /// </summary>
        /// <param name="value">输入值</param>
        /// <param name="targetType">目标类型</param>
        /// <param name="parameter">转换参数</param>
        /// <param name="culture">文化信息</param>
        /// <returns>录制状态文本</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isRecording)
            {
                return isRecording ? "正在录制..." : "就绪";
            }
            return "就绪";
        }

        /// <summary>
        /// 反向转换（不支持）
        /// </summary>
        /// <param name="value">输入值</param>
        /// <param name="targetType">目标类型</param>
        /// <param name="parameter">转换参数</param>
        /// <param name="culture">文化信息</param>
        /// <returns>始终抛出异常</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 
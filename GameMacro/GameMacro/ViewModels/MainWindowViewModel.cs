using System;
using System.Windows.Input;
using GameMacro.Services;

namespace GameMacro.ViewModels
{
    /// <summary>
    /// 主窗口视图模型
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ILoggingService _loggingService;
        private string _title = "GameMacro";
        private bool _isRecording;

        /// <summary>
        /// 窗口标题
        /// </summary>
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        /// <summary>
        /// 是否正在录制
        /// </summary>
        public bool IsRecording
        {
            get => _isRecording;
            set => SetProperty(ref _isRecording, value, OnRecordingChanged);
        }

        /// <summary>
        /// 开始录制命令
        /// </summary>
        public ICommand StartRecordingCommand { get; }

        /// <summary>
        /// 停止录制命令
        /// </summary>
        public ICommand StopRecordingCommand { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="loggingService">日志服务</param>
        public MainWindowViewModel(ILoggingService loggingService)
        {
            _loggingService = loggingService ?? throw new ArgumentNullException(nameof(loggingService));
            
            StartRecordingCommand = CreateCommand(StartRecording, CanStartRecording);
            StopRecordingCommand = CreateCommand(StopRecording, CanStopRecording);
            
            _loggingService.Info("MainWindowViewModel initialized");
        }

        /// <summary>
        /// 开始录制
        /// </summary>
        private void StartRecording()
        {
            _loggingService.Info("Starting recording...");
            IsRecording = true;
        }

        /// <summary>
        /// 停止录制
        /// </summary>
        private void StopRecording()
        {
            _loggingService.Info("Stopping recording...");
            IsRecording = false;
        }

        /// <summary>
        /// 是否可以开始录制
        /// </summary>
        /// <returns>如果当前未在录制中，则返回true</returns>
        private bool CanStartRecording()
        {
            return !IsRecording;
        }

        /// <summary>
        /// 是否可以停止录制
        /// </summary>
        /// <returns>如果当前正在录制中，则返回true</returns>
        private bool CanStopRecording()
        {
            return IsRecording;
        }

        /// <summary>
        /// 录制状态变更处理
        /// </summary>
        private void OnRecordingChanged()
        {
            _loggingService.Info($"Recording state changed to: {IsRecording}");
            // 更新命令可执行状态
            (StartRecordingCommand as RelayCommand)?.RaiseCanExecuteChanged();
            (StopRecordingCommand as RelayCommand)?.RaiseCanExecuteChanged();
        }
    }
} 
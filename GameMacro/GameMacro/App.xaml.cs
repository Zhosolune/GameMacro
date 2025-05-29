using System;
using System.Windows;
using GameMacro.Services;
using GameMacro.ViewModels;
using NLog;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;

namespace GameMacro
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : PrismApplication
    {
        /// <summary>
        /// 创建Shell窗口（主窗口）
        /// </summary>
        /// <returns>主窗口实例</returns>
        protected override Window CreateShell()
        {
            var logger = Container.Resolve<ILoggingService>();
            logger.Debug("CreateShell called, resolving MainWindow.");
            return Container.Resolve<MainWindow>();
        }

        /// <summary>
        /// 注册类型到IoC容器
        /// </summary>
        /// <param name="containerRegistry">容器注册器</param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 注册服务
            containerRegistry.RegisterSingleton<ILoggingService, LoggingService>();
            
            // 注册视图模型
            containerRegistry.Register<MainWindowViewModel>();
            
            // 显式注册视图和视图模型的关联
            ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();
        }

        /// <summary>
        /// 配置日志
        /// </summary>
        private void ConfigureLogging()
        {
            try
            {
                // NLog已通过NLog.config配置
                LogManager.GetCurrentClassLogger().Info("应用程序启动");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"初始化日志系统失败: {ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// 应用程序启动
        /// </summary>
        /// <param name="e">启动事件参数</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            ConfigureLogging();
            base.OnStartup(e);
        }

        /// <summary>
        /// 应用程序退出
        /// </summary>
        /// <param name="e">退出事件参数</param>
        protected override void OnExit(ExitEventArgs e)
        {
            LogManager.Shutdown();
            base.OnExit(e);
        }
    }
}

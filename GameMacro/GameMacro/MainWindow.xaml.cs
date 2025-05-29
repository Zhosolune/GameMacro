using System.Windows;
// using GameMacro.ViewModels; //不再需要，Prism会自动关联

namespace GameMacro
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        // 不再需要这个构造函数，Prism会自动注入ViewModel
        // /// <summary>
        // /// 带视图模型参数的构造函数，用于Prism依赖注入
        // /// </summary>
        // /// <param name="viewModel">主窗口视图模型</param>
        // public MainWindow(MainWindowViewModel viewModel) : this()
        // {
        //     DataContext = viewModel;
        // }
    }
}
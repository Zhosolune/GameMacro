# GameMacro

GameMacro是一款运行在Windows系统上的游戏操作录制与自动化工具，能够录制、编辑和回放用户在游戏中的鼠标和键盘操作，用于自动化重复性游戏任务。

## 主要功能

- **操作录制**：录制用户的键盘和鼠标操作，包括按键、点击、移动等
- **操作编辑**：修改操作的持续时间、间隔时间，重新排序操作
- **操作回放**：精确回放录制的操作序列，支持循环和速度调整
- **数据管理**：保存、加载和分享操作序列
- **置顶显示**：界面保持在所有窗口最上层
- **托盘集成**：最小化到系统托盘，可配置悬浮图标

## 技术栈

- **开发语言**：C#
- **框架**：.NET 8.0
- **UI框架**：WPF + HandyControl
- **架构模式**：MVVM (使用Prism框架)
- **底层实现**：Windows Hook API, Raw Input API, SendInput API

## 项目结构

```
GameMacro/
|-- GameMacro/           # 主项目
|   |-- Core/            # 核心功能代码
|   |   |-- Helpers/     # 辅助类
|   |   |-- Hooks/       # 钩子相关代码
|   |   |-- Input/       # 输入处理相关代码
|   |-- Models/          # 数据模型
|   |-- ViewModels/      # 视图模型
|   |-- Views/           # 视图
|   |   |-- Controls/    # 自定义控件
|   |-- Services/        # 服务层
|   |-- Resources/       # 资源文件
|       |-- Images/      # 图片资源
|       |-- Styles/      # 样式资源
|-- docs/                # 文档
|-- tests/               # 测试代码
|   |-- GameMacro.Tests/ # 单元测试项目
|-- tools/               # 工具脚本
```

## 开发环境

- Visual Studio 2022 (17.8及以上版本)
- .NET 8.0 SDK
- Windows 10/11

## 文档

- [需求文档](docs/需求文档.md)
- [开发文档](docs/开发文档.md)

## 许可证

本项目采用MIT许可证。详见[LICENSE](LICENSE)文件。 
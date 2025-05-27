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
- **UI框架**：WPF + HandyControl
- **架构模式**：MVVM (使用Prism框架)
- **底层实现**：Windows Hook API, Raw Input API, SendInput API

## 项目结构

```
GameMacro/
|-- src/                # 源代码
|   |-- GameMacro/      # 主项目
|-- docs/               # 文档
|-- tests/              # 测试代码
|-- tools/              # 工具脚本
```

## 开发环境

- Visual Studio 2022或JetBrains Rider
- .NET 6.0+ SDK
- Windows 10/11

## 文档

- [需求文档](docs/需求文档.md)
- [开发文档](docs/开发文档.md)

## 许可证

本项目采用MIT许可证。详见[LICENSE](LICENSE)文件。 
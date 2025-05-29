using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace GameMacro.ViewModels
{
    /// <summary>
    /// ViewModel基类，实现INotifyPropertyChanged接口，提供属性变更通知和命令绑定支持
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// 属性变更事件
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// 触发属性变更事件
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 设置属性值并触发属性变更事件
        /// </summary>
        /// <typeparam name="T">属性类型</typeparam>
        /// <param name="storage">属性字段引用</param>
        /// <param name="value">新的属性值</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns>如果属性值发生变化则返回true，否则返回false</returns>
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// 设置属性值并触发属性变更事件，同时执行额外的操作
        /// </summary>
        /// <typeparam name="T">属性类型</typeparam>
        /// <param name="storage">属性字段引用</param>
        /// <param name="value">新的属性值</param>
        /// <param name="onChanged">属性变更后执行的操作</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns>如果属性值发生变化则返回true，否则返回false</returns>
        protected virtual bool SetProperty<T>(ref T storage, T value, Action onChanged, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// 基础命令类，实现ICommand接口
        /// </summary>
        protected class RelayCommand : ICommand
        {
            private readonly Action<object?> _execute;
            private readonly Func<object?, bool>? _canExecute;

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="execute">执行方法</param>
            /// <param name="canExecute">是否可执行方法</param>
            public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
            {
                _execute = execute ?? throw new ArgumentNullException(nameof(execute));
                _canExecute = canExecute;
            }

            /// <summary>
            /// 可执行状态变更事件
            /// </summary>
            public event EventHandler? CanExecuteChanged
            {
                add => CommandManager.RequerySuggested += value;
                remove => CommandManager.RequerySuggested -= value;
            }

            /// <summary>
            /// 判断命令是否可执行
            /// </summary>
            /// <param name="parameter">命令参数</param>
            /// <returns>是否可执行</returns>
            public bool CanExecute(object? parameter)
            {
                return _canExecute == null || _canExecute(parameter);
            }

            /// <summary>
            /// 执行命令
            /// </summary>
            /// <param name="parameter">命令参数</param>
            public void Execute(object? parameter)
            {
                _execute(parameter);
            }

            /// <summary>
            /// 触发可执行状态变更事件
            /// </summary>
            public void RaiseCanExecuteChanged()
            {
                CommandManager.InvalidateRequerySuggested();
            }
        }

        /// <summary>
        /// 创建命令
        /// </summary>
        /// <param name="execute">执行方法</param>
        /// <param name="canExecute">是否可执行方法</param>
        /// <returns>命令对象</returns>
        protected ICommand CreateCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            return new RelayCommand(execute, canExecute);
        }

        /// <summary>
        /// 创建无参数命令
        /// </summary>
        /// <param name="execute">执行方法</param>
        /// <param name="canExecute">是否可执行方法</param>
        /// <returns>命令对象</returns>
        protected ICommand CreateCommand(Action execute, Func<bool>? canExecute = null)
        {
            return new RelayCommand(
                _ => execute(),
                _ => canExecute?.Invoke() ?? true
            );
        }
    }
} 
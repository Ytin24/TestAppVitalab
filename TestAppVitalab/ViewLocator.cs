using Avalonia.Controls;
using System;
using System.Linq;
using ReactiveUI;
using System.Reflection;

namespace TestAppVitalab {
    public class ViewLocator : IViewLocator
    {
        public IViewFor? ResolveView<T>(T? viewModel, string? contract = null)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            var viewModelName = viewModel.GetType().Name;
            var viewName = viewModelName.Replace("ViewModel", "View");
            var viewType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == viewName);
            if (viewType == null)
            {
                return default;
            }

            var view = Activator.CreateInstance(viewType);
            if (view == null)
            {
                throw new InvalidOperationException($"Не удалось создать представление для {viewModelName}");
            }

            ((UserControl)view).DataContext = viewModel;
            return (IViewFor?)view;
        }
    }
}

using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppVitalab.ViewModels;

namespace TestAppVitalab.Services {
    public class ViewModelService : BaseService, IViewModelService {
		private ViewModelBase _currentViewModel;

		public ViewModelBase CurrentViewModel {
			get { return _currentViewModel; }
			set { this.RaiseAndSetIfChanged(ref _currentViewModel, value); }
		}
    }

    public interface IViewModelService {
        public ViewModelBase CurrentViewModel { get; set; } 
    }
}

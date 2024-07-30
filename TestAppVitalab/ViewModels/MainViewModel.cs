using ReactiveUI;
using System.Diagnostics.Metrics;
using System.Reactive;
using TestAppVitalab.Services;

namespace TestAppVitalab.ViewModels;

public class MainViewModel : ReactiveObject, IScreen {
    private IViewModelService _viewModelService;
    public MainViewModel(IViewModelService viewModelService) {
        _viewModelService = viewModelService;
        this.WhenAnyValue(x => x._viewModelService.CurrentViewModel).WhereNotNull().Subscribe(
            new AnonymousObserver<ViewModelBase>((x) => {
                Router.Navigate.Execute(x);
            })
         );
    }
    private RoutingState _router = new();
    public RoutingState Router {
        get => _router;
        set => this.RaiseAndSetIfChanged(ref _router, value);
    }
}

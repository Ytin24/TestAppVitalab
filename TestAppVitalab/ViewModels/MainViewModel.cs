using ReactiveUI;
using System.Diagnostics.Metrics;
using System.Reactive;
using TestAppVitalab.Services;

namespace TestAppVitalab.ViewModels;

public class MainViewModel : ReactiveObject, IScreen {
    public MainViewModel() {
        
    }
    private RoutingState _router = new();
    public RoutingState Router {
        get => _router;
        private set => this.RaiseAndSetIfChanged(ref _router, value);
    }
}

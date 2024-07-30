using ReactiveUI;
using ReactiveUI.Validation.Helpers;
using System;

namespace TestAppVitalab.ViewModels;

public class ViewModelBase : ReactiveValidationObject, IRoutableViewModel {
    public ViewModelBase(IScreen screen) {
        HostScreen = screen;
    }
    public string? UrlPathSegment => Guid.NewGuid().ToString();

    public IScreen HostScreen { get; set; }
}

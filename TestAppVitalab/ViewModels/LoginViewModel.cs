using Avalonia.Threading;

using MsBox.Avalonia;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using TestAppVitalab.Services;

namespace TestAppVitalab.ViewModels {
    public class LoginViewModel : ViewModelBase {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string AppartmentNumber { get; set; } = string.Empty;
        public ReactiveCommand<Unit, Unit> LoginAccount { get; set; }
        public LoginViewModel(IScreen screen, IAuthService authService, HomeViewModel homeViewModel) : base(screen) {
            LoginAccount = ReactiveCommand.CreateFromTask(async () =>
            {
                if (await authService.TryLoginUser(new()
                    {
                        UserLogin = Login,
                        UserPassword = Password
                    }))
                {
                    HostScreen.Router.Navigate.Execute(homeViewModel);
                }
            });
        }
    }
}

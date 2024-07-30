using Avalonia.Controls;
using Avalonia.ReactiveUI;
using TestAppVitalab.ViewModels;

namespace TestAppVitalab.Views {
    public partial class LoginView : ReactiveUserControl<LoginViewModel> {
        public LoginView() {
            InitializeComponent();
        }
    }
}

using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TestAppVitalab.Core.DTO;

namespace TestAppVitalab.Services {
    public class AuthService : BaseService, IAuthService {
        private bool _isAuth;

        public bool IsAuth {
            get { return _isAuth; }
            set { this.RaiseAndSetIfChanged(ref _isAuth, value); }
        }
        private User _currentUser;

        public User CurrentUser {
            get { return _currentUser; }
            set { this.RaiseAndSetIfChanged(ref _currentUser, value); }
        }

        public async Task<bool> TryLoginUser(UserAuthDTO userAuth) {
            using (HttpClient client = new()) {
                var answer = await client.PostAsync("http://127.0.0.1:5084/Login/GetUser", JsonContent.Create(userAuth));
                return answer.IsSuccessStatusCode ? true : false;
            }
        }
    }

    public interface IAuthService {
        public bool IsAuth { get; set; }
        public User CurrentUser { get; set; }
        public Task<bool> TryLoginUser(UserAuthDTO userAuth);
    }

    public class User {
    }
}

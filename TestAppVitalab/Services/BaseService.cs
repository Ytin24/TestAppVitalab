using System;
using ReactiveUI;

namespace TestAppVitalab.Services {
    public class BaseService : ReactiveObject {
        protected const string BASE_URL = "http://127.0.0.1:5084/";
    }
}
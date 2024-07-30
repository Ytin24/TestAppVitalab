using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppVitalab.Core.DTO {
    public record UserAuthDTO {
        public string UserLogin { get; set; } = null!;

        public string UserPassword { get; set; } = null!;
    }
    public record UserDTO {
        public int UserId { get; set; }

        public string UserName { get; set; } = null!;

        public string UserLogin { get; set; } = null!;

        public string UserPassword { get; set; } = null!;
    }
}

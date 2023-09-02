using System;
using System.Collections.Generic;

namespace AdventuraClick.Database {
    public partial class Role {
        public int RoleId { get; set; }
        public string Name { get; set; } = null!;
        public string ? Description { get; set; }
}
}
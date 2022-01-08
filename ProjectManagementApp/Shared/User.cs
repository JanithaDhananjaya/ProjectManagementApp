using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.Shared
{
    class User
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string role { get; set; }

        public DateTime createdAt { get; set; }
    }
}

using Java.Sql;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiStock.MAUI.Models
{
    internal class UsersModel
    {
        public UUID ID { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public String password { get; set; }
        public UsersRights rights { get; set; }
    }
}

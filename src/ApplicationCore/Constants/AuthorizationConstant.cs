using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Constants
{
    public class AuthorizationConstant
    {
        public const string DEFAULT_PHARMA_USER = "pharma@example.com";
        public const string DEFAULT_ADMIN_USER = "admin@example.com";
        public const string DEFAULT_PASSWORD = "P@ssword1";
        public static class Roles
        {
            public const string ADMIN = "Admin";
            public const string PHARMACIST = "Pharmacist";
        }
    }
}

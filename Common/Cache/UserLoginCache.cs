﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public static class UserLoginCache
    {
        public static int UserID { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string Cargo { get; set; }
        public static string Status { get; set; }
        public static string Email { get; set; }
    }
}
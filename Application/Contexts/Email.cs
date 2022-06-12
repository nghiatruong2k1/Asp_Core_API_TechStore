using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Contexts
{
    public class EmailAuth
    {
        public string Name { get; set; }
        public string Username { get; set; }
    }
    public class EmailAccount : EmailAuth
    {
        public string Password { get; set; }
    }
    public class EmailConfigs
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; }
    }
    public class EmailData
    {
        public string FromName { get; set; }
        public string ToEmail { get; set; }
        public string ToName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}

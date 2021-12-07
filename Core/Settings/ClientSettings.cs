using System;
using System.Collections.Generic;

namespace Core.Options
{
    public class ClientSettings
    {
        public Configuration Defaults { get; set; }
        public List<Client> Clients { get; set; }
    }

    public class Client
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string DbServer { get; set; }
        public string DbName { get; set; }
        public string ConnectionString {
            get
            {
                return $"Data Source=(localdb)\\mssqllocaldb; Database= {DbName}; Trusted_Connection = True; MultipleActiveResultSets = true";
            }
            set { } 
        }

    }

    public class Configuration
    {
        public string DBProvider { get; set; }
        public string ConnectionString { get; set; }
    }
}
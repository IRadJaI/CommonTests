using Common.Tests.Base;
using Common.Tests.Entity;
using System;
using System.Collections.Generic;

namespace Common.Tests {
    public class Settings : ISettings {
        public string BaseUrl { get; set; }
        public string TestUrl { get {
                return string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("BaseUrl")) ? 
                    BaseUrl : 
                    Environment.GetEnvironmentVariable("BaseUrl");
            } 
        }
        public string TestContactName { get; set; }
        public List<TestUser> TestUsers { get; set; }
    }
}

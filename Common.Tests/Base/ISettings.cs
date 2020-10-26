using Common.Tests.Entity;
using System.Collections.Generic;

namespace Common.Tests.Base
{
    public interface ISettings
    {
        string TestUrl { get; }
        string TestContactName { get; set; }
        List<TestUser> TestUsers { get; set; }
    }
}

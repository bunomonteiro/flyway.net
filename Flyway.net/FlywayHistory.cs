using System;

namespace Flyway.net
{
    public class FlywayHistory
    {
        public string Category { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime? InstalledOn { get; set; }
        public string State { get; set; }
    }
}

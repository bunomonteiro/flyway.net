using System.Collections.Generic;

using Flyway.net.ValueObjects;

namespace Flyway.net
{
    public class FlywayOutputResult
    {
        public string RawOutput { get; set; }
        public string ErrorMessage { get; set; }
        public bool HasError { get; set; }
        public SemVer Version { get; set; }
        public string Edition { get; set; }
        public List<FlywayHistory> History { get; set; }

        public FlywayOutputResult()
        {
            History = new List<FlywayHistory>();
        }
    }
}

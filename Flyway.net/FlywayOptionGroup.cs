using System;

namespace Flyway.net
{
    public abstract class FlywayOptionGroup
    {
        public FlywayUrlOption Url { get; set; }

        /// <summary>
        /// Validate required options
        /// </summary>
        public virtual bool Validate()
        {
            return !String.IsNullOrWhiteSpace(Url.Value);
        }

        /// <summary>
        /// Transform to prompt args
        /// </summary>
        public abstract string ToArgs();
    }
}

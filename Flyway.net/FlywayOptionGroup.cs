using System;
using System.Collections.Generic;
using System.Linq;

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

        protected string ToArgs(IEnumerable<string> options)
        {
            return String.Join(" ", onlyOptionsNotEmpty(options).Select(withoutLineBreaks));


            IEnumerable<string> onlyOptionsNotEmpty(IEnumerable<string> option) => option.Where(value => !String.IsNullOrWhiteSpace(value));
            // for dictionary values
            string withoutLineBreaks(string line) => line.Replace("\r\n", " ").Trim();
        }
    }
}

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
            Func<IEnumerable<string>, IEnumerable<string>> onlyOptionsNotEmpty = (option) => option.Where(value => !String.IsNullOrWhiteSpace(value));
            Func<string, string> withoutLineBreaks = (line) => line.Replace("\r\n", " ").Trim(); // for dictionary values

            return String.Join(" ", onlyOptionsNotEmpty(options).Select(withoutLineBreaks));
        }
    }
}

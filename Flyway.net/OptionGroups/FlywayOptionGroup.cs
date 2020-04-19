using System.Collections.Generic;
using System.Linq;

namespace Flyway.net.OptionGroups
{
    public abstract class FlywayOptionGroup
    {
        public FlywayUrlOption Url { get; set; }

        /// <summary>
        /// Validate required options
        /// </summary>
        public virtual bool Validate()
        {
            return !string.IsNullOrWhiteSpace(Url.Value);
        }

        /// <summary>
        /// Transform to prompt args
        /// </summary>
        public abstract string ToArgs();

        protected string ToArgs(IEnumerable<string> options)
        {
            return string.Join(" ", onlyOptionsNotEmpty(options).Select(withoutLineBreaks));


            IEnumerable<string> onlyOptionsNotEmpty(IEnumerable<string> option)
            {
                return option.Where(value => !string.IsNullOrWhiteSpace(value));
            }
            // for dictionary values
            string withoutLineBreaks(string line)
            {
                return line.Replace("\r\n", " ").Trim();
            }
        }
    }
}

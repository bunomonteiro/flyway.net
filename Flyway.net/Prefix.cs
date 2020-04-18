using System;

namespace Flyway.net
{
    public struct Prefix
    {
        public const string Cli = "-";
        public const string File = "flyway.";
        internal string Value { get; set; }

        public Prefix(string prefix = Cli) => this.Value = prefix ?? String.Empty;

        public override string ToString() => Value;
        public override bool Equals(object obj) => this == Convert.ToString(obj);
        public override int GetHashCode() => this.Value.GetHashCode();
        public static bool operator ==(Prefix left, Prefix right) => left.Equals(right);
        public static bool operator !=(Prefix left, Prefix right) => !(left == right);
        
        public static implicit operator string(Prefix prefix) => prefix.ToString();
        public static implicit operator Prefix(string prefix) => new Prefix(prefix);
    }
}

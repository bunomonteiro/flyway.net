using System;

namespace Flyway.net
{
    public struct Prefix
    {
        public const string Cli = "-";
        public const string File = "flyway.";
        internal string Value { get; set; }

        public Prefix(string prefix = Cli)
        {
            Value = prefix ?? Cli;
        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object obj)
        {
            return this == Convert.ToString(obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(Prefix left, Prefix right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Prefix left, Prefix right)
        {
            return !(left == right);
        }

        public static implicit operator string(Prefix prefix)
        {
            return prefix.ToString();
        }

        public static implicit operator Prefix(string prefix)
        {
            return new Prefix(prefix);
        }
    }
}

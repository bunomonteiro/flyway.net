using System;
using System.Text.RegularExpressions;

namespace Flyway.net.ValueObjects
{
    public struct SemVer
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Patch { get; set; }

        public SemVer(int major = 0, int minor = 0, int patch = 0)
        {
            Major = major;
            Minor = minor;
            Patch = patch;
        }

        public override string ToString()
        {
            return $"{Major}.{Minor}.{Patch}";
        }

        public override bool Equals(object version)
        {
            if(version is null || !(version is SemVer))
            {
                return false;
            }


            return this == (SemVer)version;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static bool operator ==(SemVer a, SemVer b)
        {
            if(ReferenceEquals(a, b))
            {
                return true;
            }

            return a.Major == b.Major && a.Minor == b.Minor && a.Patch == b.Patch;
        }
        public static bool operator !=(SemVer a, SemVer b)
        {
            return !(a == b);
        }

        public static bool operator >(SemVer a, SemVer b)
        {
            return (a.Major > b.Major)
                || (a.Major >= b.Major && a.Minor > b.Minor)
                || (a.Major >= b.Major && a.Minor >= b.Minor && a.Patch > b.Patch);
        }
        public static bool operator <(SemVer a, SemVer b)
        {
            return !(a > b);
        }

        public static bool operator >=(SemVer a, SemVer b)
        {
            return a > b || a == b;
        }
        public static bool operator <=(SemVer a, SemVer b)
        {
            return !(a >= b);
        }

        public static implicit operator SemVer(string version)
        {
            if(string.IsNullOrWhiteSpace(version))
            {
                return new SemVer();
            }

            string versionString = Regex.Match(version, @"\d+.+\d").Value;

            if(version.Trim().Length == versionString.Length)
            {
                string[] numbers = versionString.Split('.');
                return new SemVer(Convert.ToInt32(numbers[0]), Convert.ToInt32(numbers[1]), Convert.ToInt32(numbers[2]));
            }

            return new SemVer();
        }
    }
}

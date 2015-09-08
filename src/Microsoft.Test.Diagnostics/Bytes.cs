using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Test.Diagnostics
{
    public struct Bytes : IEquatable<Bytes>, IEquatable<long>, IComparable
    {
        public Bytes(long value)
        {
            Value = value;
        }

        public long Value { get; }

        public override string ToString()
        {
            if (Value < 1024)
            {
                return $"{Value}B";
            }
            else if (Value < (1024 * 1024))
            {
                return $"{(double)Value / 1024.0:0.00}KB";
            }
            else if (Value < (1024 * 1024 * 1024))
            {
                return $"{(double)Value / (1024.0 * 1024.0):0.00}MB";
            }
            else
            {
                return $"{(double)Value / (1024.0 * 1024.0 * 1024.0):0.00}GB";
            }
        }

        public int CompareTo(object obj)
        {
            if (obj is long)
            {
                return Value.CompareTo((long)obj);
            }
            else
            {
                return Value.CompareTo(((Bytes)obj).Value);
            }
        }

        public override bool Equals(object obj)
        {
            return Equals((Bytes)obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public bool Equals(long other)
        {
            return Value.Equals(other);
        }

        public bool Equals(Bytes other)
        {
            return Value.Equals(other.Value);
        }

        public static Bytes operator *(Bytes left, Bytes right)
        {
            return new Bytes(left.Value * right.Value);
        }

        public static Bytes operator /(Bytes left, Bytes right)
        {
            return new Bytes(left.Value / right.Value);
        }

        public static Bytes operator +(Bytes left, Bytes right)
        {
            return new Bytes(left.Value - right.Value);
        }

        public static Bytes operator -(Bytes left, Bytes right)
        {
            return new Bytes(left.Value - right.Value);
        }

        public static implicit operator Bytes(long value)
        {
            return new Bytes(value);
        }

        public static implicit operator long (Bytes value)
        {
            return value.Value;
        }
    }
}

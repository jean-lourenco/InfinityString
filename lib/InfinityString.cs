using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace InfinityStringLib
{
    public struct InfinityString : IEquatable<InfinityString>, IEnumerable<char>
    {
        public string Value { get; }
        public int Length { get; }
        public int TrueLength { get; }

        public InfinityString(string baseString)
        {
            if (baseString == null)
                throw new ArgumentNullException(nameof(baseString));

            Value = baseString;
            TrueLength = Value.Length;
            Length = Int32.MaxValue;
        }

        public char this[int index]
        {
            get
            {
                if (index >= TrueLength)
                    index = index % TrueLength;

                return Value[index];

                // checar pq não funciona
                //return Value[new IntControlledOverflow(index, TrueLength-1)];
            }
        }

        public static implicit operator string(InfinityString infinityString)
        {
            return infinityString.Value;
        }

        public static implicit operator InfinityString(string value)
        {
            return new InfinityString(value);
        }

        public IEnumerator<char> GetEnumerator()
        {
            var index = 0;
            
            while (true && TrueLength > 0)
            {
                yield return Value[index++];

                if (index >= TrueLength)
                    index = 0;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Equals(InfinityString infinityString)
        {
            return Value == infinityString.Value;
        }

        public override bool Equals(Object obj)
        {
            switch (obj)
            {
                case string value:
                    return Value == value;

                case InfinityString infinityString:
                    return Value == infinityString.Value;

                default:
                    return false;
            }
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value;
        }
    }
}

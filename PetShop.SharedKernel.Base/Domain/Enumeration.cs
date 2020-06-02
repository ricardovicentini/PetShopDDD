using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PetShop.SharedKernel.Base.Domain
{
    public abstract class Enumeration
    {
        int? _requestedHashCode;

        public string Name { get; private set; }
        public int Value { get; private set; }

        public Enumeration(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public static T Get<T>(int value) where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            return fields.Select(f => f.GetValue(null)).Cast<T>().Where(x => x.Value == value).SingleOrDefault();
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;

            if (otherValue == null)
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }
        public override int GetHashCode()
        {
            if (!_requestedHashCode.HasValue)
                _requestedHashCode = this.Value.GetHashCode() ^ 31;
            // XOR for random distribution. See:
            // https://docs.microsoft.com/archive/blogs/ericlippert/guidelines-and-rules-for-gethashcode
            return _requestedHashCode.Value;
        }
        public int CompareTo(object other) => Value.CompareTo(((Enumeration)other).Value);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace TaskManagement.Core.SeedWork
{
    // source: https://github.com/jhewlett/ValueObject
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        private List<PropertyInfo> properties;
        private List<FieldInfo> fields;

        public static bool operator ==(ValueObject left, ValueObject right)
        {
            if (object.Equals(left, null))
            {
                if (object.Equals(right, null))
                {
                    return true;
                }
                return false;
            }
            return left.Equals(right);
        }
        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !(left == right);
        }

        public bool Equals(ValueObject obj)
        {
            return Equals(obj as object);
        }
        private bool PropertiesAreEqual(object obj, PropertyInfo p)
        {
            return object.Equals(p.GetValue(this, null), p.GetValue(obj, null));
        }

        private bool FieldsAreEqual(object obj, FieldInfo f)
        {
            return object.Equals(f.GetValue(this), f.GetValue(obj));
        }
        // May contains bugs
        private IEnumerable<PropertyInfo> GetProperties()
        {
            if (this.properties == null)
            {
                this.properties = GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(p => p.GetCustomAttribute(typeof(IgnoreDataMemberAttribute)) == null)
                    .ToList();
            }

            return this.properties;
        }
        // May contains bugs
        private IEnumerable<FieldInfo> GetFields()
        {
            if (this.fields == null)
            {
                this.fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public)
                    .Where(p => p.GetCustomAttribute(typeof(IgnoreDataMemberAttribute)) == null)
                    .ToList();
            }

            return this.fields;
        }

        public override int GetHashCode()
        {
            unchecked   //allow overflow
            {
                int hash = 17;
                foreach (var prop in GetProperties())
                {
                    var value = prop.GetValue(this, null);
                    hash = HashValue(hash, value);
                }

                foreach (var field in GetFields())
                {
                    var value = field.GetValue(this);
                    hash = HashValue(hash, value);
                }

                return hash;
            }
        }

        private int HashValue(int seed, object value)
        {
            var currentHash = value != null
                ? value.GetHashCode()
                : 0;

            return seed * 23 + currentHash;
        }

    }

}

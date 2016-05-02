using System;

namespace Epiphany.Model
{
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public abstract TKey Id
        {
            get;
        }

        object IEntity.Id
        {
            get
            {
                return this.Id;
            }
        }

        public static bool operator ==(Entity<TKey> e1, Entity<TKey> e2)
        {
            if (object.ReferenceEquals(null, e1) && object.ReferenceEquals(null, e2))
            {
                return true;
            }
            else if (object.ReferenceEquals(null, e1))
            {
                return false;
            }
            else
            {
                return e1.Equals(e2);
            }
        }

        public static bool operator !=(Entity<TKey> e1, Entity<TKey> e2)
        {
            return !(e1 == e2);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}

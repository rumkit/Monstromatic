using System.Collections.Generic;
using System.Linq;

namespace Monstromatic.Models
{
    public abstract class FeatureBase
    {
        public abstract string Name { get; }

        public virtual IEnumerable<string> IncompatibleFeatures => Enumerable.Empty<string>();

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is FeatureBase feature)
                return Equals(feature);
            return false;
        }

        protected bool Equals(FeatureBase other)
        {
            return other.Name == Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}

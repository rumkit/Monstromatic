using System.Collections.Generic;
using System.Linq;

namespace Monstromatic.Models
{
    public abstract class FeatureBase
    {
        public abstract string Id { get; }

        public abstract string DisplayName { get; }

        public virtual string DetailsDisplayName => DisplayName;

        public virtual int LevelModifier => 0;

        public virtual int AttackModifier => 0;

        public virtual int DefenceModifier => 0;

        public virtual string Description => string.Empty;

        public virtual IEnumerable<FeatureBase> IncompatibleFeatures => Enumerable.Empty<FeatureBase>();

        public virtual IEnumerable<FeatureBase> IncludedFeatures => Enumerable.Empty<FeatureBase>();

        public virtual IEnumerable<FeatureBase> ExcludedFeatures => Enumerable.Empty<FeatureBase>();

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
            return other.Id == Id;
        }

        public override int GetHashCode() => DisplayName.GetHashCode() | Id.GetHashCode();
    }
}

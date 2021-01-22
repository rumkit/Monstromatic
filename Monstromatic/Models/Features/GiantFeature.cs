using System.Collections.Generic;

namespace Monstromatic.Models
{
    public class GiantFeature : FeatureBase
    {
        public override string Id => nameof(GiantFeature);
        public override string DisplayName => "Гигант";
        public override string DetailsDisplayName => "Гигант";
        public override string Description => "Гигант";

        public override IEnumerable<FeatureBase> IncompatibleFeatures
        {
            get
            {
                yield return new SmallSizeFeature();
            }
        }
        public override IEnumerable<FeatureBase> IncludedFeatures
        {
            get
            {
                yield return new BigSizeFeature();
                yield return new PowerfulAttackFeature();
                yield return new MassAttackFeature();
            }
        }
    }
}
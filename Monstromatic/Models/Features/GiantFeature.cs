using System.Collections.Generic;

namespace Monstromatic.Models
{
    public class GiantFeature : FeatureBase
    {
        public override string Id => nameof(GiantFeature);
        public override string DisplayName => "Гигант";
        public override int BraveryModifier => 1;

        public override IEnumerable<FeatureBase> IncompatibleFeatures
        {
            get
            {
                yield return new SmallSizeFeature();
            }
        }
        public override IEnumerable<FeatureBase> IncludedFeatures
        {
            get { yield return new BigSizeFeature(); }
        }
    }
}
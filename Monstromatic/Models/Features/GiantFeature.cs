using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Monstromatic.Models
{
    public class GiantFeature : FeatureBase
    {
        public override string Id => nameof(GiantFeature);
        public override string DisplayName => "Гигант";
        public override int BraveryModifier => 1;

        public override IEnumerable<string> IncompatibleFeatures
        {
            get
            {
                yield return nameof(SmallSizeFeature);
            }
        }
        public override IEnumerable<FeatureBase> IncludedFeatures
        {
            get { yield return new BigSizeFeature(); }
        }
    }
}
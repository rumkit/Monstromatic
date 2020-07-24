using System.Collections.Generic;

namespace Monstromatic.Models
{
    public class GiantFeature : FeatureBase
    {
        public override string Id => nameof(GiantFeature);
        public override string DisplayName => "Гигант";
        public override int LevelModifier => 2;

        public override IEnumerable<string> IncompatibleFeatures
        {
            get
            {
                yield return nameof(SmallSizeFeature);
                yield return nameof(BigSizeFeature);
            }
        }
    }
}
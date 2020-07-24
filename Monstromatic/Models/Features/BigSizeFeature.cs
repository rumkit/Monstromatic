using System.Collections.Generic;

namespace Monstromatic.Models
{
    public class BigSizeFeature : FeatureBase
    {
        public override string Id => nameof(BigSizeFeature);
        public override string DisplayName => "Большой размер";
        public override int LevelModifier => 1;

        public override IEnumerable<string> IncompatibleFeatures
        {
            get
            {
                yield return nameof(SmallSizeFeature);
                yield return nameof(GiantFeature);
            }
        }
    }
}
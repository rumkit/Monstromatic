using System.Collections.Generic;

namespace Monstromatic.Models
{
    public class BigSizeFeature : FeatureBase
    {
        public override string Id => nameof(BigSizeFeature);
        public override string DisplayName => "Большой";
        public override int LevelModifier => 1;

        public override IEnumerable<FeatureBase> IncompatibleFeatures
        {
            get
            {
                yield return new SmallSizeFeature();
            }
        }
    }
}
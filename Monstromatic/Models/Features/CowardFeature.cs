using System.Collections.Generic;

namespace Monstromatic.Models
{
    public class CowardFeature : FeatureBase
    {
        public override string Id => nameof(CowardFeature);
        public override string DisplayName => "Трус";
        public override string Description => "Бежит после первой раны";

        public override IEnumerable<FeatureBase> IncompatibleFeatures
        {
            get { yield return new BerserkFeature(); }
        }
    }
}
using System.Collections.Generic;

namespace Monstromatic.Models
{
    public class BerserkFeature : FeatureBase
    {
        public override string Id => nameof(BerserkFeature);
        public override string DisplayName => "Упорный/Берсерк";

        public override IEnumerable<FeatureBase> IncompatibleFeatures
        {
            get { yield return new CowardFeature(); }
        }
    }
}
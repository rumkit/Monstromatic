using System.Collections.Generic;

namespace Monstromatic.Models
{
    public class BerserkFeature : FeatureBase
    {
        public override string Id => nameof(BerserkFeature);
        public override string DisplayName => "Упорный/Берсерк";

        public override IEnumerable<string> IncompatibleFeatures
        {
            get { yield return nameof(CowardFeature); }
        }
    }
}
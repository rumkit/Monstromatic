using System;
using System.Collections.Generic;

namespace Monstromatic.Models
{
    public class BerserkFeature : FeatureBase
    {
        public override string Id => nameof(BerserkFeature);
        public override string DisplayName => "Упорн.Берсерк";

        public override string DetailsDisplayName => "Не бежит";
        public override string Description => "Не бежит";

        public override IEnumerable<FeatureBase> IncompatibleFeatures
        {
            get { yield return new CowardFeature(); }
        }
    }
}
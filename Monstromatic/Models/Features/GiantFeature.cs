﻿using System.Collections.Generic;

namespace Monstromatic.Models
{
    public class GiantFeature : FeatureBase
    {
        public override string Id => nameof(GiantFeature);
        public override string DisplayName => "Гигант";

        // Level modifier is inherited from BigSizeFeature
        // that is considered as included into the GiantFeature
        public override int LevelModifier => 1;
        public override int BraveryModifier => 1;

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
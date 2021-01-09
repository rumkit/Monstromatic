using System.Collections.Generic;

namespace Monstromatic.Models
{
    public class ArmorFeature : FeatureBase
    {
        public override string Id => nameof(ArmorFeature);
        public override string DisplayName => "Броня/Маг";
        public override int LevelModifier => 0;
        public override int DefenceModifier => 1;
        
        public override IEnumerable<FeatureBase> IncompatibleFeatures
        {
            get { yield return new FlyingFeature(); }
        }
    }
}
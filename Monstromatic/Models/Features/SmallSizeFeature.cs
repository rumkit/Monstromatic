using System.Collections.Generic;

namespace Monstromatic.Models
{
    public class SmallSizeFeature : FeatureBase
    {
        public override string Id => nameof(SmallSizeFeature);
        public override string DisplayName => "Маленький";
        public override int LevelModifier => 1;
        public override int AttackModifier => -1;

        public override IEnumerable<FeatureBase> IncompatibleFeatures
        {
            get
            {
                yield return new BigSizeFeature();
                yield return new GiantFeature();
            }
        }

        public override IEnumerable<FeatureBase> ExcludedFeatures
        {
            get { yield return new PowerfulAttackFeature(); }
        }
    }
}
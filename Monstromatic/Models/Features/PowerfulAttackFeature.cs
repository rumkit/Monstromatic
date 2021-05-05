using System.Collections.Generic;

namespace Monstromatic.Models
{
    public class PowerfulAttackFeature : FeatureBase
    {
        public override string Id => nameof(PowerfulAttackFeature);
        public override string DisplayName => "Мощ. Атака";
        public override int AttackModifier => 1;

        public override IEnumerable<FeatureBase> ExcludedFeatures
        {
            get { yield return new SmallSizeFeature(); }
        }
    }
}
using System.Collections.Generic;

namespace Monstromatic.Models
{
    public class PowerfulAttackFeature : FeatureBase
    {
        public override string Id => nameof(PowerfulAttackFeature);
        public override string DisplayName => "Мощная атака/Маг/Яд";
        public override string DetailsDisplayName => "Мощная атака";
        public override string Description => "Атака увеличена вдвое";

        public override int AttackModifier => 1;

        public override IEnumerable<FeatureBase> ExcludedFeatures
        {
            get { yield return new SmallSizeFeature(); }
        }
    }
}
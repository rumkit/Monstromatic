using System.Collections.Generic;

namespace Monstromatic.Models
{
    public class SmallSizeFeature : FeatureBase
    {
        public override string Id => nameof(SmallSizeFeature);
        public override string DisplayName => "Малый размер";
        public override string DetailsDisplayName => "Безвредный";
        public override int LevelModifier => 1;
        public override string Description => "Не способен наносить ран, если не ядовит";

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
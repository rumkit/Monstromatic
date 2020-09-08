using System.Collections.Generic;

namespace Monstromatic.Models
{
    public class PowerfulAttackFeature : FeatureBase
    {
        public override string Id => nameof(PowerfulAttackFeature);
        public override string DisplayName => "Мощная атака/Маг/Яд";
        public override string DetailsDisplayName => "Мощная атака";
        public override string Description => "Оглушает цель в случае успешной атаки";

        public override IEnumerable<FeatureBase> MutexFeatures
        {
            get { yield return new SmallSizeFeature(); }
        }
    }
}
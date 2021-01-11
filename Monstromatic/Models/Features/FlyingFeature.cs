using System.Collections.Generic;

namespace Monstromatic.Models
{
    public class FlyingFeature : FeatureBase
    {
        public override string Id => nameof(FlyingFeature);
        public override string DisplayName => "Полет";
        public override string Description => "Уязвим только к дальним атакам (пока не кончится храбрость)";

        public override IEnumerable<FeatureBase> IncompatibleFeatures
        {
            get
            {
                yield return new ArmorFeature();
            }
        }
    }
}
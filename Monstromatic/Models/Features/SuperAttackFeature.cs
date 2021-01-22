using System.Collections.Generic;

namespace Monstromatic.Models
{
    public class SuperAttackFeature : FeatureBase
    {
        public override string Id => nameof(SuperAttackFeature);
        public override string DisplayName => "Суперудар";
        public override string DetailsDisplayName => "Суперудар";
        public override string Description => "Атака х2 при суперударе";

        public override IEnumerable<FeatureBase> IncompatibleFeatures
        {
            get { yield return new PowerfulAttackFeature(); }
        }
    }
}
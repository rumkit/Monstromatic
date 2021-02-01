using System.Collections.Generic;

namespace Monstromatic.Models
{
    [HideFeature]
    public class GroupFeature : FeatureBase
    {
        public override string Id => nameof(GroupFeature);
        public override string DisplayName => "Группа";
        public override string Description => "Раз два три... много";
        public override string DetailsDisplayName => "Масс. атака";

        public override int LevelModifier => 1;
        public int Count { get; set; }

        public override IEnumerable<FeatureBase> IncludedFeatures
        {
            get
            {
                yield return new MassAttackFeature();
            }
        }

        public override IEnumerable<FeatureBase> ExcludedFeatures
        {
            get { yield return new SmallSizeFeature(); }
        }
    }
}
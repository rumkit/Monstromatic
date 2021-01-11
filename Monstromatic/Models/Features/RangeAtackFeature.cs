namespace Monstromatic.Models
{
    public class RangeAtackFeature : FeatureBase
    {
        public override string Id => nameof(RangeAtackFeature);
        public override string DisplayName => "Даль. бой";
        public override string DetailsDisplayName => "Дистанционная атака";
        public override string Description => "Атакует на дистанции";
    }
}
namespace Monstromatic.Models
{
    public class AbberationFeature : FeatureBase
    {
        public override string Id => nameof(AbberationFeature);
        public override string DisplayName => "Гад/Абберация";
        public override int LevelModifier => 1;
    }
}
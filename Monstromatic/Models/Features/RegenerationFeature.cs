namespace Monstromatic.Models
{
    public class RegenerationFeature : FeatureBase
    {
        public override string Id => nameof(RegenerationFeature);
        public override string DisplayName => "Регенрация/Маг";
        public override int LevelModifier => 1;
    }
}
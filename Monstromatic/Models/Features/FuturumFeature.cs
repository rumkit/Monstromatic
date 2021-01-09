namespace Monstromatic.Models
{
    public class FuturumFeature : FeatureBase
    {
        public override string Id => nameof(FuturumFeature);
        public override string DisplayName => "Sci-Fi/Futurum";
        public override int LevelModifier => 1;
    }
}
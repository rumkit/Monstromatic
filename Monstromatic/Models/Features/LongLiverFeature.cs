namespace Monstromatic.Models
{
    public class LongLiverFeature : FeatureBase
    {
        public override string Id => nameof(LongLiverFeature);
        public override string DisplayName => "Долгожитель";
        public override int LevelModifier => 1;
    }
}